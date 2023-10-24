import React, { useState } from 'react';
import Button from 'react-bootstrap/Button';
import { useNavigate } from 'react-router-dom';

function ConfirmDelete({ handleDelete, titulo, mensagem }) {
    const navigate = useNavigate();
    const [loading, setLoading] = useState(false);

    const handleBack = () => {
        navigate(-1);
    };

    return (
        <div>
            <h1>{titulo}</h1>
            <p>{mensagem}</p>
            <Button variant="secondary" onClick={handleBack}>
                Cancel
            </Button>
            <Button variant="danger" onClick={handleDelete} disabled={loading}>
                {loading ? 'Deleting...' : 'Yes, I am'}
            </Button>
        </div>
    );
}

export default ConfirmDelete;
