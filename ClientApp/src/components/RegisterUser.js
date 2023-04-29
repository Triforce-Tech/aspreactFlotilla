/*import logo from './logo.svg';*/
import React, { useState } from 'react';
import './styles.css';
import NavigationBar from './NavigationBar';

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

  return (
    <div className="register-container">
      
      <h1>Registrarse</h1>
      <form onSubmit={handleSubmit}>
        <label htmlFor="username">Nombre Usuario:</label>
        <input
          type="text"
          id="username"
          name="username"
          value={username}
          onChange={(event) => setUsername(event.target.value)}
        />
        <label htmlFor="username">Apellido Usuario:</label>
        <input
          type="text"
          id="userlastname"
          name="userlastname"
          value={userlastname}
          onChange={(event) => setUserlastname(event.target.value)}
        />
        <label htmlFor="dpi">DPI:</label>
        <input
          type="text"
          id="dpi"
          name="dpi"
          value={dpi}
          onChange={(event) => setDpi(event.target.value)}
        />
        <label htmlFor="address">Dirección:</label>
        <input
          type="text"
          id="address"
          name="address"
          value={address}
          onChange={(event) => setAddress(event.target.value)}
        />
        <label htmlFor="phonenumber">No. Teléfono:</label>
        <input
          type="text"
          id="phonenumber"
          name="phonenumber"
          value={phonenumber}
          onChange={(event) => setPhonenumber(event.target.value)}
        />
        <label htmlFor="company">Empresa:</label>
        <input
          type="text"
          id="company"
          name="company"
          value={company}
          onChange={(event) => setCompany(event.target.value)}
        />
        <label htmlFor="email">Correo electrónico:</label>
        <input
          type="email"
          id="email"
          name="email"
          value={email}
          onChange={(event) => setEmail(event.target.value)}
        />
        <label htmlFor="password">Contraseña:</label>
        <input
          type="password"
          id="password"
          name="password"
          value={password}
          onChange={(event) => setPassword(event.target.value)}
        />
        <label htmlFor="password-confirm">Confirmar contraseña:</label>
        <input
          type="password"
          id="password-confirm"
          name="password-confirm"
          value={passwordConfirm}
          onChange={(event) => setPasswordConfirm(event.target.value)}
        />
        <label htmlFor="usertype">Tipo de Usuario:</label>
        <select name ="usertype">
          <option value="client">Cliente</option>
          <option value="operator">Operador</option>
          onChange={(event) => setUserType(event.target.value)}
        </select>
        <button type="submit">Registrarse</button>
      </form>
    </div>
  );
}

export default RegisterUser;
