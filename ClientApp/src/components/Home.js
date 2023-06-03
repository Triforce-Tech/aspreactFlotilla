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
import axios from 'axios';


function HOME() {



    const handleSubmit = (event) => {
        event.preventDefault();
        // Aquí podrías enviar los datos del formulario al servidor
    };
    const [data, setData] = useState([]);

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        try {
            const response = await axios.post('/api/home/Lista', {
                id:"",
                value: "",
            }); // Cambia la ruta '/api/data' por la ruta correcta para obtener tus datos JSON desde ASP.NET Core
            setData(response.data);
        } catch (error) {
            console.log(error);
        }
    };
    const [data1, setData1] = useState([]);

    useEffect(() => {
        fetchData1();
    }, []);

    const fetchData1 = async () => {
        try {
            const response = await axios.post('/api/home/Lista1', {
                id: "",
                value: "",
            }); // Cambia la ruta '/api/data' por la ruta correcta para obtener tus datos JSON desde ASP.NET Core
            setData1(response.data);
        } catch (error) {
            console.log(error);
        }
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

           
            <Form.Group className="mb-3" onSubmit={handleSubmit}>
                <div>
                    <h1>MIS ORDENES</h1>
                    <Table className="table" striped bordered hover size="sm">
                        <thead>
                            <tr>
                                <th>UUID</th>
                                <th>KM</th>
                                <th>FECHA IGRESO</th>
                                <th>FECHA ASIGACION</th>
                                <th>DESCRIPCION</th>
                                <th>EMPRESA</th>
                                <th>PRECIO</th>
                                
                                {/* Añade más encabezados de columnas según tus datos JSON */}
                            </tr>
                        </thead>
                        <tbody>
                            {data.map((item) => (
                                <tr key={item.uuid}>
                                    <td>{item.uuid}</td>
                                    <td>{item.km}</td>
                                    <td>{item.fechA_ENTREGA}</td>
                                    <td>{item.fechA_RECOLECCION}</td>
                                    <td>{item.descripcion}</td>
                                    <td>{item.empresa}</td>
                                    <td>{item.precio}</td>
                                    {/* Añade más celdas según las propiedades de tu objeto JSON */}
                                </tr>
                            ))}
                        </tbody>
                    </Table>
                </div>


            </Form.Group>



       
            <Form.Group className="mb-3" onSubmit={handleSubmit}>
                <h1>MIS ORDENES</h1>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>ORDEN</th>
                            <th>DESC</th>
                        </tr>
                    </thead>
                    <tbody>
                        {data1.map((item) => (
                            <tr key={item.uuid}>
                                <td>{item.uuid}</td>
                                <td>{item.km}</td>
                                <td>{item.fechA_ENTREGA}</td>
                                <td>{item.fechA_RECOLECCION}</td>
                                <td>{item.descripcion}</td>
                                <td>{item.empresa}</td>
                                <td>{item.precio}</td>
                                {/* Añade más celdas según las propiedades de tu objeto JSON */}
                            </tr>
                        ))}
                    </tbody>
                </Table>
            </Form.Group>


        </Container>
        </div>



    );


}

export default HOME;