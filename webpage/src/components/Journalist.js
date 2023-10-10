import React, { Component } from 'react';

export class Journalist extends Component {
    static displayName = Journalist.name;

    constructor(props) {
        super(props);
        this.state = { journalists: [], loading: true };
    }

    componentDidMount() {
        this.populateEditionsData();
    }

    static renderEditionTable(journalists) {
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                    </tr>
                </thead>
                <tbody>
                    {journalists.map(journalist =>
                        <tr key={journalist.id}>
                            <td>{journalist.id}</td>
                            <td>{journalist.name}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Journalist.renderEditionTable(this.state.journalists);

        return (
            <div>
                <h1 id="tableLabel">Journalists</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateEditionsData() {
        const response = await fetch('https://localhost:7113/Journalist');
        const data = await response.json();
        this.setState({ journalists: data, loading: false });
    }
}
