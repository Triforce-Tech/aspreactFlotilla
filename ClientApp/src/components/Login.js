import React, { useState } from 'react';
import './styles.css';
import { Link } from 'react-router-dom';
import Button from 'react-bootstrap/Button';

function Login() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = (event) => {
    event.preventDefault();
    // Aquí podrías enviar los datos del formulario al servidor
  };

  return (
    
    <div className="register-container">
      <h1>Bienvenido Usuario!</h1>
      <form onSubmit={handleSubmit}>
        <label htmlFor="email">Usuario:</label>
        <input
          type="email"
          id="email"
          name="email"
          value={email}
          onChange={(event) => setEmail(event.target.value)} />
        <label htmlFor="password">Contraseña:</label>
        <input
          type="password"
          id="password"
          name="password"
          value={password}
          onChange={(event) => setPassword(event.target.value)} />

        <Button variant="success">Iniciar Sesión</Button>{' '}
        <h2></h2>
        <Button variant="success" as = {Link} to={"/registeruser"}>Registrarse</Button>
      </form>
    </div>
    
  );
}

export default Login;