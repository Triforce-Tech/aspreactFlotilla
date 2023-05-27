import React, { useState, useEffect } from 'react';
import './styles.css';
import { Form, Container, Row, Col, Button } from 'react-bootstrap';
import { useSession } from 'react-session';

function DriverAsignation() {
     
  const [drivername, setDrivername] = useState('');
  const [licensetype, setLicensetype] = useState('');
  const [vehicle, setVehicle] = useState('');
  const [releasedate, setReleasedate] = useState('');
  const [licensestartdate, setLicensestartdate] = useState('');
  const [licenseenddate, setLicenseenddate] = useState('');

  const handleSubmit = (event) => {
    event.preventDefault();
    // Aquí podrías enviar los datos del formulario al servidor
  };

    const [data, setData] = useState([]);
    const [selectedOption, setSelectedOption] = useState('');

    useEffect(() => {
        fetch('/api/vehicle/Lista')
            .then(response => response.json())
            .then(json => setData(json));
    }, []);

    useEffect(() => {
        fetch('/api/licenciasoperador/Lista')
            .then(response => response.json())
            .then(json => setData(json));
    }, []);

    function handleSelectChange(event) {
        setSelectedOption(event.target.value);
    }

  return (
      <div><Container>
      <h1>Registrar Piloto</h1>
      <Form.Group className="mb-3" onSubmit={handleSubmit}>
      <Row>
      <Col>
        <Form.Label htmlFor="drivername">Nombre del Piloto:</Form.Label>
        <Form.Control
          type="text"
          id="drivername"
          name="drivername"
          value={drivername}
          onChange={(event) => setDrivername(event.target.value)}
        />
        </Col>
        <Col>
        <Form.Label htmlFor="licensetype">Tipo de Licencia:</Form.Label>
            <Form.Select value={selectedOption} onChange={(handleSelectChange) => setLicensetype(handleSelectChange.target.value)}>
                <option value="">Seleccione la licencia</option>


                    {
                        (data.length < 1) ?
                            (
                                <option value="">No hay data</option>

                            ) : (
                                data.map(lycensetype=> (
                                    <option key={lycensetype.uuid} value={lycensetype.uuid}>{lycensetype.descripcion}</option>

                                ))
                    )}
            </Form.Select>
        </Col>

        <Col>
        <Form.Label htmlFor="vehicle">Vehiculo:</Form.Label>

            <Form.Select value={selectedOption} onChange={(handleSelectChange) => setVehicle(handleSelectChange.target.value)}>
                  <option value="">Seleccione el vehiculo</option>


                  {
                      (data.length < 1) ?
                          (
                      <option value="">No hay data</option>

                      ) : (
                      data.map(vehicle => (
                    <option key={vehicle.uuid} value={vehicle.uuid}>{vehicle.descripcion}</option>

                  ))
              )}
            </Form.Select>
        </Col>
      </Row>
      <Row>
        <Col>
        <Form.Label htmlFor="releasedate">Fecha de alta:</Form.Label>
        <Form.Control
          type="text"
          id="releasedate"
          name="releasedate"
          value={releasedate}
          onChange={(event) => setReleasedate(event.target.value)}
        />
        </Col>
        <Col>
        <Form.Label htmlFor="licensestartdate">Fecha de emision de la licencia:</Form.Label>
        <Form.Control
          type="text"
          id="licensestartdate"
          name="licensestartdate"
          value={licensestartdate}
          onChange={(event) => setLicensestartdate(event.target.value)}
        />
        </Col>
        <Col>
        <Form.Label htmlFor="licenseenddate">Fecha de caducidad de la licencia:</Form.Label>
        <Form.Control
          type="text"
          id="licenseenddate"
          name="licenseenddate"
          value={licenseenddate}
          onChange={(event) => setLicenseenddate(event.target.value)}
        />
        </Col>
        </Row>
        
        <button type="submit">Registrar</button>
      </Form.Group>
    </Container></div>
  );
}

export default DriverAsignation;