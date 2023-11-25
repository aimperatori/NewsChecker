import React, { useState, useEffect } from 'react';
import Form from 'react-bootstrap/Form';
import { NewsCheckerFetcher } from '../../../api/NewsChecker/NewsCheckerFetcher';

function JournalistSelect({ value, onChange, createChooseOption }) {
    const [journalists, setJournalist] = useState([]);

    useEffect(() => {
        const fetchJournalists = async () => {
            try {
                const response = await NewsCheckerFetcher.Get('Journalist');
                const data = await response.json();
                setJournalist(data);
            } catch (error) {
                console.error('Error fetching journalists:', error);
            }
        };

        fetchJournalists();
    }, []);

    return (
        <Form.Select
            aria-label="Default select example"
            name="journalist"
            value={value}
            onChange={onChange}
        >
            {createChooseOption == true ? <option value="">Choose a journalist</option> : ''}
            {journalists.map((journalist) => (
                <option key={journalist.id} value={journalist.id}>
                    {journalist.name}
                </option>
            ))}
        </Form.Select>
    );
}

export default JournalistSelect;
