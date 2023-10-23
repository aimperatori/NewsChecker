
export class NewsCheckerFetcher {

    static async Get(endpoint) {
        return fetch(`https://localhost:7113/${endpoint}`);
    }

    static async GetById(endpoint, id) {
        return fetch(`https://localhost:7113/${endpoint}/${id}`);
    }

    static async Post(endpoint, formData) {
        return fetch('https://localhost:7113/' + endpoint, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(formData),
        })
            /*
            .then((response) => response.json())
            .then((data) => {
                // Manipule a resposta da API conforme necess�rio
                console.log(data);
                this.setState({ loading: false });
            })
            .catch((error) => {
                console.error('Erro ao enviar o formul�rio:', error);
                this.setState({ loading: false });
            });
            */
    }

    static async Put(endpoint, id, formData) {
        return fetch(`https://localhost:7113/${endpoint}/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(formData),
        });
    }

}