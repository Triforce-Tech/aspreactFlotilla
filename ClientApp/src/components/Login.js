import { useState, useEffect } from 'react';
import './styles.css';
import NavigationBar from './NavigationBar';
import Form from 'react-bootstrap/Form';
import ReactDOM from "react-dom/client";
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import Nav from 'react-bootstrap/Nav';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
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



function Login() {
    const [USER, setUser] = useState('');
    const [PASSWORD, setPassword] = useState('');

    

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

    const [data, setData] = useState([]);
    const [show, setShow] = useState(false);


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
                toast.success('¡Operación exitosa!', {
                    position: toast.POSITION.TOP_CENTER
                });
            })
            .catch(error => {
                console.error('Error login:');
                console.error(error);
            });
    }


    return (
        
        <Container>
            <h1>Bienvenido Usuario!</h1>
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

                <Button variant="success" onClick={() => setShow(true)} onClick={handleSaveClick}>Iniciar Sesión</Button>{' '}
                <h2></h2>
                <Button variant="success" as={Link} to={"/registeruser"}>Registrarse</Button>
                {/*<Button variant="success" as={Link} to={"/home"}>Redireccionar</Button>*/}
            </Form.Group>

            

            </Container>


    );
}

export default Login;