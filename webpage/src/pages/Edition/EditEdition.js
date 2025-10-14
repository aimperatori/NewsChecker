import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { NewsCheckerFetcher } from '../../api/NewsChecker/NewsCheckerFetcher';

function EditEdition() {
    const { id } = useParams();

    const [editionName, setEditionName] = useState('');
    const [publishDate, setPublishDate] = useState('');
    const [newspaperId, setNewspaperId] = useState('');

    const [loading, setLoading] = useState(false);

    useEffect(() => {
        NewsCheckerFetcher.GetById('edition', id)
            .then(response => response.json())
            .then(data => {
                setEditionName(data.name);
                setPublishDate(data.publishDate);
                setNewspaperId(data.newspaper.id);
            })
            .catch(error => {
                console.error('Erro ao buscar dados do jornal:', error);
            });
    }, [id]);

    const editionNameHandleChange = (e) => {
        setEditionName(e.target.value);
    };

    const publishDateHandleChange = (e) => {
        setPublishDate(e.target.value);
    };

    const newspaperIdHandleChange = (e) => {
        setNewspaperId(e.target.value);
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        setLoading(true);

        const formData = {
            name: editionName,
            publishDate: publishDate,
            NewspaperId: newspaperId
        };

        NewsCheckerFetcher.Put("edition", id, formData)
            .then((data) => {
                console.log(data);
                setLoading(false);
                // Redirecionar para a p�gina de detalhes ou outra p�gina ap�s a edi��o
                // this.props.history.push(`/Edition/details/${id}`);
            })
            .catch((error) => {
                console.error('Erro ao enviar o formul�rio:', error);
                setLoading(false);
            });
    };

    return (
        <div>
            <h1 id="tableLabel">Editing Edition id {id}</h1>
            <Form onSubmit={handleSubmit}>
                <Form.Group className="mb-3" controlId="formEditionName">
                    <Form.Label>Edition Name</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Enter Edition name"
                        value={editionName}
                        onChange={editionNameHandleChange}
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formPublishDate">
                    <Form.Label>Publish date</Form.Label>
                    <Form.Control
                        type="date"
                        placeholder="Enter publising date"
                        value={publishDate}
                        onChange={publishDateHandleChange}
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formNewspaperId">
                    <Form.Label>Newspaper Id</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Enter Newspaper Id"
                        value={newspaperId}
                        onChange={newspaperIdHandleChange}
                    />
                </Form.Group>

                <Button variant="primary" type="submit" disabled={loading}>
                    {loading ? 'Submitting...' : 'Submit'}
                </Button>
            </Form>
        </div>
    );
}

export default EditEdition;
