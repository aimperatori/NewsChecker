import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import Button from 'react-bootstrap/Button';

export class ListAbstract extends Component {

    constructor(props) {
        super(props);
        this.state = { data: [], loading: true, title: '' };
    }

    componentDidMount() {
        this.populateData();
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderTable(this.state.data);

        return (
            <div>
                <h1 id="tableLabel">{ this.state.title }</h1>
                <Link to="create"><Button variant="primary">Create</Button></Link>
                {contents}
            </div>
        );
    }

    async populateData() {
        throw new Error("Abstract method 'populateData' must be implemented");
    }

}