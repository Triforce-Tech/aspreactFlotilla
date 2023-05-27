/*import logo from './logo.svg';*/
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
    
    const [selectedOption, setSelectedOption] = useState('');
    const [data, setData] = useState([]);

    useEffect(() => {
        fetch('/api/usuario/Tipousuario')
            .then(response => response.json())
            .then(json => setData(json));
    }, []);

    function handleSelectChange(event) {
        setSelectedOption(event.target.value);
    }
  


        function handleSaveClick() {
            //console.log(`Saving ${field1} and ${field2}`);
            saveusuario();
         
            // Hacer una solicitud HTTP para guardar los datos
           
    }

    function savepersona() {
        const fechaEspecifica = new Date('2022-05-01T12:00:00Z');

        axios.post('/api/persona/Guardarper', {
            uuid: "",
            primer_nombre: PRIMER_NOMBRE,
            segundo_nombre: SEGUNDO_NOMBRE,
            tercer_nombre: "",
            primer_apellido: PRIMER_APELLIDO,
            segundo_apellido: SEGUNDO_APELLIDO,
            dpi: DPI,
            direccion: address,
            telefono: phonenumber,
            correo: email,
            empresa: company,
            fecha_ingreso: fechaEspecifica,
            fecha_modificacion: fechaEspecifica,
            uuid_estado: "",
            uuid_tipo_usuario: selectedOption,
            uuid_user_session: "",
            user_name: username,

        })
            .then(response => {
                console.log('Data saved successfully!');
                console.log(response.data);
                toast.success('¡Operación exitosa!', {
                    position: toast.POSITION.TOP_CENTER
                });
            })
            .catch(error => {
                console.error('Error saving data:');
                console.error(error);
            });
    }

    function saveusuario() {

       

         axios.post('/api/usuario/Guardarusuario', {
                uuid: "",
                usuario: username,
                password: password,
                UUID_ESTADO: ""

            })
            
                .then(response => {
                    console.log('Data saved successfully!');
                    console.log(response.data);
                    savepersona();
                    toast.success('¡Operación exitosa!', {
                        position: toast.POSITION.TOP_CENTER
                    });
                })
                .catch(error => {
                    console.error('Error saving data:');
                    console.error(error);
                });
    }
    const [show, setShow] = useState(false);
   
    
   
    

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
                    <Col>  <Form.Label htmlFor="DPI">DPI:</Form.Label>
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

                        <>
                            <Alert show={show}  variant="success">
                                <Alert.Heading>Success!</Alert.Heading>
                                <p>
                                    
                                </p>
                                <hr />
                                <div className="d-flex justify-content-end">
                                    <button onClick={() => setShow(false)} variant="outline-success">
                                        Close me y'all!
                                    </button>
                                </div>
                            </Alert>

                            {!show && <Button onClick={() => setShow(true)} onClick={handleSaveClick}>Registrarse</Button>}
                        </>



                        {/*<button  type="submit" onClick={handleSaveClick}>Registrarse</button>*/}

                    </Col>
                </Row>


            </Form.Group>



        </Container>
        </div>



    );


}
export default RegisterUser;
