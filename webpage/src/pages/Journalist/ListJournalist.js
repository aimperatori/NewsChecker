import React from 'react';
import { Link } from 'react-router-dom';
import { NewsCheckerFetcher } from '../../api/NewsChecker/NewsCheckerFetcher';
import { ListAbstract } from '../../components/ListAbstract'

export class ListJournalist extends ListAbstract {
    
    constructor(props) {
        super(props);
        this.state.title = "Journalist";
    }

    renderTable(data) {
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
                    {data.map(journalist =>
                        <tr key={journalist.id}>
                            <td>{journalist.id}</td>
                            <td>{journalist.name}</td>
                            <td>
                                <Link to={`edit/${journalist.id}`}>Edit</Link>
                                <Link to={`delete/${journalist.id}`}>Delete</Link>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    async populateData() {
        const response = await NewsCheckerFetcher.Get("journalist");
        const data = await response.json();
        this.setState({ data: data, loading: false });
    }
}
