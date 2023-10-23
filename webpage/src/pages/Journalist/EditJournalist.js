import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { NewsCheckerFetcher } from '../../api/NewsChecker/NewsCheckerFetcher';

function EditJournalist() {
    const { id } = useParams();

    const [journalistName, setJournalistName] = useState('');

    const [loading, setLoading] = useState(false);

    useEffect(() => {
        NewsCheckerFetcher.GetById('journalist', id)
            .then(response => response.json())
            .then(data => {
                setJournalistName(data.name);
            })
            .catch(error => {
                console.error('Erro ao buscar dados do jornal:', error);
            });
    }, [id]);

    const journalistNameHandleChange = (e) => {
        setJournalistName(e.target.value);
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        setLoading(true);

        const formData = {
            name: journalistName,
        };

        NewsCheckerFetcher.Put("journalist", id, formData)
            .then((data) => {
                console.log(data);
                setLoading(false);
                // Redirecionar para a página de detalhes ou outra página após a edição
                // this.props.history.push(`/Journalist/details/${id}`);
            })
            .catch((error) => {
                console.error('Erro ao enviar o formulário:', error);
                setLoading(false);
            });
    };

    return (
        <div>
            <h1 id="tableLabel">Editing Journalist id {id}</h1>
            <Form onSubmit={handleSubmit}>
                <Form.Group className="mb-3" controlId="formJournalistName">
                    <Form.Label>Journalist Name</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Enter Journalist name"
                        value={journalistName}
                        onChange={journalistNameHandleChange}
                    />
                </Form.Group>

                <Button variant="primary" type="submit" disabled={loading}>
                    {loading ? 'Submitting...' : 'Submit'}
                </Button>
            </Form>
        </div>
    );
}

export default EditJournalist;
