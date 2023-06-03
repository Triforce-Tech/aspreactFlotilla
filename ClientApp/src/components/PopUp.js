import React from 'react';
import Modal from 'react-modal';

// Configuración global del modal
Modal.setAppElement('#root'); // Especifica el elemento raíz de tu aplicación

const Popup = ({ isOpen, onClose }) => {
    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={onClose}
        >
            <h2>Error</h2>
            <p>Favor comunicarse con su administrador.</p>
            <button onClick={onClose}>Cerrar</button>
        </Modal>
    );
};

export default Popup;