import axios from "axios";
const API = 'https://localhost:5001/api/book/'
import authHeader from "./auth-header";

class BookService {

    getBooks(){
        return axios.get(API, authHeader).then(res => {
            return res.data
        })
    }

    getBook(id){
        return axios.get(API+id, authHeader).then(res=> res.data)
    }
}

export default new BookService();