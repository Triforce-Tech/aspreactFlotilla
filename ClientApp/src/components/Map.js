import React from 'react';
import { GoogleMap, Marker, LoadScript } from '@react-google-maps/api';

const containerStyle = {
    width: '1000px',
    height: '400px',
};



const center = {
    lat: 14.5040362873799,
    lng: -90.61560837309347,
};

const MapComponent = () => {
    return (
        <LoadScript googleMapsApiKey="AIzaSyAIw8ETxdDdM0zwzUZLR2PPcGOii_Rvyp0">
            <GoogleMap mapContainerStyle={containerStyle} center={center} zoom={15}>
                <Marker position={center} />
            </GoogleMap>
        </LoadScript>
    );
};

export default MapComponent;
