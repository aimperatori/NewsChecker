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
    const [newsType, setNewsType] = useState('');
    

    const [loading, setLoading] = useState(false);

    useEffect(() => {
        NewsCheckerFetcher.GetById('news', id)
            .then(response => response.json())
            .then(data => {
                setTitle(data.title);
                setSubtitle(data.subtitle),
                setResume(data.resume),
                setEditionId(data.edition.id),
                setNewsType(data.newsType)
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

    const newsTypeHandleChange = (e) => {
        setNewsType(e.target.value);
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        setLoading(true);

        const formData = {
            title: title,
            subtitle: subtitle,
            resume: resume,
            editionId: editionId,
            newsType: parseInt(newsType)
        };

        console.log(formData);

        NewsCheckerFetcher.Put("news", id, formData)
            .then((data) => {
                console.log(data);
                setLoading(false);
                // Redirecionar para a p�gina de detalhes ou outra p�gina ap�s a edi��o
                // this.props.history.push(`/News/details/${id}`);
            })
            .catch((error) => {
                console.error('Erro ao enviar o formul�rio:', error);
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

                <Form.Group className="mb-3" controlId="formNewsType">
                    <Form.Label>News Type</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Enter news type"
                        value={newsType}
                        onChange={newsTypeHandleChange}
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
