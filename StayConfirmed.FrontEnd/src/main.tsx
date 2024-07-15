import React from 'react';
import ReactDOM from 'react-dom/client';
import { createBrowserRouter, RouterProvider, Outlet } from 'react-router-dom';
import ProtectedRoute from './Helpers/AuthHelper';
import TEST from './Pages/TEST/TEST';
import { loadConfig } from './Helpers/ConfigHelper';
import { Paths } from './Common/Paths';
import { i18nPromise } from './Common/Translations';

import PublicLayout from './Layout/Public/Layout';
import PrivateLayout from './Layout/Private/Layout';
import { Error } from './Layout/Error';

import { Login } from './Pages/Authentication/Login';
import { ResetPassword } from './Pages/Authentication/ResetPassword';
import Activate from './Pages/Authentication/Activate';
import { RequestUserActivation } from './Pages/Authentication/RequestUserActivation';
import { PrimeReactProvider } from 'primereact/api';
import { LayoutProvider } from './Layout/Private/context/layoutcontext';

const router = createBrowserRouter([
    {
        path: '/auth',
        element: <PublicLayout><Outlet /></PublicLayout>,
        errorElement: <Error />,
        children: [
            { path: Paths['Login'].value, element: <Login /> },
            { path: Paths['ResetPassword'].value, element: <ResetPassword /> },
            { path: Paths['ActivateUser'].value + '/:token', element: <Activate /> },
            { path: Paths['ActivateUserRequest'].value, element: <RequestUserActivation /> }
        ],
    },
    {
        path: '/',
        element: <PrivateLayout><Outlet /></PrivateLayout>,
        errorElement: <Error />,
        children: [
            {
                path: 'test',
                element: <ProtectedRoute element={<TEST />} />,
            },
        ],
    },
]);

const renderApp = async () => {
    try {
        await loadConfig(); // Ensure configuration is loaded
        await i18nPromise; // Ensure i18n is initialized

        const isAuthenticated = true; // Replace this with your actual authentication logic

        ReactDOM.createRoot(document.getElementById('root')!).render(
            <React.StrictMode>
                {isAuthenticated ? (
                    <PrimeReactProvider>
                        <LayoutProvider>
                            <RouterProvider router={router} />
                        </LayoutProvider>
                    </PrimeReactProvider>
                ) : (
                    <RouterProvider router={router} />
                )}
            </React.StrictMode>
        );
    } catch (error) {
        console.error('Failed to load configuration or i18n', error);
    }
};

renderApp();
