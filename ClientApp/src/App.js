import { Button } from "bootstrap"
import logo from './components/logo.svg';
import './components/App.css';
import { Container, Row, Col, Card, CardHeader } from "reactstrap"
/*import ValidaUsuario from "./components/ValidaUsuario"*/
import { useEffect, useState,React } from "react"
import NavigationBar from './components/NavigationBar';
import { useSession } from 'react-session';




function App() {

    return (

        <div className="App">
            <header className="App-header">
                <img src={logo} className="App-logo" alt="logo" />
                <p>
                    Edit <code>src/App.js</code> and save to reload.
                </p>
                <a
                    className="App-link"
                    href="https://reactjs.org"
                    target="_blank"
                    rel="noopener noreferrer"
                >
                    Learn React
                </a>
            </header>
        </div>
    );
}




export default App;