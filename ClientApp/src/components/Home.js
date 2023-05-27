/*import logo from './logo.svg';*/
import { useState, useEffect } from 'react';
import './styles.css';
import NavigationBar from './NavigationBar';
import Form from 'react-bootstrap/Form';
import ReactDOM from "react-dom/client";
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Table from 'react-bootstrap/Table';
import Carousel from 'react-bootstrap/Carousel';
import { useSession } from 'react-session';



function HOME() {

    

    const handleSubmit = (event) => {
        event.preventDefault();
        // Aquí podrías enviar los datos del formulario al servidor
    };
 
     

    return (

        <div><Container>



            <h1>HOME</h1>
            <p1>BIENVENIDO USUARIO</p1>
            <Container>

                <Carousel>
                    <Carousel.Item>
                        <img
                            className="d-block w-100"
                            src="https://www.ubicalo.com.mx/wp-content/uploads/2020/05/original-bcb8dfae789303136afad728286b86fe.jpeg"
                            alt="First slide"
                        />
                        <Carousel.Caption>
                            <h3>Transportes logistics te asegura siempre tu pedido a la direccion exacta </h3>
                            <p>estamos siempre cuidando tu mercaderia</p>
                        </Carousel.Caption>
                    </Carousel.Item>
                    <Carousel.Item>
                        <img
                            className="d-block w-100"
                            src="https://images.prismic.io/simpliroute/fc06a986-891b-4a3b-b48f-5e0346833517_tipos+de+camiones+de+carga.jpg?auto=compress,format"
                            alt="Second slide"
                        />

                        <Carousel.Caption>
                            <h3>mantente al dia con tus ordenes de envio </h3>
                            <p>contamos con rastreo satelital</p>
                        </Carousel.Caption>
                    </Carousel.Item>
                    <Carousel.Item>
                        <img
                            className="d-block w-100"
                            src="https://us.123rf.com/450wm/dell640/dell6401804/dell640180400085/100284729-cami%C3%B3n-de-estilo-americano-en-la-autopista-tirando-de-la-carga.jpg"
                            alt="Third slide"
                        />

                        <Carousel.Caption>
                            <h3>Camiones seguros para tu negocio</h3>
                            <p>
                               nuestros camiones siempre contaran con seguridad y rastreo para que sepas donde esta tu mercaderias 
                            </p>
                        </Carousel.Caption>
                    </Carousel.Item>
                </Carousel>

                
            </Container>

            <p1>MIS ORDENES </p1>
            <Form.Group className="mb-3" onSubmit={handleSubmit}>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>ORDEN</th>
                            <th>DESC</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1</td>
                            <td>Orden1</td>
                            <td>Lorem</td>
                        </tr>

                        <tr>
                            <td>2</td>
                            <td>Orden2</td>
                            <td>Lorem</td>

                        </tr>
                        <tr>
                            <td>3</td>
                            <td>orden3</td>
                            <td>Lorem</td>
                        </tr>
                        <tr>
                            <td>4</td>
                            <td>orden 4</td>
                            <td>Lorem</td>
                        </tr>
                        <tr>
                            <td>5</td>
                            <td>orden 5</td>
                            <td>Lorem</td>
                        </tr>
                    </tbody>
                </Table>

            </Form.Group>

            <p1>Vehiculos disponibles </p1>
            <Form.Group className="mb-3" onSubmit={handleSubmit}>




                <Table striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>ORDEN</th>
                            <th>DESC</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1</td>
                            <td>Orden1</td>
                            <td>Lorem</td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Orden2</td>
                            <td>Lorem</td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>orden3</td>
                            <td>Lorem</td>
                        </tr>
                        <tr>
                            <td>4</td>
                            <td>orden 4</td>
                            <td>Lorem</td>
                        </tr>
                        <tr>
                            <td>5</td>
                            <td>orden 5</td>
                            <td>Lorem</td>
                        </tr>
                    </tbody>
                </Table>
            </Form.Group>


        </Container>
        </div>



    );


}

export default HOME;