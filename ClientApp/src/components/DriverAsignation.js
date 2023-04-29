import React, { useState } from 'react';
import './styles.css';

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

  return (
    <div className="register-container">
      <h1>Registrar Piloto</h1>
      <form onSubmit={handleSubmit}>
        <label htmlFor="drivername">Nombre del Piloto:</label>
        <input
          type="text"
          id="drivername"
          name="drivername"
          value={drivername}
          onChange={(event) => setDrivername(event.target.value)}
        />
        <label htmlFor="licensetype">Tipo de Licencia:</label>
        <select name ="licensetype">
          <option value={licensetype}>Licencia tipo 1</option>
          <option value={licensetype}>Licencia tipo 2</option>
          <option value={licensetype}>Licencia tipo 3</option>
          onChange={(event) => setLicensetype(event.target.value)}
        </select>
        <label htmlFor="vehicle">Vehiculo:</label>
        <select name ="vehicle">
          <option value={vehicle}>Vehiculo 1</option>
          <option value={vehicle}>Vehiculo 2</option>
          <option value={vehicle}>Vehiculo 3</option>
          onChange={(event) => setVehicle(event.target.value)}
        </select>
        <label htmlFor="releasedate">Fecha de alta:</label>
        <input
          type="text"
          id="releasedate"
          name="releasedate"
          value={releasedate}
          onChange={(event) => setReleasedate(event.target.value)}
        />
        <label htmlFor="licensestartdate">Fecha de emision de la licencia:</label>
        <input
          type="text"
          id="licensestartdate"
          name="licensestartdate"
          value={licensestartdate}
          onChange={(event) => setLicensestartdate(event.target.value)}
        />
        <label htmlFor="licenseenddate">Fecha de caducidad de la licencia:</label>
        <input
          type="text"
          id="licenseenddate"
          name="licenseenddate"
          value={licenseenddate}
          onChange={(event) => setLicenseenddate(event.target.value)}
        />
        
        <button type="submit">Registrar</button>
      </form>
    </div>
  );
}

export default DriverAsignation;