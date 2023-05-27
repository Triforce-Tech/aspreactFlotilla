import { Container } from 'react-bootstrap';
import { Nav, Navbar, NavDropdown } from 'react-bootstrap';
import { useSession } from 'react-session';

//import Navbar from 'react-bootstrap/Navbar';
import RegisterVehicle from './RegisterVehicle';
//import NavDropdown from 'react-bootstrap/NavDropdown';
import {
    BrowserRouter as Router,
    Link,
    Routes,
    Route,
} from "react-router-dom";
import Login from './Login';
import DriverAsignation from './DriverAsignation';
import RegisterUser from './RegisterUser';
import NewOrder from './NewOrder';
import ViewOrder from './ViewOrder';
import DashboardInicio from './DashboardInicio';
import * as React from 'react';
import Home from './Home';
import FillDetails from './FillDetails';
import { useEffect, useState } from 'react';
import axios from 'axios';





function NavigationBar() {
 
    const [data, setData] = useState([null]);

    useEffect(() => {
        fetch('/api/session/consultasession')
            .then(response => response.json())
            .then(json => setData(json));
    }, []);
    var mostrarContenido = false;

    if (data.length === 2) {
        mostrarContenido = true;
    }
        return (


            <Router>
                <>
                    { mostrarContenido ? (
                     
                    <Navbar bg="dark" variant="dark">
                        <Container>
                            <Navbar.Brand as={Link} to={"/home"}>Logistics</Navbar.Brand>
                            <Nav className="justify-content-end">
                                <Nav.Link as={Link} to={"/home"}>Home</Nav.Link>
                                <Nav.Link as={Link} to={"/registervehicle"}>Vehiculos</Nav.Link>
                                <Nav.Link as={Link} to={"/driverasignation"}>Pilotos</Nav.Link>
                                <NavDropdown title="Ordenes" id="basic-nav-dropdown">
                                    <NavDropdown.Item as={Link} to={"/neworder"}>Nueva Orden</NavDropdown.Item>
                                    <NavDropdown.Item as={Link} to={"/vieworder"}>Ver Ordenes</NavDropdown.Item>
                                </NavDropdown>
                                <Nav.Link href="">Cerrar Sesión</Nav.Link>
                            </Nav>
                        </Container>
                    </Navbar>  
                    ) : (

                            <p></p>
                    )
                    }
                </>
                <>
                    <Routes>
                        <Route path='/' element={<Login />} name="Login" >
                        </Route>
                        <Route path='/home' element={<Home />}>
                        </Route>
                        <Route path='/registervehicle' element={<RegisterVehicle />}>
                        </Route>
                        <Route path='/driverasignation' element={<DriverAsignation />}>
                        </Route>
                        <Route path='/neworder' element={<NewOrder />}>
                        </Route>
                        <Route path='/vieworder' element={<ViewOrder />}>
                        </Route>
                        <Route path='/registeruser' element={<RegisterUser />}>
                        </Route>
                        <Route path='/home' ></Route>
                    </Routes>
                </>
            </Router>
        );
    }
export default NavigationBar;
