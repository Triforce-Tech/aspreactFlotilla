import React from 'react';
import { GoogleMap, Marker, LoadScript } from '@react-google-maps/api';

const containerStyle = {
    width: '400px',
    height: '400px',
};

const center = {
    lat: 37.7749,
    lng: -122.4194,
};

const Map = (props) => {
    return (
        <LoadScript googleMapsApiKey="AIzaSyAIw8ETxdDdM0zwzUZLR2PPcGOii_Rvyp0">
            <GoogleMap mapContainerStyle={containerStyle} center={center} zoom={10}>
                <Marker position={center} />
            </GoogleMap>
        </LoadScript>
    );
};

export default Map;
