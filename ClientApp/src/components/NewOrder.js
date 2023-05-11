import React, { useState, useEffect } from 'react';
import { Form, FormGroup, FormControl, Button } from 'react-bootstrap';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import MyDatePicker from './MyDatePicker';
import Container from 'react-bootstrap/Container';
import DatePicker from 'react-datepicker';
import Card from 'react-bootstrap/Card';
import Nav from 'react-bootstrap/Nav';
import {
    BrowserRouter as Router,
    Link,
    Routes,
    Route,
} from "react-router-dom";
import FillDetails from './FillDetails';
import RegisterUser from './RegisterUser';


function NewOrder() {
    var caso;

    return (

        <Container>
        <h1>Nueva Orden</h1>
        <Card>
                <Card.Header>
                    <Nav variant="tabs" defaultActiveKey="#first">
                        <Nav.Item>
                            <Nav.Link href="#first">Active</Nav.Link>
                        </Nav.Item>
                        <Nav.Item>
                            <Nav.Link href="#link">Link</Nav.Link>
                        </Nav.Item>
                        <Nav.Item>
                            <Nav.Link href="#disabled" disabled>
                                Disabled
                            </Nav.Link>
                        </Nav.Item>
                    </Nav>
                </Card.Header>
                <Card.Body>

                    <FillDetails />
                                 
                </Card.Body>

                
                 
        </Card>
        </Container>
        
    );
}

export default NewOrder;