import { useSession } from 'react-session';

import './styles.css';
import Dropdown from 'react-bootstrap/Dropdown';

const getestado = ({ data }) => 
{
     

        return (
            <Dropdown>
                <Dropdown.Menu show>
                    <Dropdown.Header>Estados</Dropdown.Header>
                    {
                        (data.length < 1) ?
                            (
                                <Dropdown.Item eventKey="0">No hay estados disponibles</Dropdown.Item>

                            ) : (

                                data.map((item) => (
                                    <Dropdown.Item eventKey={item.uuid}>{item.descripcion}</Dropdown.Item>

                                ))
                            )



                    }




                </Dropdown.Menu>

            </Dropdown >
        )
    }
    export default getestado;

