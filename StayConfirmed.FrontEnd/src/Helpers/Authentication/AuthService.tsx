import axios from 'axios';
import { getConfig } from '../ConfigHelper';
class AuthService {

    login(email: string, password: string) {
        return axios.post(getConfig().APIUrl + 'login', { email, password })
            .then(response => {
                if (response.data.accessToken) {
                    localStorage.setItem('user', JSON.stringify(response.data));
                }
                return response.data;
            });
    }

    logout() {
        localStorage.removeItem('user');
    }

    getCurrentUser() {
        return JSON.parse(localStorage.getItem('user') || '{}');
    }
}

export default new AuthService();
