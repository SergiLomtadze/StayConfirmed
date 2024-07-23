import axios from 'axios';
import Cookies from 'js-cookie';
import { getConfig } from '../ConfigHelper';

class AuthService {
    login(email: string, password: string) {
        return axios.post(getConfig().APIUrl + 'login', { email, password })
            .then(response => {
                if (response.data.accessToken) {
                    Cookies.set('SessionToken', response.data.accessToken, {
                        expires: response.data.expiresIn,
                        secure: process.env.NODE_ENV === 'production',
                        sameSite: 'Strict'
                    });
                    console.log("Token saved:", Cookies.get('SessionToken')); // Log the saved token
                }
                return response.data;
            })
            .catch(error => {
                console.error("Login error:", error);
                throw error;
            });
    }

    logout() {
        Cookies.remove('SessionToken');
    }

    getCurrentUser() {
        const token = Cookies.get('SessionToken');
        console.log("Current token from cookies:", token); // Log the current token
        if (token) {
            // Here you would normally decode the token or fetch user info from your server
            return { token };
        }
        return null;
    }
}

export default new AuthService();
