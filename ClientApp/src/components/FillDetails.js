import React, { useState, useEffect } from 'react';
import { Form, FormGroup, FormControl, Button } from 'react-bootstrap';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';
import DatePicker from 'react-datepicker';
import { useSession } from 'react-session';


function FillDetails() {

     
    const [shipfrom, setShipfrom] = useState('');
    const [shipto, setShipto] = useState('');
    const [data, setData] = useState([]);
    const [selectedOption, setSelectedOption] = useState('');
    const [vehicle, setVehicle] = useState('');
    const [driver, setDriver] = useState('');
    const [description, setDescription] = useState('');
    const [selectedDate, setSelectedDate] = useState(null);
    const [data1, setData1] = useState([]);




    function listarvehiculo() {
        axios.post('/api/vehiculo/Lista', id: "", value: "")
            .then(response => response.json())
            .then(json => setData1(json));
    }, []);


    }
        
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
                    </Col>
                    <Col>
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
                    </Col>
                    <Col>
                        <FormGroup className="mb-3">
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
                </Row>
                <Row>

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
                            <Form.Label>Vehiculo</Form.Label>
                            <Form.Select value={selectedOption} onChange={(handleSelectChange) => setVehicle(handleSelectChange.target.value)}>
                                <option value="">Seleccione el vehiculo</option>


                                {
                                    (data1.length < 1) ?
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

                    <Col>
                        <Form.Group className="mb-3">
                            <Form.Label>Descripcion</Form.Label>
                            <FormControl
                                type="text"
                                id="description"
                                name="description"
                                value={description}
                                onChange={(event) => setDescription(event.target.value)}
                            />
                        </Form.Group>
                    </Col>

                </Row>




                

            </Form>

        </Container>

    )

}

export default FillDetails;