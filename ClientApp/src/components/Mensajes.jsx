import React, { useState } from 'react';

const Modal = ({ value }) => {
    const [showModal, setShowModal] = useState(false);

    const openModal = () => {
        setShowModal(true);
    };

    const closeModal = () => {
        setShowModal(false);
    };

    return (
        <div>
            <button onClick={openModal}>Abrir modal</button>

            {showModal && (
                <div className="modal">
                    <div className="modal-content">
                        <span className="close" onClick={closeModal}>
                            &times;
                        </span>
                        {value === 1 ? (
                            <>
                                <h2>Accion realizada correctamente</h2>
                                <p></p>
                            </>
                        ) : value === 0 ? (
                            <>
                                <h2>Accion no realizada </h2>
                                <p></p>
                            </>
                        ) : null}
                    </div>
                </div>
            )}
        </div>
    );
};

export default Modal;
