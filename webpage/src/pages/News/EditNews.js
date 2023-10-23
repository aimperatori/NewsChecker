import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { NewsCheckerFetcher } from '../../api/NewsChecker/NewsCheckerFetcher';

function EditNews() {
    const { id } = useParams();

    const [title, setTitle] = useState('');
    const [subtitle, setSubtitle] = useState('');
    const [resume, setResume] = useState('');
    const [editionId, setEditionId] = useState('');

    const [loading, setLoading] = useState(false);

    useEffect(() => {
        NewsCheckerFetcher.GetById('news', id)
            .then(response => response.json())
            .then(data => {
                setTitle(data.title);
                setSubtitle(data.subtitle),
                setResume(data.resume),
                setEditionId(data.edition.id)
            })
            .catch(error => {
                console.error('Erro ao buscar dados:', error);
            });
    }, [id]);

    const titleHandleChange = (e) => {
        setTitle(e.target.value);
    };

    const subtitleHandleChange = (e) => {
        setSubtitle(e.target.value);
    };

    const resumeHandleChange = (e) => {
        setResume(e.target.value);
    };

    const editionIdHandleChange = (e) => {
        setEditionId(e.target.value);
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        setLoading(true);

        const formData = {
            title: title,
            subtitle: subtitle,
            resume: resume,
            editionId: editionId
,        };

        NewsCheckerFetcher.Put("news", id, formData)
            .then((data) => {
                console.log(data);
                setLoading(false);
                // Redirecionar para a página de detalhes ou outra página após a edição
                // this.props.history.push(`/News/details/${id}`);
            })
            .catch((error) => {
                console.error('Erro ao enviar o formulário:', error);
                setLoading(false);
            });
    };

    return (
        <div>
            <h1 id="tableLabel">Editing News id {id}</h1>
            <Form onSubmit={handleSubmit}>

                <Form.Group className="mb-3" controlId="formTitleName">
                    <Form.Label>Title</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Enter news Title"
                        value={title}
                        onChange={titleHandleChange}
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formSubtitle">
                    <Form.Label>Subtitle</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Enter news Subtitle"
                        value={subtitle}
                        onChange={subtitleHandleChange}
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formResume">
                    <Form.Label>Resume</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Enter news Resume"
                        value={resume}
                        onChange={resumeHandleChange}
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formEditionId">
                    <Form.Label>Edition Id</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Enter Edition Id"
                        value={editionId}
                        onChange={editionIdHandleChange}
                    />
                </Form.Group>

                <Button variant="primary" type="submit" disabled={loading}>
                    {loading ? 'Submitting...' : 'Submit'}
                </Button>
            </Form>
        </div>
    );
}

export default EditNews;
