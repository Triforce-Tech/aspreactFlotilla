import React, { useState, useEffect } from 'react';
import { Form, FormGroup, FormControl, Button } from 'react-bootstrap';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import MyDatePicker from './MyDatePicker';
import Container from 'react-bootstrap/Container';
import DatePicker from 'react-datepicker';
import Card from 'react-bootstrap/Card';
import Nav from 'react-bootstrap/Nav';


function NewOrder() {
    const [shipfrom, setShipfrom] = useState('');
    const [shipto, setShipto] = useState('');
    const [data, setData] = useState([]);
    const [selectedOption, setSelectedOption] = useState('');
    const [vehicle, setVehicle] = useState('');
    const [driver, setDriver] = useState('');
    const [selectedDate, setSelectedDate] = useState(null);

    useEffect(() => {
        fetch('/api/vehicle/Lista')
            .then(response => response.json())
            .then(json => setData(json));
    }, []);

    useEffect(() => {
        fetch('/api/operador/Lista')
            .then(response => response.json())
            .then(json => setData(json));
    }, []);

    function handleSelectChange(event) {
        setSelectedOption(event.target.value);
    }

    return (
        <Container>
        <h1>Nueva Orden</h1>
        <Card>
                <Card.Header>
                    <Nav variant="tabs" defaultActiveKey="#first">
                        <Nav.Item>
                            <Nav.Link href="#first">Active</Nav.Link>
                        </Nav.Item>
                        <Nav.Item>
                            <Nav.Link href="#link">Link</Nav.Link>
                        </Nav.Item>
                        <Nav.Item>
                            <Nav.Link href="#disabled" disabled>
                                Disabled
                            </Nav.Link>
                        </Nav.Item>
                    </Nav>
                </Card.Header>
            <Card.Body>
            <Form>
                <Row>
                    <Col>
                        <Form.Group className="mb-3">
                            <Form.Label>Seleccione la fecha de recolección</Form.Label>
                            < DatePicker
                                selected={selectedDate}
                                onChange={date => setSelectedDate(date)}
                                dateFormat="dd-MM-yyyy"
                                placeholderText="Seleccione una fecha"
                            />
                        </Form.Group>
                        <FormGroup className="mb-3">
                            <Form.Label>Dirección de recolección</Form.Label>
                            <FormControl
                                type="text"
                                id="shipfrom"
                                name="shipfrom"
                                value={shipfrom}
                                onChange={(event) => setShipfrom(event.target.value)}
                            />
                        </FormGroup>
                        <FormGroup controlId="formBasicPassword">
                            <Form.Label>Dirección de entrega</Form.Label>
                            <FormControl
                                type="text"
                                id="shipto"
                                name="shipto"
                                value={shipto}
                                onChange={(event) => setShipto(event.target.value)}
                            />
                        </FormGroup>
                    </Col>

                    <Col>
                        <Form.Group className="mb-3">
                        <Form.Label>Piloto</Form.Label>
                            <Form.Select value={selectedOption} onChange={(handleSelectChange) => setDriver(handleSelectChange.target.value)}>
                                <option value="">Seleccione el piloto</option>


                                {
                                    (data.length < 1) ?
                                        (
                                            <option value="">No hay data</option>

                                        ) : (
                                            data.map(vehicle => (
                                                <option key={driver.uuid} value={driver.uuid}>{driver.descripcion}</option>

                                            ))
                                        )}
                            </Form.Select>    
                        </Form.Group>
                    </Col>

                    <Col>
                        <Form.Group className="mb-3">
                            <Form.Label>Piloto</Form.Label>
                            <Form.Select value={selectedOption} onChange={(handleSelectChange) => setVehicle(handleSelectChange.target.value)}>
                                <option value="">Seleccione el vehiculo</option>


                                {
                                    (data.length < 1) ?
                                        (
                                            <option value="">No hay data</option>

                                        ) : (
                                            data.map(vehicle => (
                                                <option key={vehicle.uuid} value={vehicle.uuid}>{vehicle.descripcion}</option>

                                            ))
                                        )}
                            </Form.Select>
                        </Form.Group>
                    </Col>
                </Row>

                <Col>

                </Col>



                <Button variant="primary" type="submit">
                    Registrar Orden
                </Button>

            </Form>
            </Card.Body>
        </Card>
        </Container>
    );
}

export default NewOrder;