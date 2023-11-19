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
    const [journalistIds, setJournalistsId] = useState(['']);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        NewsCheckerFetcher.GetById('news', id)
            .then(response => response.json())
            .then(data => {
                setTitle(data.title);
                setSubtitle(data.subtitle),
                setResume(data.resume),
                setEditionId(data.edition.id),
                setNewsType(data.newsType),
                setJournalistsId(data.journalist.map(j => j.id))
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

    const handleJournalistIdChange = (e, index) => {
        const journalists = [...journalistIds];
        journalists[index] = e.target.value;
        setJournalistsId(journalists);
    };

    const handleAddJournalistId = () => {
        const journalists = [...journalistIds];
        journalists.push('');
        setJournalistsId(journalists);
    };

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

                NewsCheckerFetcher.GetById("news", id)
                    .then(response => response.json())
                    .then(data => {
                        console.log(data);

                        journalistIds.forEach(function (e) {
                            // CREATE
                            if (!data.journalist.some(item => item.id == e)) {

                                const formDataJournalistNews = {
                                    newsId: id,
                                    journalistId: e
                                };

                                NewsCheckerFetcher.Post("JournalistNews", formDataJournalistNews)
                                    .then((response) => response.json())
                                    .then((data) => {
                                        console.log(data);
                                    })
                                    .catch((error) => {
                                        console.error('Erro ao enviar o formulário:', error);
                                        setState({ loading: false });
                                    });
                            }
                        })

                        data.journalist.forEach(function (e) {
                            // DELETE
                            if (!journalistIds.some(item => item.id == e.id)) {

                                NewsCheckerFetcher.Delete2("JournalistNews", e.id, id)
                                    .then((response) => response.json())
                                    .then((data) => {
                                        console.log(data);
                                    })
                                    .catch((error) => {
                                        console.error('Erro ao enviar o formulário:', error);
                                        setState({ loading: false });
                                    });
                            }
                        })
                        

                    });


                /*
                journalistIds.map(journalistId => {

                    const formDataJournalistNews = {
                        newsId: id,
                        journalistId: journalistId
                    };

                    NewsCheckerFetcher.Post("JournalistNews", formDataJournalistNews)
                        .then((response) => response.json())
                        .then((data) => {
                            console.log(data);
                            this.setState({ loading: false });
                        })
                        .catch((error) => {
                            console.error('Erro ao enviar o formulário:', error);
                            this.setState({ loading: false });
                        });
                });
                */


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

                <Form.Group className="mb-3" controlId="formNewsType">
                    <Form.Label>News Type</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Enter news type"
                        value={newsType}
                        onChange={newsTypeHandleChange}
                    />
                </Form.Group>

                <Form.Group controlId="formJournalistIds">
                    <Form.Label>Journalist</Form.Label>
                    {journalistIds.map((id, index) => (
                        <Form.Control
                            type="text"
                            placeholder="Enter journalist ID"
                            value={id}
                            onChange={(e) => handleJournalistIdChange(e, index)}
                            key={index}
                        />
                    ))}
                    <Button variant="primary" onClick={handleAddJournalistId}>
                        Add Journalist ID
                    </Button>
                </Form.Group>

                <Button variant="primary" type="submit" disabled={loading}>
                    {loading ? 'Submitting...' : 'Submit'}
                </Button>
            </Form>
        </div>
    );
}

export default EditNews;
