import React from 'react';
import { Link } from 'react-router-dom';
import { NewsCheckerFetcher } from '../../api/NewsChecker/NewsCheckerFetcher';
import { ListAbstract } from '../../components/ListAbstract'

export class ListNews extends ListAbstract {

    constructor(props) {
        super(props);
        this.state.title = "News";
    }

    renderTable(data) {
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Title</th>
                        <th>Subtitle</th>
                        <th>Resume</th>
                        <th>Edition name</th>
                        <th>Published data</th>
                        <th>Newspapper name</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(article =>
                        <tr key={article.id}>
                            <td>{article.id}</td>
                            <td>{article.title}</td>
                            <td>{article.subtitle}</td>
                            <td>{article.resume}</td>
                            <td>{article.edition.name}</td>
                            <td>{article.edition.publishDate}</td>
                            <td>{article.edition.newspaper.name}</td>
                            <td>
                                <Link to={`edit/${article.id}`}>Edit</Link>
                                <Link to={`delete/${article.id}`}>Delete</Link>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    async populateData() {
        const response = await NewsCheckerFetcher.Get("news");
        const data = await response.json();
        this.setState({ data: data, loading: false });
    }
}
