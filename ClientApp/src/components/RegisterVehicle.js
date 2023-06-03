import React, { useState } from 'react';
import { useEffect } from 'react';
import NavigationBar from './NavigationBar';
import Form from 'react-bootstrap/Form';
import ReactDOM from "react-dom/client";
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';
import Button from 'react-bootstrap/Button';
import { useSession } from 'react-session';
import axios from 'axios';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function RegisterVehicle() {
  const [plate, setPlate] = useState('');
  const [descripcion, setDescripcion] = useState('');
  const [km, setKm] = useState('');
  const [brand, setBrand] = useState('');
  const [model, setModel] = useState('');
  const [year, setYear] = useState('');
  const [uuid_tipo_vehiculo, set_uuid_tipo_vehiculo] = useState('');
   function handleSelectChange(event) {
       setSelectedOption(event.target.value);
       axios.post('/api/tipovehiculo/marca', {
           uuid: selectedOption,
           marca: "",
           modelo: "",
           año: Date,
           descripcion: "",
           tipo: "",
           tipo_gasolina: 1,
           tipo_disel: 1,

       })
           .then(response => {
               console.log('Data saved successfully!');
               console.log(response.data.marca);
               console.log(response.data.marca);

               setBrand(response.data[0].marca);
               setModel(response.data[0].modelo);
               setYear(response.data[0].año);
               toast.success('¡Operación exitosa!', {
                   position: toast.POSITION.TOP_CENTER
               });
           })
           .catch(error => {
               console.error('Error saving data:');
               console.error(error);
           });
   }


    

    const [data2, setData2] = useState([]);
    

  const handleSubmit = (event) => {
    event.preventDefault();
    };

    const [selectedOption, setSelectedOption] = useState('');
    const [data, setData] = useState([]);
    function saveVehiculo() {
        

        axios.post('/api/vehiculo/guardaVehiculo', {
            uuid: "",
            placa: plate,
            descripcion: descripcion,
            kilometraje_actual: km,
            uuid_tipo_vehiculo: uuid_tipo_vehiculo,
            
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

    useEffect(() => {
        fetch('/api/tipovehiculo/Lista')
            .then(response => response.json())
            .then(json => setData(json));
    }, []);




  return (
      <div><Container>
      <h1>Registrar Vehiculo</h1>
      <Form.Group className="mb-3" onSubmit={handleSubmit}>
        <Row>
        <Col>
        <Form.Label htmlFor="plate">Placa:</Form.Label>
        <Form.Control
          type="text"
          id="plate"
          name="plate"
          value={plate}
          onChange={(event) => setPlate(event.target.value)}
        />
        </Col>
        <Col>
        <Form.Label htmlFor="descripcion">Descripcion:</Form.Label>
        <Form.Control
          type="text"
          id="descripcion"
          name="descripcion"
          value={descripcion}
          onChange={(event) => setDescripcion(event.target.value)}
        />
        </Col>
        <Col>
        <Form.Label htmlFor="km">Kilometraje Actual:</Form.Label>
        <Form.Control
          type="text"
          id="km"
          name="km"
          value={km}
          onChange={(event) => setKm(event.target.value)}
        />
        </Col>
        </Row>

        <Row>
        <Col>
        <Form.Label htmlFor="brand">Marca:</Form.Label>
        <Form.Control
          type="text"
          id="brand"
          name="brand"
          value={brand}
          onChange={(event) => setBrand(event.target.value)}
        />
        </Col>
        <Col>
        <Form.Label htmlFor="model">Modelo:</Form.Label>
        <Form.Control
          type="text"
          id="model"
          name="model"
          value={model}
          onChange={(event) => setModel(event.target.value)}
        />
        </Col>
        <Col>
        <Form.Label htmlFor="year">Año:</Form.Label>
        <Form.Control
          type="text"
          id="year"
          name="year"
          value={year}
          onChange={(event) => setYear(event.target.value)}
        />
        </Col>
              </Row>
              <Row>
                  <Form.Group className="mb-3">

                      <div>
                          <Form.Label htmlFor="disabledSelect">Tipo de Vehiculo:</Form.Label>
                          <Form.Select type="UUID" id="UUID" name="UUID" value={selectedOption.uuid} onChange={(handleSelectChange)}>
                              <option value="">Seleccione el Tipo</option>
                              {data.map(user => (
                                  <option key={user.uuid} value={user.uuid}>{user.descripcion}</option>
                              ))}
                          </Form.Select>
                      </div>
                  </Form.Group>
              </Row>
              <Row>
              <Col>
                      <Button className='w-100 mb-4' size='md' variant="success"  to={"/registeruser"}>Registrarse</Button>
              
              </Col>
                  <Col>

                      <Button className='w-100 mb-4' size='md' variant="success"  to={"/registeruser"}>Actualizar</Button>
                  </Col>
                  <Col>

                      <Button className='w-100 mb-4' size='md' variant="success" to={"/registeruser"}>Eliminar</Button>
                  </Col>
              </Row>
       </Form.Group>
      </Container>
      </div>
  );
}

export default RegisterVehicle;