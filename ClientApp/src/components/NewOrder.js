import React, { useState, useEffect } from 'react';
import { Form, FormGroup, FormControl, Button } from 'react-bootstrap';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import MyDatePicker from './MyDatePicker';
import Container from 'react-bootstrap/Container';


function NewOrder() {
    const [shipfrom, setShipfrom] = useState('');
    const [shipto, setShipto] = useState('');
    const [data, setData] = useState([]);
    const [selectedOption, setSelectedOption] = useState('');
    const [vehicle, setVehicle] = useState('');
    const [driver, setDriver] = useState('');

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
            <Form>
                <Row>
                    <Col>
                        <Form.Group className="mb-3">
                            <Form.Label>Seleccione una fecha</Form.Label>
                            < MyDatePicker / >
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
        </Container>
    );
}

export default NewOrder;