import React, { useState, useEffect } from 'react';
import Form from 'react-bootstrap/Form';
import { NewsCheckerFetcher } from '../../../api/NewsChecker/NewsCheckerFetcher';

function EditionSelect({ value, onChange, createChooseOption }) {
    const [editions, setEditions] = useState([]);

    useEffect(() => {
        const fetchEditions = async () => {
            try {
                const response = await NewsCheckerFetcher.Get('edition');
                const data = await response.json();
                setEditions(data);
            } catch (error) {
                console.error('Error fetching editions:', error);
            }
        };

        fetchEditions();
    }, []);

    return (
        <Form.Group className="mb-3" controlId="formEdition">
            <Form.Label>Edition</Form.Label>
            <Form.Select
                aria-label="Default select example"
                name="edition"
                value={value}
                onChange={onChange}
            >
                { createChooseOption == true ? <option value="">Choose an edition</option> : '' }
                {editions.map((edition) => (
                    <option key={edition.id} value={edition.id}>
                        {edition.name + ' - ' + edition.newspapper.name}
                    </option>
                ))}
            </Form.Select>
        </Form.Group>
    );
}

export default EditionSelect;
