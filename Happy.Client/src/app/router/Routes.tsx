import {RouteObject, createBrowserRouter} from "react-router-dom";
import App from "../layout/App";
import LoginForm from "../../features/users/LoginForm";
import ComplexDashboard from "../../features/complexes/dashboard/ComplexDashboard";
import ProgressDashboard from "../../features/progresses/ProgressDashboard";

export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App/>,
        children: [
            {path: 'complexes', element: <ComplexDashboard/> },
            {path: 'progress', element: <ProgressDashboard/>},
            {path: 'login', element: <LoginForm/>},
        ]
    },
]

export const router = createBrowserRouter(routes);
