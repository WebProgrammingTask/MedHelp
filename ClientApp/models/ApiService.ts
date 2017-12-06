import axios from 'axios';

export const ApiService = axios.create({
    baseURL: 'api/',
    headers: {
        Authorization: 'Bearer ' + localStorage.getItem('access_token')
    }
});