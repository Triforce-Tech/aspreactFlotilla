import { Button } from "bootstrap"
import { Container, Row, Col, Card, CardHeader } from "reactstrap"
import ValidaUsuario from "./components/ValidaUsuario"
import { useEffect, useState,React } from "react"


const App = () => {
    
    const [usersession, setUsers] = useState([]);

    const mostrarUsuarios = async () => {

        const response = await fetch("api/login/Lista")
        if (response.ok) {
            const data = await response.json();
            setUsers(data)
        } else {
            console.log("Error en el login no tiene data")
        }
    }
    
    useEffect(() => {
        mostrarUsuarios()
    },[])


    return (
        <Container>
            <Row clasName="mt-5">
                <Col sm="12">


                    <div class="card">
                        <div class="card-header">
                            Flotilla Net
                        </div>
                        <div class="card-body">
                            <h5 class="card-title">desea iniciar sesion ?</h5>
                            <p class="card-text">Haz click sobre el boton iniciar sesion</p>

                            <ValidaUsuario data={usersession} />
                          

                            <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
                                Iniciar session
                            </button>
                        </div>
                    </div>


              
                    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabel">Inicio de sesion</h5>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">

                                    <div class="container">
                                        <div class="row">
                                            <div class="col">
                                                <div class="row">
                                                    <div class="col">
                                                        <input type="text" class="form-control" placeholder="Usuario" aria-label="Usuario" />
                                                    </div>
                                                    <div class="col">
                                                        <input type="text" class="form-control" placeholder="Contraseña" aria-label="Contraseña" />
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>




                                </div>
                                <div class="modal-footer">
                                   





                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </Col>
            </Row>
        </Container>
    )
}
export default App;