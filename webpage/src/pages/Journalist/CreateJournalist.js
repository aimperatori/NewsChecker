import React, { Component } from 'react';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { NewsCheckerFetcher } from '../../api/NewsChecker/NewsCheckerFetcher';

export class CreateJournalist extends Component {
    //static displayName = CreateJournalist.name;

    constructor(props) {
        super(props);
        this.state = {
            journalistName: '',
            loading: false,
        };
    }

    handleChange = (e) => {
        this.setState({ [e.target.name]: e.target.value });
    };

    handleSubmit = (e) => {
        e.preventDefault();
        this.setState({ loading: true });

        const { journalistName } = this.state;

        // Crie um objeto com os dados que você deseja enviar para a API
        const formData = {
            name: journalistName,
        };

        NewsCheckerFetcher.Post("journalist", formData)
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
                <h1 id="tableLabel">Create a new Journalist</h1>
                <Form onSubmit={this.handleSubmit}>
                    <Form.Group className="mb-3" controlId="formJournalistName">
                        <Form.Label>Journalist Name</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="Enter Journalist name"
                            name="journalistName"
                            value={this.state.journalistName}
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
