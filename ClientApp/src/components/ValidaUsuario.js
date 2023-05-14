import { useSession } from 'react-session';
import { Button, Table } from "reactstrap"

const ValidaUsuario = ({ data }) => {

     

    return (

        <Table striped responsive>
            <thead>
                <tr>
                    <th>UUID</th>
                    <th>USUARIO</th>
                    <th></th>
                </tr>

            </thead>
            <tbody>
                {
                    (data.length < 1) ?
                        (
                            <tr>
                                <td colSpam="4">Sin registros</td>
                            </tr>

                        ) : (

                            data.map((item) => (

                                <tr key={item.uuiD_USER_SESSION}>
                                    <td>{item.uuiD_USER_SESSION}</td>
                                    <td>{item.usuario}</td>
                                   
                                    <td>
                                        <Button color="primary" size="sm" className="me-2">Editar</Button>
                                        <Button color="danger" size="sm">Eliminar</Button>
                                    </td>
                                </tr>

                            ))
                        )



                }
            </tbody>
        </Table>

    )
}
export default ValidaUsuario;