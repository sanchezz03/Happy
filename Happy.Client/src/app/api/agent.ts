import axios, { AxiosResponse } from "axios"
import { User, UserFormValues } from "../models/user";
import { store } from "../stores/store";
import { Progress } from "../models/progress";

axios.defaults.baseURL = 'http://localhost:8000/api/v1';

const responseBody = <T> (response: AxiosResponse<T>) => response.data;

axios.interceptors.request.use(config => {
    const token = store.commonStore.token;
    if(token && config.headers) config.headers.Authorization = `Bearer ${token}`
    return config;
})

const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody),
    post: <T> (url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T> (url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    del: <T> (url: string) => axios.delete<T>(url).then(responseBody)
}

const UserProgress = {
    list: () => requests.get<Progress[]>('/progress')
}

const Account = {
    current: () => requests.get<User>('/account/information'),
    login:(user: UserFormValues) => requests.post<User>('/account/authenticate', user),
    register:(user: UserFormValues) => requests.post<User>('/account/registeration', user)
}

const agent = {
    UserProgress,
    Account
}

export default agent;