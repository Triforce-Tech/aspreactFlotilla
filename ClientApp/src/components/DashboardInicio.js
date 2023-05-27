import React from "react";
import { Container, Row, Col, Card, Button } from "reactstrap";
import { useSession } from 'react-session';

function DashboardInicio() {
    

  return (
    <Container fluid>
      <Row>
        <Col sm={4}>
          <Card>
            <Card.Header>Últimas noticias</Card.Header>
            <Card.Body>
              <Card.Title>Encabezado de noticia</Card.Title>
              <Card.Text>
                Aquí va el contenido de la noticia. Puedes poner un resumen o
                la noticia completa.
              </Card.Text>
              <Button variant="primary">Leer más</Button>
            </Card.Body>
          </Card>
        </Col>
        <Col sm={4}>
          <Card>
            <Card.Header>Eventos próximos</Card.Header>
            <Card.Body>
              <Card.Title>Encabezado del evento</Card.Title>
              <Card.Text>
                Aquí puedes poner información sobre el evento, como la fecha y
                la hora, la ubicación, los detalles, etc.
              </Card.Text>
              <Button variant="primary">Más detalles</Button>
            </Card.Body>
          </Card>
        </Col>
        <Col sm={4}>
          <Card>
            <Card.Header>Estadísticas del sitio</Card.Header>
            <Card.Body>
              <Card.Title>Número de visitas</Card.Title>
              <Card.Text>Aquí puedes poner las estadísticas del sitio.</Card.Text>
              <Button variant="primary">Más detalles</Button>
            </Card.Body>
          </Card>
        </Col>
      </Row>
    </Container>
  );
}

export default DashboardInicio;
