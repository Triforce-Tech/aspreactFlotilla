/*import logo from './logo.svg';*/
import { useState, useEffect } from 'react';
import './styles.css';
import NavigationBar from './NavigationBar';
import Form from 'react-bootstrap/Form';
import ReactDOM from "react-dom/client";
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';
import Button from 'react-bootstrap/Button';

import axios from 'axios';


function RegisterUser() {
    const [username, setUsername] = useState('');
    const [PRIMER_NOMBRE, setPRIMER_NOMBRE] = useState('');
    const [SEGUNDO_NOMBRE, setSEGUNDO_NOMBRE] = useState('');
    const [SEGUNDO_APELLIDO, setSEGUNDO_APELLIDO] = useState('');
    const [PRIMER_APELLIDO, setPRIMER_APELLIDO] = useState('');
    const [DPI, setDpi] = useState('');
    const [address, setAddress] = useState('');
    const [phonenumber, setPhonenumber] = useState('');
    const [company, setCompany] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [passwordConfirm, setPasswordConfirm] = useState('');
    const [usertype, setUserType] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();
        // Aquí podrías enviar los datos del formulario al servidor
    };

    const [data, setData] = useState([]);
    const [selectedOption, setSelectedOption] = useState('');

    useEffect(() => {
        fetch('/api/usuario/Tipousuario')
            .then(response => response.json())
            .then(json => setData(json));
    }, []);

    function handleSelectChange(event) {
        setSelectedOption(event.target.value);
    }
    function SaveButton() {


        function handleSaveClick() {
            //console.log(`Saving ${field1} and ${field2}`);

            // Hacer una solicitud HTTP para guardar los datos
            axios.post('/api/usuario/Guardar', {
                PRIMER_NOMBRE: PRIMER_NOMBRE,
                SEGUNDO_NOMBRE: SEGUNDO_NOMBRE,
                PRIMER_APELLIDO: PRIMER_APELLIDO,
                SEGUNDO_APELLIDO: SEGUNDO_APELLIDO,
                DPI: DPI,
                address: address,
                phonenumber: phonenumber,
                company: company,
                email: email,
                password: password,
                passwordConfirm: passwordConfirm,
                usertype: usertype

            })
                .then(response => {
                    console.log('Data saved successfully!');
                    console.log(response.data);
                })
                .catch(error => {
                    console.error('Error saving data:');
                    console.error(error);
                });
        }
    }
   

    return (

        <div><Container>



            <h1>Registrarse</h1>


            

            <Form.Group className="mb-3" onSubmit={handleSubmit}>
                 

              
                <Row>


                    <Col>
                        <Form.Label htmlFor="PRIMER_NOMBRE">PRIMER_NOMBRE:</Form.Label>
                        <Form.Control
                            type="text"
                            id="PRIMER_NOMBRE"
                            name="PRIMER_NOMBRE"
                            value={PRIMER_NOMBRE}
                            onChange={(event) => setPRIMER_NOMBRE(event.target.value)}
                        />
                    </Col>
                    <Col>
                        <Form.Label htmlFor="SEGUNDO_NOMBRE">SEGUNDO_NOMBRE:</Form.Label>
                        <Form.Control
                            type="text"
                            id="SEGUNDO_NOMBRE"
                            name="SEGUNDO_NOMBRE"
                            value={SEGUNDO_NOMBRE}
                            onChange={(event) => setSEGUNDO_NOMBRE(event.target.value)}
                        />
                    </Col>
                    <Col>
                        <Form.Label htmlFor="PRIMER_APELLIDO">PRIMER_APELLIDO:</Form.Label>
                        <Form.Control
                            type="text"
                            id="PRIMER_APELLIDO"
                            name="PRIMER_APELLIDO"
                            value={PRIMER_APELLIDO}
                            onChange={(event) => setPRIMER_APELLIDO(event.target.value)}
                        />
                    </Col>

                    <Col>
                        <Form.Label htmlFor="SEGUNDO_APELLIDO">SEGUNDO_APELLIDO:</Form.Label>
                        <Form.Control
                            type="text"
                            id="SEGUNDO_APELLIDO"
                            name="SEGUNDO_APELLIDO"
                            value={SEGUNDO_APELLIDO}
                            onChange={(event) => setSEGUNDO_APELLIDO(event.target.value)}
                        />
                    </Col>

                   
                    
                </Row>
                <Row>
                    <Col>

                        <Form.Label htmlFor="address">Dirección</Form.Label>
                        <Form.Control
                            type="text"
                            id="address"
                            name="address"
                            value={address}
                            onChange={(event) => setAddress(event.target.value)}
                        /></Col>
                    <Col>  <Form.Label htmlFor="email">Correo electrónico:</Form.Label>
                        <Form.Control
                            type="email"
                            id="email"
                            name="email"
                            value={email}
                            onChange={(event) => setEmail(event.target.value)}
                        /></Col>
                    <Col>  <Form.Label htmlFor="email">DPI:</Form.Label>
                        <Form.Control
                            type="DPI"
                            id="DPI"
                            name="DPI"
                            value={DPI}
                            onChange={(event) => setDpi(event.target.value)}
                        /></Col>
                    <Col>  <Form.Label htmlFor="phonenumber">No. Teléfono:</Form.Label>
                        <Form.Control
                            type="text"
                            id="phonenumber"
                            name="phonenumber"
                            value={phonenumber}
                            onChange={(event) => setPhonenumber(event.target.value)}
                        /></Col>
                    

                </Row>

                <Row>
                    <Col>
                        <Form.Label htmlFor="company">Empresa:</Form.Label>
                        <Form.Control
                            type="text"
                            id="company"
                            name="company"
                            value={company}
                            onChange={(event) => setCompany(event.target.value)}
                        /></Col>
                    <Col>
                        

                        <fieldset enabled>
                           
                            <Form.Group className="mb-3">

                                <div>
                                    <Form.Label htmlFor="disabledSelect">Tipo de Usuario:</Form.Label>
                                    <Form.Select type="UUIDTIPO" id="UUIDTIPO" name="UUIDTIPO" value={selectedOption} onChange={(handleSelectChange) }>
                                        <option value="">Seleccione el estado</option>
                                        {data.map(user => (
                                            <option key={user.uuid} value={user.uuid}>{user.descripcion}</option>
                                        ))}
                                    </Form.Select>
                                </div>
                            </Form.Group>
                          
                        </fieldset>
                       </Col>
                </Row>

                <Row>
                    <Col>
                        <Form.Label htmlFor="username">Usuario:</Form.Label>
                        <Form.Control type="text" placeholder="ingrese el nombre de usuario dentro del app" id="username"
                            name="username"
                            value={username}
                            onChange={(event) => setUsername(event.target.value)} />
                       
                    </Col>
                    <Col>
                         
                        <Form.Label htmlFor="password">Contraseña:</Form.Label>
                        <Form.Control
                            type="password"
                            id="password"
                            name="password"
                            value={password}
                            onChange={(event) => setPassword(event.target.value)}
                        /></Col>
                    <Col>
                        <Form.Label htmlFor="password-confirm">Confirmar contraseña:</Form.Label>
                        <Form.Control
                            type="password"
                            id="password-confirm"
                            name="password-confirm"
                            value={passwordConfirm}
                            onChange={(event) => setPasswordConfirm(event.target.value)}
                        /></Col>

                </Row>


                <Row>
                    <Col>
                        <button type="submit">Registrarse</button>

                    </Col>
                </Row>


            </Form.Group>



        </Container>
        </div>



    );


}
export default RegisterUser;
