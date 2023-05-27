import 'bootstrap/dist/css/bootstrap.css';
import React from "react";
import ReactDOM from "react-dom/client";
import './components/index.css';
import RegisterUser from './components/RegisterUser';
import Login from './components/Login';
import reportWebVitals from './components/reportWebVitals';
import RegisterVehicle from './components/RegisterVehicle';
import DriverAsignation from './components/DriverAsignation';
import NavigationBar from './components/NavigationBar';
import 'bootstrap/dist/css/bootstrap.min.css';
import MyDatePicker from './components/MyDatePicker';
/*import NavigationBar from "./components/Login";*/
import App from "./App"
import { useSession } from 'react-session';


const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
    <React.StrictMode>
       
        < NavigationBar /> 
    </React.StrictMode>
)

