import React, { useState, useEffect } from 'react';
import Container from 'react-bootstrap/Container';
import Map from './Map'
import { useSession } from 'react-session';

function ShipTo() {

     

    return (
        <Container>

            <h1>Mapa de Google</h1>
            <Map />

        </Container>
    )
}

export default ShipTo;