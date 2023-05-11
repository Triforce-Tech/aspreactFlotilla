import React, { useState, useEffect } from 'react';
import { Form, FormGroup, FormControl, Button } from 'react-bootstrap';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import MyDatePicker from './MyDatePicker';
import Container from 'react-bootstrap/Container';
import DatePicker from 'react-datepicker';
import Card from 'react-bootstrap/Card';
import Nav from 'react-bootstrap/Nav';
import {
    BrowserRouter as Router,
    Link,
    Routes,
    Route,
} from "react-router-dom";
import FillDetails from './FillDetails';
import RegisterUser from './RegisterUser';


function NewOrder() {
    const [activeTab, setActiveTab] = useState('filldetails');

    const handleNavClick = (tab) => {
        setActiveTab(tab);
    };


    return (

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
                            <Card.Text>Contenido de la pestaña Acerca de.</Card.Text>
                            <Button variant="primary" onClick={() => handleNavClick('mapshipto')}>
                                Siguiente
                            </Button>
                        </>
                    )}
                    {activeTab === 'mapshipto' && (
                        <>
                            <Card.Title>Contacto</Card.Title>
                            <Card.Text>Contenido de la pestaña Contacto.</Card.Text>
                            <Button variant="success" onClick={() => handleNavClick('filldetails')}>
                                Registrar Orden
                            </Button>
                        </>
                    )}
                                 
                </Card.Body>


                 
        </Card>
        </Container>
        
    );
}

export default NewOrder;