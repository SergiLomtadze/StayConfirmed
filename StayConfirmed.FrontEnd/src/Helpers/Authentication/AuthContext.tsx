import React, { createContext, useContext, useState, useEffect, ReactNode } from 'react';
import AuthService from './AuthService';

interface SessionToken {
    token: string;
}

interface AuthContextType {
    SessionToken: SessionToken | null;
    setCurrentUser: React.Dispatch<React.SetStateAction<SessionToken | null>>;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: { children: ReactNode }) => {
    const [SessionToken, setCurrentUser] = useState<SessionToken | null>(null);

    useEffect(() => {
        const user = AuthService.getCurrentUser();
        if (user) {
            setCurrentUser(user);
        }
    }, []);

    return (
        <AuthContext.Provider value={{ SessionToken, setCurrentUser }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = (): AuthContextType => {
    const context = useContext(AuthContext);
    if (context === undefined) {
        throw new Error('useAuth must be used within an AuthProvider');
    }
    return context;
};
