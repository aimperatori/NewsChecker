import React, { Component } from 'react';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { NewsCheckerFetcher } from '../../api/NewsChecker/NewsCheckerFetcher';

export class CreateEdition extends Component {
   
    constructor(props) {
        super(props);
        this.state = {
            editionName: '',
            publishDate: '',
            loading: false,
        };
    }

    handleChange = (e) => {
        this.setState({ [e.target.name]: e.target.value });
    };

    handleSubmit = (e) => {
        e.preventDefault();
        this.setState({ loading: true });

        const { editionName, publishDate, newspaperId } = this.state;

        const formData = {
            name: editionName,
            publishDate: publishDate,
            NewspaperId: newspaperId
        };

        NewsCheckerFetcher.Post("edition", formData)
            .then((response) => response.json())
                .then((data) => {
                    console.log(data);
                    this.setState({ loading: false });
                })
                .catch((error) => {
                    console.error('Erro ao enviar o formulário:', error);
                    this.setState({ loading: false });
                });
    };

    render() {
        return (
            <div>
                <h1 id="tableLabel">Create a new Edition</h1>
                <Form onSubmit={this.handleSubmit}>
                    <Form.Group className="mb-3" controlId="formEditionName">
                        <Form.Label>Edition Name</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="Enter edition name"
                            name="editionName"
                            value={this.state.editionName}
                            onChange={this.handleChange}
                        />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formEditionPublishDate">
                        <Form.Label>Publish Date</Form.Label>
                        <Form.Control
                            type="date"
                            placeholder="Enter publish date"
                            name="publishDate"
                            value={this.state.publishDate}
                            onChange={this.handleChange}
                        />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formEditionNewspaperId">
                        <Form.Label>Newspaper</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="newspaper"
                            name="newspaperId"
                            value={this.state.NewspaperId}
                            onChange={this.handleChange}
                        />
                    </Form.Group>


                    <Button variant="primary" type="submit" disabled={this.state.loading}>
                        {this.state.loading ? 'Submitting...' : 'Submit'}
                    </Button>
                </Form>
            </div>
        );
    }
}
