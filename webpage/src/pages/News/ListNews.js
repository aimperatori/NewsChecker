import React from 'react';
import { Link } from 'react-router-dom';
import { NewsCheckerFetcher } from '../../api/NewsChecker/NewsCheckerFetcher';
import { ListAbstract } from '../../components/ListAbstract'
import NewsTypes from '../../components/NewsType/Data/NewsTypes';
import { formatDate } from '../../helpers/DateTimeHelper';

export class ListNews extends ListAbstract {

    constructor(props) {
        super(props);
        this.state.title = "News";
    }

    getNewsTypeName(newsTypeId) {
        return NewsTypes[newsTypeId];
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
                        <th>News Type</th>
                        <th>Edition name</th>
                        <th>Published data</th>
                        <th>Newspapper name</th>
                        <th>Journalists</th>
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
                            <td>{this.getNewsTypeName(article.newsType)}</td>
                            <td>{article.edition.name}</td>
                            <td>{formatDate(article.edition.publishDate)}</td>
                            <td>{article.edition.newspapper.name}</td>
                            <td>{article.journalist.map(row => row.name).join(', ')}</td>
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
