import axios from "axios";
const API = 'https://localhost:5001/api/account/'

class AuthService {
    login(user) {
        return axios
            .post(API + 'login', {
                email: user.email,
                password: user.password
            })
            .then(res => {
                if(res.data.token){
                    localStorage.setItem('token', JSON.stringify(res.data.token));
                }

                return res.data;
            });

            
    };

    logout(){
        localStorage.removeItem('token');
    }

    register(user) {
        return axios
            .post(API + 'register', user)
            .then(res => {
                if(res.data.token){
                    localStorage.setItem('token', JSON.stringify(res.data.token));
                }
                return res.data;
            })
    }
    
}

export default new AuthService();