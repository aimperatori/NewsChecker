import React, { Component } from 'react';

export class NewsPapper extends Component {
  static displayName = NewsPapper.name;

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
          </tr>
        </thead>
            <tbody>
            {newspappers.map(newpapper =>
            <tr key={newpapper.id}>
              <td>{newpapper.id}</td>
              <td>{newpapper.name}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : NewsPapper.renderNewspapperTable(this.state.newspappers);

    return (
      <div>
        <h1 id="tableLabel">Newspappers</h1>
        <p>This component demonstrates fetching data from the server.</p>
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
