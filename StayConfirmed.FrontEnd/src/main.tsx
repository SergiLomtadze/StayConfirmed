import React from 'react';
import ReactDOM from 'react-dom/client';
import { createBrowserRouter, RouterProvider, Outlet } from 'react-router-dom';
import { loadConfig } from './Helpers/ConfigHelper';
import { Paths } from './Common/Paths';
import { i18nPromise } from './Common/Translations';

import { PrimeReactProvider } from 'primereact/api';
import PublicLayout from './Layout/Public/Layout';
import PrivateLayout from './Layout/Private/Layout';
import { Error } from './Layout/Error';
import { LayoutProvider } from './Layout/Private/context/layoutcontext';

import { Login } from './Pages/Authentication/Login';
import ResetPassword from './Pages/Authentication/ResetPassword';
import Activate from './Pages/Authentication/Activate';
import { RequestUserActivation } from './Pages/Authentication/RequestUserActivation';
import TEST from './Pages/TEST/TEST';
import Register from './Pages/Authentication/Register';
import { ToastHelper } from './Helpers/ToastHelper'; // Import ToastProvider
import { AuthProvider } from './Helpers/Authentication/AuthContext';
import ProtectedRoute from './Helpers/Authentication/ProtectedRoute';

const router = createBrowserRouter([
    {
        path: '/auth',
        element: <PublicLayout><Outlet /></PublicLayout>,
        errorElement: <Error />,
        children: [
            { path: Paths['Login'].value, element: <Login /> },
            { path: Paths['ResetPassword'].value, element: <ResetPassword /> },
            { path: Paths['ActivateUser'].value + '/:token', element: <Activate /> },
            { path: Paths['ActivateUserRequest'].value, element: <RequestUserActivation /> },
            { path: Paths['Register'].value, element: <Register /> }
        ],
    },
    {
        path: '/',
        element: <ProtectedRoute><PrivateLayout><Outlet /></PrivateLayout></ProtectedRoute>,
        errorElement: <Error />,
        children: [
            { path: Paths['Home'].value, element: <TEST /> }
        ],
    },
]);

const renderApp = async () => {
    try {
        await loadConfig();
        await i18nPromise;

        ReactDOM.createRoot(document.getElementById('root')!).render(
            <React.StrictMode>
                <AuthProvider>
                    <PrimeReactProvider>
                        <LayoutProvider>
                            <ToastHelper>
                                <RouterProvider router={router} />
                            </ToastHelper>
                        </LayoutProvider>
                    </PrimeReactProvider>
                </AuthProvider>
            </React.StrictMode>
        );
    } catch (error) {
        console.error('Failed to load configuration or i18n', error);
    }
};

renderApp();
