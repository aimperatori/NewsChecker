import React from 'react';
import Form from 'react-bootstrap/Form';
import NewsTypes from '../Data/NewsTypes';

function NewsTypeSelect({ value, onChange }) {
    return (
        <Form.Group className="mb-3" controlId="formNewsType">
            <Form.Label>News type</Form.Label>
            <Form.Select
                aria-label="Default select example"
                name="newsType"
                value={value}
                onChange={onChange}
            >
                {Object.entries(NewsTypes).map(([key, newsType]) => (
                <option key={key} value={key}>
                    {newsType}
                </option>
                ))}
            </Form.Select>
        </Form.Group>
    );
}

export default NewsTypeSelect;
