import React, { useState } from 'react';
import NavigationBar from './NavigationBar';
import Form from 'react-bootstrap/Form';
import ReactDOM from "react-dom/client";
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';
import Button from 'react-bootstrap/Button';

function RegisterVehicle() {
  const [plate, setPlate] = useState('');
  const [descripcion, setDescripcion] = useState('');
  const [km, setKm] = useState('');
  const [brand, setBrand] = useState('');
  const [model, setModel] = useState('');
  const [year, setYear] = useState('');

  const handleSubmit = (event) => {
    event.preventDefault();
    // Aquí podrías enviar los datos del formulario al servidor
  };

  return (
      <div><Container>
      <h1>Registrar Vehiculo</h1>
      <Form.Group className="mb-3" onSubmit={handleSubmit}>
        <Row>
        <Col>
        <Form.Label htmlFor="plate">Placa:</Form.Label>
        <Form.Control
          type="text"
          id="plate"
          name="plate"
          value={plate}
          onChange={(event) => setPlate(event.target.value)}
        />
        </Col>
        <Col>
        <Form.Label htmlFor="descripcion">Descripcion:</Form.Label>
        <Form.Control
          type="text"
          id="descripcion"
          name="descripcion"
          value={descripcion}
          onChange={(event) => setDescripcion(event.target.value)}
        />
        </Col>
        <Col>
        <Form.Label htmlFor="km">Kilometraje Actual:</Form.Label>
        <Form.Control
          type="text"
          id="km"
          name="km"
          value={km}
          onChange={(event) => setKm(event.target.value)}
        />
        </Col>
        </Row>

        <Row>
        <Col>
        <Form.Label htmlFor="brand">Marca:</Form.Label>
        <Form.Control
          type="text"
          id="brand"
          name="brand"
          value={brand}
          onChange={(event) => setBrand(event.target.value)}
        />
        </Col>
        <Col>
        <Form.Label htmlFor="model">Modelo:</Form.Label>
        <Form.Control
          type="text"
          id="model"
          name="model"
          value={model}
          onChange={(event) => setModel(event.target.value)}
        />
        </Col>
        <Col>
        <Form.Label htmlFor="year">Año:</Form.Label>
        <Form.Control
          type="text"
          id="year"
          name="year"
          value={year}
          onChange={(event) => setYear(event.target.value)}
        />
        </Col>
        </Row>
        
        <button type="submit">Registrar</button>
       </Form.Group>
      </Container>
      </div>
  );
}

export default RegisterVehicle;