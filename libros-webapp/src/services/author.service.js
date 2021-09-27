import axios from 'axios';
import authHeader from './auth-header';

const API = 'https://localhost:5001/api/author/'

class AuthorService {
    getAuthors(){
        return axios
            .get(API, authHeader).then(res => res.data);
    }

    getAuthor(id){
        return axios.get(API+id, authHeader).then(res=> res.data)
    }
}

export default new AuthorService();