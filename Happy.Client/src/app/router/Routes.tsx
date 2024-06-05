import {RouteObject, createBrowserRouter} from "react-router-dom";
import App from "../layout/App";
import LoginForm from "../../features/users/LoginForm";
import ComplexDashboard from "../../features/complexes/dashboard/ComplexDashboard";
import ProgressDashboard from "../../features/progresses/ProgressDashboard";
import ExerciseDashboard from "../../features/Exercises/dashboard/ExerciseDashboard";
import ExerciseForm from "../../features/Exercises/form/ExerciseForm";

export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App/>,
        children: [
            {path: 'complexes', element: <ComplexDashboard/> },
            {path: 'exercises', element: <ExerciseDashboard/>},
            {path: 'exercises/createExercise', element: <ExerciseForm /> },
            {path: 'exercises/manage/:id', element: <ExerciseForm/>},
            {path: 'progress', element: <ProgressDashboard/>},
            {path: 'login', element: <LoginForm/>},
        ]
    },
]

export const router = createBrowserRouter(routes);
