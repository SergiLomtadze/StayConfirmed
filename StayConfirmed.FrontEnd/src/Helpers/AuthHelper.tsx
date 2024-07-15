import { Navigate } from "react-router-dom";

const isAuthenticated = (): boolean => {
    return true;
};
interface ProtectedRouteProps {
    element: JSX.Element;
}

const ProtectedRoute: React.FC<ProtectedRouteProps> = ({ element }) => {
    return isAuthenticated() ? element : <Navigate to="/auth/login" />;
};

export default ProtectedRoute;