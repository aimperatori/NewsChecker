import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import Button from 'react-bootstrap/Button';

export class ListNewspapper extends Component {
    static displayName = ListNewspapper.name;

    constructor(props) {
        super(props);
        this.state = { newspappers: [], loading: true };
    }

    componentDidMount() {
        this.populateNewspapperData();
    }

    static renderNewspapperTable(newspappers) {
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {newspappers.map(newpapper =>
                    <tr key={newpapper.id}>
                        <td>{newpapper.id}</td>
                        <td>{newpapper.name}</td>
                        <td>
                            <Link to={`edit/${newpapper.id}`}>Edit</Link>
                            <Link to={`delete/${newpapper.id}`}>Delete</Link>
                        </td>
                    </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ListNewspapper.renderNewspapperTable(this.state.newspappers);

        return (
            <div>
                <h1 id="tableLabel">Newspappers</h1>
                <p>This component demonstrates fetching data from the server.</p>
                <Link to="create"><Button variant="primary">Create</Button></Link>
                {contents}
            </div>
        );
    }

    async populateNewspapperData() {
        const response = await fetch('https://localhost:7113/Newspaper');
        const data = await response.json();
        this.setState({ newspappers: data, loading: false });
    }
}
