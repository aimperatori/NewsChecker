import React, { Component } from 'react';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { NewsCheckerFetcher } from '../../api/NewsChecker/NewsCheckerFetcher';
import NewsTypeSelect from '../../components/NewsType/Select/NewsTypeSelect';
import EditionSelect from '../../components/Edition/Select/EditionSelect';
import JournalistSelectAddButton from '../../components/Journalist/Select/JournalistSelectAddButton';

export class CreateNews extends Component {

    constructor(props) {
        super(props);
        this.state = {
            title: '',
            subtitle: '',
            resume: '',
            editionId: '',
            newsType: '',
            journalistIds: [''],
            loading: false,
        };
    }

    handleChange = (e) => {
        this.setState({ [e.target.name]: e.target.value });
    };

    handleJournalistIdChange = (e, index) => {
        const journalistIds = [...this.state.journalistIds];
        journalistIds[index] = e.target.value;
        this.setState({ journalistIds });
    };

    handleAddJournalistId = () => {
        const journalistIds = [...this.state.journalistIds];
        journalistIds.push('');
        this.setState({ journalistIds });
    };

    handleSubmit = (e) => {
        e.preventDefault();
        this.setState({ loading: true });

        const { title, subtitle, resume, editionId, journalistIds, newsType } = this.state;

        const formData = {
            title: title,
            subtitle: subtitle,
            resume: resume,
            editionId: editionId,
            newsType: parseInt(newsType),
            journalistsId: journalistIds
        };

        NewsCheckerFetcher.Post("news", formData)
            .then((response) => response.json())
            .then((data) => {
                console.log(data);
                this.setState({ loading: false });
                /*
                journalistIds.map(journalistId => {

                    const formDataJournalistNews = {
                        newsId: data.id,
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
            })
            .catch((error) => {
                console.error('Erro ao enviar o formulário:', error);
                this.setState({ loading: false });
            });
    };

    render() {
        return (
            <div>
                <h1 id="tableLabel">Create a new News</h1>
                <Form onSubmit={this.handleSubmit}>
                    <Form.Group className="mb-3" controlId="formTitle">
                        <Form.Label>Title</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="Enter news title"
                            name="title"
                            value={this.state.title}
                            onChange={this.handleChange}
                        />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formSubtitle">
                        <Form.Label>Subtitle</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="Enter news subtitle"
                            name="subtitle"
                            value={this.state.subtitle}
                            onChange={this.handleChange}
                        />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formResume">
                        <Form.Label>Resume</Form.Label>
                        <Form.Control
                            as="textarea"
                            rows={5}
                            placeholder="Enter news resume"
                            name="resume"
                            value={this.state.resume}
                            onChange={this.handleChange}
                        />
                    </Form.Group>

                    <EditionSelect
                        value={this.state.editionId}
                        onChange={this.handleChange}
                        createChooseOption={true}
                    />

                    <NewsTypeSelect
                        value={this.state.newsType}
                        onChange={this.handleChange}
                    />

                    <JournalistSelectAddButton
                        journalistIds={this.state.journalistIds}
                        createChooseOption={true}
                        onChange={(e, index) => this.handleJournalistIdChange(e, index)}
                        onAddJournalist={this.handleAddJournalistId}
                    />
                    
                    {/*
                    <Form.Group controlId="formJournalistIds">
                        <Form.Label>Journalist</Form.Label>
                        {this.state.journalistIds.map((id, index) => (
                            <JournalistSelect
                                createChooseOption={true}
                                value={id}
                                onChange={(e) => this.handleJournalistIdChange(e, index)}
                                key={index} />
                        ))}
                        <Button variant="primary" onClick={this.handleAddJournalistId}>
                            Add Journalist ID
                        </Button>
                    </Form.Group>
                    */ }

                    <Button variant="primary" type="submit" disabled={this.state.loading}>
                        {this.state.loading ? 'Submitting...' : 'Submit'}
                    </Button>
                </Form>
            </div>
        );
    }
}
