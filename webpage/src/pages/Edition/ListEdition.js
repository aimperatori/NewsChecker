import React from 'react';
import { Link } from 'react-router-dom';
import { NewsCheckerFetcher }  from '../../api/NewsChecker/NewsCheckerFetcher'
import { ListAbstract } from '../../components/ListAbstract'

export class ListEdition extends ListAbstract {
    
    constructor(props) {
        super(props);
        this.state.title = "Edition";
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
                    {data.map(edition =>
                        <tr key={edition.id}>
                            <td>{edition.id}</td>
                            <td>{edition.name}</td>
                            <td>
                                <Link to={`edit/${edition.id}`}>Edit</Link>
                                <Link to={`delete/${edition.id}`}>Delete</Link>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
    
    async populateData() {
        const response = await NewsCheckerFetcher.Get('edition');
        const data = await response.json();
        this.setState({ data: data, loading: false });
    }
}
