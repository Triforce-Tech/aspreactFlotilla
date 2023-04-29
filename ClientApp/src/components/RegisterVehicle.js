import React, { useState } from 'react';
import './styles.css';

function RegisterVehicle() {
  const [plate, setPlate] = useState('');
  const [descripcion, setDescripcion] = useState('');
  const [km, setKm] = useState('');
  const [brand, setBrand] = useState('');
  const [model, setModel] = useState('');
  const [year, setYear] = useState('');

  const handleSubmit = (event) => {
    event.preventDefault();
    // Aquí podrías enviar los datos del formulario al servidor
  };

  return (
    <div className="register-container">
      <h1>Registrar Vehiculo</h1>
      <form onSubmit={handleSubmit}>
        <label htmlFor="plate">Placa:</label>
        <input
          type="text"
          id="plate"
          name="plate"
          value={plate}
          onChange={(event) => setPlate(event.target.value)}
        />
        <label htmlFor="descripcion">Descripcion:</label>
        <input
          type="text"
          id="descripcion"
          name="descripcion"
          value={descripcion}
          onChange={(event) => setDescripcion(event.target.value)}
        />
        <label htmlFor="km">Kilometraje Actual:</label>
        <input
          type="text"
          id="km"
          name="km"
          value={km}
          onChange={(event) => setKm(event.target.value)}
        />
        <label htmlFor="brand">Marca:</label>
        <input
          type="text"
          id="brand"
          name="brand"
          value={brand}
          onChange={(event) => setBrand(event.target.value)}
        />
        <label htmlFor="model">Modelo:</label>
        <input
          type="text"
          id="model"
          name="model"
          value={model}
          onChange={(event) => setModel(event.target.value)}
        />
        <label htmlFor="year">Año:</label>
        <input
          type="text"
          id="year"
          name="year"
          value={year}
          onChange={(event) => setYear(event.target.value)}
        />
        
        <button type="submit">Registrar</button>
      </form>
    </div>
  );
}

export default RegisterVehicle;