import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { NewsCheckerFetcher } from '../../api/NewsChecker/NewsCheckerFetcher';
import { ListAbstract } from '../../components/ListAbstract'

export class ListNewspapper extends ListAbstract {

    constructor(props) {
        super(props);
        this.state.title = "Newspapper"
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
                    {data.map(newpapper =>
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

    async populateData() {
        const response = await NewsCheckerFetcher.Get("Newspapper");
        const data = await response.json();
        this.setState({ data: data, loading: false });
    }
}
