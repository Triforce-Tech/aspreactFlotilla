import React, { useState, useEffect } from 'react';
import Container from 'react-bootstrap/Container';
import Map from './Map'

function ShipFrom() {

    <div>

        <h1>Mapa de Google</h1>
        <Map
            containerElement={<div style={{ height: '400px' }} />}
            mapElement={<div style={{ height: '100%' }} />}
            loadingElement={<p>Cargando</p> }
        />

    </div>

}

export default ShipFrom;