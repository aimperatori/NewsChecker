import React from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import JournalistSelect from './JournalistSelect';

function JournalistSelectAddButton({ journalistIds, onChange, onAddJournalist, createChooseOption }) {    
    return (
        <Form.Group>
            <Form.Label>Journalist</Form.Label>
            {journalistIds.map((id, index) => (
                <JournalistSelect
                    key={id}
                    createChooseOption={createChooseOption}
                    onChange={(e) => onChange(e, index)}
                    value={id} />
            ))}
            <Button variant="primary" onClick={onAddJournalist}>
                Add Journalist
            </Button>
        </Form.Group>
    );
}

export default JournalistSelectAddButton;
