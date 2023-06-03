import { useState, useEffect } from 'react';
import './styles.css';
//import NavigationBar from './NavigationBar';
import Form from 'react-bootstrap/Form';
import ReactDOM from "react-dom/client";
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import Nav from 'react-bootstrap/Nav';
import { ToastContainer, toast } from 'react-toastify';
import Cookies from 'js-cookie';
import Alert from 'react-bootstrap/Alert';
import axios from 'axios';
import { useSession } from 'react-session';
import {
    BrowserRouter as Router,
    Link,
    Routes,
    Route,
} from "react-router-dom";
import { useHistory } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import React from 'react';

import {
    MDBBtn,
    MDBContainer,
    MDBCard,
    MDBCardBody,
    MDBCol,
    MDBRow,
    MDBInput,
    MDBCheckbox,
    MDBIcon,
    MDBBadge
}
    from 'mdb-react-ui-kit';
import { Badge } from 'reactstrap';


function Login() {
    const [USER, setUser] = useState('');
    const [PASSWORD, setPassword] = useState('');

    const redirigir = () => {
        window.location.href = 'http://localhost:44422/home';
    };
    const handleSubmit = (event) => {
        event.preventDefault();
        // Aquí podrías enviar los datos del formulario al servidor
    };

    function handleSaveClick() {
        //console.log(`Saving ${field1} and ${field2}`);
        iniciarsesion();

        // Hacer una solicitud HTTP para guardar los datos

    }

    /*setSession('valorDeMiVariable')*/
 
    const [data, setData] = useState([null]);
    useEffect(() => {
        fetch('/api/session/consultasession')
            .then(response => response.json())
            .then(json => setData(json));
    }, []);
  
    


    

    const [show, setShow] = useState(false);

    const [value1, setvalue1] = useState(false);


    
    function iniciarsesion() {

        axios.post('/api/session/guardarsession', {
            uuid: "",
            usuario: USER,
            password: PASSWORD,
            UUID_ESTADO: ""

        })

            .then(response => {
                console.log('login correcto');
                console.log(response.data);
                if (response.data === 'ok') {
                    redirigir();

                } else {
                    console.log('sin acceso');
                    console.log(data);
                    setvalue1.value = true;
                }
             
                
                
                toast.success('¡Operación exitosa!', {
                    position: toast.POSITION.TOP_CENTER
                });
            })
            .catch(error => {
                value1 = true;
                console.error('Error login:');
                console.error(error);
            });
    }

  


    return (



        <MDBContainer fluid>

            <div className="p-5 bg-image" style={{ backgroundImage: 'url(https://mdbootstrap.com/img/new/textures/full/171.jpg)', height: '300px' }}></div>

            <MDBCard className='mx-5 mb-5 p-5 shadow-5' style={{ marginTop: '-100px', background: 'hsla(0, 0%, 100%, 0.8)', backdropFilter: 'blur(30px)' }}>
                <MDBCardBody className='p-5 text-center'>

                    <h2 className="fw-bold mb-5">Inicia sesion ahora!</h2>

                    <Form.Group className="mb-3" onSubmit={handleSubmit}>
                        <Form.Label htmlFor="USER">Usuario:</Form.Label>
                        <Form.Control
                            type="text"
                            id="USER"
                            name="USER"
                            value={USER}
                            onChange={(event) => setUser(event.target.value)}
                        />

                        <Form.Label htmlFor="PASSWORD">Contraseña:</Form.Label>
                        <Form.Control
                            type="password"
                            id="PASSWORD"
                            name="PASSWORD"
                            value={PASSWORD}
                            onChange={(event) => setPassword(event.target.value)}
                        />

                        

                        <MDBBtn className='w-100 mb-4' size='md' onClick={() => setShow(true)} onClick={handleSaveClick}>Ingresa</MDBBtn>
              
                        <Button className='w-100 mb-4' size='md'  variant="success" as={Link} to={"/registeruser"}>Registrarse</Button>

                    </Form.Group>





                </MDBCardBody>
            </MDBCard>

        </MDBContainer>



    );
}
export default Login;