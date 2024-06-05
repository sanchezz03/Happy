import axios, { AxiosResponse } from "axios"
import { User, UserFormValues } from "../models/user";
import { store } from "../stores/store";
import { Progress } from "../models/progress";
import { Exercise, ExerciseFormValues } from "../models/exercise";

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

const Exercises = {
    list: () => requests.get<Exercise[]>('/exercise'),
    get: (exersiceName: string) => requests.get<Exercise>('/exercise'),
    create: (exercise: ExerciseFormValues) => requests.post<void>('/exercise',exercise),
    update: (id: number, exercise: ExerciseFormValues) => requests.put<void>(`/exercise/${id}`, exercise),
    delete: (id: number) => requests.del<void>(`/exercise/${id}`)
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
    Exercises,
    UserProgress,
    Account
}

export default agent;