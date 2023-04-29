import React, { useState } from 'react';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';

function MyDatePicker() {
    const [selectedDate, setSelectedDate] = useState(null);

    return (
        <DatePicker
            selected={selectedDate}
            onChange={date => setSelectedDate(date)}
            dateFormat="dd-MM-yyyy"
            placeholderText="Seleccione una fecha"
        />
    );
}

export default MyDatePicker;
