import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { NewsCheckerFetcher } from '../../api/NewsChecker/NewsCheckerFetcher';

function EditNewspaper() {
    const { id } = useParams();

    const [newspaperName, setNewspaperName] = useState('');
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        NewsCheckerFetcher.GetById('Newspaper', id)
            .then(response => response.json())
            .then(data => {
                setNewspaperName(data.name);
            })
            .catch(error => {
                console.error('Erro ao buscar dados do jornal:', error);
            });
    }, [id]);

    const handleChange = (e) => {
        setNewspaperName(e.target.value);
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        setLoading(true);

        const formData = {
            name: newspaperName,
        };

        NewsCheckerFetcher.Put("Newspaper", id, formData)
            .then((data) => {
                console.log(data);
                setLoading(false);
                // Redirecionar para a página de detalhes ou outra página após a edição
                // this.props.history.push(`/newspaper/details/${id}`);
            })
            .catch((error) => {
                console.error('Erro ao enviar o formulário:', error);
                setLoading(false);
            });
    };

    return (
        <div>
            <h1 id="tableLabel">Editing newspaper id {id}</h1>
            <Form onSubmit={handleSubmit}>
                <Form.Group className="mb-3" controlId="formNewspaperName">
                    <Form.Label>Newspaper Name</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Enter newspaper name"
                        value={newspaperName}
                        onChange={handleChange}
                    />
                </Form.Group>

                <Button variant="primary" type="submit" disabled={loading}>
                    {loading ? 'Submitting...' : 'Submit'}
                </Button>
            </Form>
        </div>
    );
}

export default EditNewspaper;
