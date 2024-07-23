import React from 'react';
import Cookies from 'js-cookie';
import { Navigate, useLocation } from 'react-router-dom';

interface ProtectedRouteProps {
    children: JSX.Element;
}

const ProtectedRoute: React.FC<ProtectedRouteProps> = ({ children }) => {
    const SessionToken = Cookies.get('SessionToken');
    const location = useLocation();

    // Check if the user is not authenticated
    if (!SessionToken) {
        // Redirect them to the /login page, but save the current location they were trying to go to
        return <Navigate to="/auth/login" state={{ from: location }} replace />;
    }

    // If authenticated, render the children
    return children;
};

export default ProtectedRoute;
