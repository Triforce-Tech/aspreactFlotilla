import React, { useState } from 'react';
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import NewOrder from './NewOrder';
import {
    BrowserRouter as Router,
    Link,
    Routes,
    Route,
  } from "react-router-dom";

function ViewOrder() {
  

  return (
    <>
      <h1>Ver Orden</h1>
      <Table striped bordered hover size="sm">
      <thead>
        <tr>
          <th>#</th>
          <th>First Name</th>
          <th>Last Name</th>
          <th>Username</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td><a href="#">1</a></td>
          <td>Mark</td>
          <td>Otto</td>
          <td>@mdo</td>
        </tr>
        <tr>
          <td>2</td>
          <td>Jacob</td>
          <td>Thornton</td>
          <td>@fat</td>
        </tr>
        <tr>
          <td>3</td>
          <td colSpan={2}>Larry the Bird</td>
          <td>@twitter</td>
        </tr>
      </tbody>
    </Table>
    <Button variant="primary" as = {Link} to={"/neworder"}>Nueva Orden</Button>{' '}
    </>
  );
}

export default ViewOrder;