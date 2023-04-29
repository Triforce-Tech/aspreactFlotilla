import React from 'react';
import { Form, FormGroup, FormControl, Button } from 'react-bootstrap';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import MyDatePicker from './MyDatePicker';
import Container from 'react-bootstrap/Container';


function NewOrder() {
  return (
    <Container>
      <h1>Nueva Orden</h1>
    <Form>
      <Row>
      <Col>
      <Form.Group className="mb-3">
      <Form.Label>Seleccione una fecha</Form.Label>
      <MyDatePicker></MyDatePicker>
      </Form.Group>
      <FormGroup className="mb-3">
        <Form.Label>Dirección de recolección</Form.Label>
        <FormControl type="text"/>
      </FormGroup>
      <FormGroup controlId="formBasicPassword">
        <Form.Label>Dirección de entrega</Form.Label>
        <FormControl type="text"/>
      </FormGroup>
      </Col>

      <Col>
      <Form.Group className="mb-3">
        <Form.Label>Vehiculo</Form.Label>
        <Form.Select>
          <option>Vehiculo 1</option>
          <option>Vehiculo 2</option>
          <option>Vehiculo 3</option>
          <option>Vehiculo 4</option>
          <option>Vehiculo 5</option>
        </Form.Select>
      </Form.Group>
      </Col>

      <Col>
      <Form.Group className="mb-3">
        <Form.Label>Piloto</Form.Label>
        <Form.Select>
          <option>Piloto 1</option>
          <option>Piloto 2</option>
          <option>Piloto 3</option>
          <option>Piloto 4</option>
          <option>Piloto 5</option>
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