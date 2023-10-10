import React, { Component } from 'react';

export class Edition extends Component {
    static displayName = Edition.name;

    constructor(props) {
        super(props);
        this.state = { editions: [], loading: true };
    }

    componentDidMount() {
        this.populateEditionsData();
    }

    static renderEditionTable(editions) {
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Publish Date</th>
                        <th>Newspapper name</th>
                    </tr>
                </thead>
                <tbody>
                    {editions.map(edition =>
                        <tr key={edition.id}>
                            <td>{edition.id}</td>
                            <td>{edition.name}</td>
                            <td>{edition.publishDate}</td>
                            <td>{edition.newspaper.name}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Edition.renderEditionTable(this.state.editions);

        return (
            <div>
                <h1 id="tableLabel">Editions</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateEditionsData() {
        const response = await fetch('https://localhost:7113/Edition');
        const data = await response.json();
        this.setState({ editions: data, loading: false });
    }
}
