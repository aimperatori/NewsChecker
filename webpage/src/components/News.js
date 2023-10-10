import React, { Component } from 'react';

export class News extends Component {
    static displayName = News.name;

    constructor(props) {
        super(props);
        this.state = { news: [], loading: true };
    }

    componentDidMount() {
        this.populateNewsData();
    }

    static renderNewsTable(news) {
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
                    </tr>
                </thead>
                <tbody>
                    {news.map(article =>
                        <tr key={article.id}>
                            <td>{article.id}</td>
                            <td>{article.title}</td>
                            <td>{article.subtitle}</td>
                            <td>{article.resume}</td>
                            <td>{article.edition.name}</td>
                            <td>{article.edition.publishDate}</td>
                            <td>{article.edition.newspaper.name}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : News.renderNewsTable(this.state.news);

        return (
            <div>
                <h1 id="tableLabel">News</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateNewsData() {
        const response = await fetch('https://localhost:7113/News');
        const data = await response.json();
        this.setState({ news: data, loading: false });
    }
}
