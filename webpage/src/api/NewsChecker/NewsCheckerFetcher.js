
export class NewsCheckerFetcher {

    static async Get(endpoint) {
        return fetch('https://localhost:7113/' + endpoint);
    }

}