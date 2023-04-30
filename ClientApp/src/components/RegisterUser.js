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




function RegisterUser() {
    const [username, setUsername] = useState('');
    const [userlastname, setUserlastname] = useState('');
    const [dpi, setDpi] = useState('');
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
        fetch('/api/usuario/TipoUsuario')
            .then(response => response.json())
            .then(json => setData(json));
    }, []);

    function handleSelectChange(event) {
        setSelectedOption(event.target.value);
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
                            id="dpi"
                            name="dpi"
                            value={dpi}
                            onChange={(event) => setDpi(event.target.value)}
                        />
                    </Col>
                    <Col>
                        <Form.Label htmlFor="SEGUNDO_NOMBRE">SEGUNDO_NOMBRE:</Form.Label>
                        <Form.Control
                            type="text"
                            id="dpi"
                            name="dpi"
                            value={dpi}
                            onChange={(event) => setDpi(event.target.value)}
                        />
                    </Col>
                    <Col>
                        <Form.Label htmlFor="PRIMER_APELLIDO">PRIMER_APELLIDO:</Form.Label>
                        <Form.Control
                            type="text"
                            id="dpi"
                            name="dpi"
                            value={dpi}
                            onChange={(event) => setDpi(event.target.value)}
                        />
                    </Col>

                    <Col>
                        <Form.Label htmlFor="SEGUNDO_APELLIDO">SEGUNDO_APELLIDO:</Form.Label>
                        <Form.Control
                            type="text"
                            id="dpi"
                            name="dpi"
                            value={dpi}
                            onChange={(event) => setDpi(event.target.value)}
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
                            type="email"
                            id="email"
                            name="email"
                            value={email}
                            onChange={(event) => setEmail(event.target.value)}
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
                                    <Form.Select value={selectedOption} onChange={(handleSelectChange) => setUserType(handleSelectChange.target.value)}>
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

                <br></br>

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
