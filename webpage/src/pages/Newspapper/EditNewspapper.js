import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { NewsCheckerFetcher } from '../../api/NewsChecker/NewsCheckerFetcher';

function EditNewspapper() {
    const { id } = useParams();

    const [newspapperName, setNewspapperName] = useState('');
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        NewsCheckerFetcher.Get('Newspaper', id)
            .then(response => response.json())
            .then(data => {
                setNewspapperName(data.name);
            })
            .catch(error => {
                console.error('Erro ao buscar dados do jornal:', error);
            });
    }, [id]);

    const handleChange = (e) => {
        setNewspapperName(e.target.value);
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        setLoading(true);

        const formData = {
            name: newspapperName,
        };

        NewsCheckerFetcher.Put("Newspaper", id, formData)
            .then((data) => {
                console.log(data);
                setLoading(false);
                // Redirecionar para a página de detalhes ou outra página após a edição
                // this.props.history.push(`/newspapper/details/${id}`);
            })
            .catch((error) => {
                console.error('Erro ao enviar o formulário:', error);
                setLoading(false);
            });
    };

    return (
        <div>
            <h1 id="tableLabel">Editing newspapper id {id}</h1>
            <Form onSubmit={handleSubmit}>
                <Form.Group className="mb-3" controlId="formNewspapperName">
                    <Form.Label>Newspapper Name</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Enter newspapper name"
                        value={newspapperName}
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

export default EditNewspapper;
