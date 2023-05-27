import React, { useState, useEffect } from 'react';
import { Button } from 'react-bootstrap';
import Container from 'react-bootstrap/Container';
import Card from 'react-bootstrap/Card';
import Nav from 'react-bootstrap/Nav';
import FillDetails from './FillDetails';
import ShipFrom from './ShipFrom';
import { useSession } from 'react-session';
import ShipTo from './ShipTo';





function NewOrder() {
    const [activeTab, setActiveTab] = useState('filldetails');


    const handleNavClick = (tab) => {
        setActiveTab(tab);
    };

    const [data, setData] = useState([null]);

    useEffect(() => {
        fetch('/api/session/consultasession')
            .then(response => response.json())
            .then(json => setData(json));
    }, []);
    var mostrarContenido = false;

    if (data.length === 2) {
        mostrarContenido = true;
    }
    return (



        <Container>

            {mostrarContenido ? (
                <Container>
                 <h1>Nueva Orden</h1>
                 <Card>
                <Card.Header>
                    <Nav variant="tabs" defaultActiveKey="neworder">
                        <Nav.Item>
                            <Nav.Link
                                active={activeTab === 'filldetails'}
                                onClick={() => handleNavClick('filldetails')}
                            >Detalles</Nav.Link>
                        </Nav.Item>
                        <Nav.Item>
                            <Nav.Link
                                active={activeTab === 'mapshipfrom'}
                                onClick={() => handleNavClick('mapshipfrom')}
                            >Seleccione punto de recoleccion</Nav.Link>
                        </Nav.Item>
                        <Nav.Item>
                            <Nav.Link
                                active={activeTab === 'mapshipto'}
                                onClick={() => handleNavClick('mapshipto')}
                            >
                                Seleccione punto de entrega
                            </Nav.Link>
                        </Nav.Item>
                    </Nav>
                </Card.Header>
                <Card.Body>

                    {activeTab === 'filldetails' && (
                        <>
                            <Card.Title>Detalle</Card.Title>
                            <Card.Text><FillDetails /></Card.Text>
                            <Button variant="primary" onClick={() => handleNavClick('mapshipfrom')}>
                                Siguiente
                            </Button>
                        </>
                    )}
                    {activeTab === 'mapshipfrom' && (
                        <>
                            <Card.Title>Acerca de</Card.Title>
                            <Card.Text><ShipFrom/></Card.Text>
                            <Button variant="primary" onClick={() => handleNavClick('mapshipto')}>
                                Siguiente
                            </Button>
                        </>
                    )}
                    {activeTab === 'mapshipto' && (
                        <>
                            <Card.Title>Contacto</Card.Title>
                            <Card.Text><ShipTo/></Card.Text>
                            <Button variant="success" onClick={() => handleNavClick('filldetails')}>
                                Registrar Orden
                            </Button>
                        </>
                    )}
                                 
                </Card.Body>


                 
        </Card>
        </Container>
            ) : (

                <p></p>
            )
            } 


        </Container>


    );
}

export default NewOrder;