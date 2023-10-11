
export class NewsCheckerFetcher {

    static async Get(endpoint) {
        return fetch('https://localhost:7113/' + endpoint);
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
                // Manipule a resposta da API conforme necessário
                console.log(data);
                this.setState({ loading: false });
            })
            .catch((error) => {
                console.error('Erro ao enviar o formulário:', error);
                this.setState({ loading: false });
            });
            */
    }

}