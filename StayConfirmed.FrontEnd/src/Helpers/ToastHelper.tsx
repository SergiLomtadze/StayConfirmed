import React, { createContext, useContext, useRef, ReactNode } from 'react';
import { Toast } from 'primereact/toast';

interface ToastContextProps {
    showToast: (severity: 'success' | 'info' | 'warn' | 'error', summary: string, detail: string) => void;
}

interface ToastProviderProps {
    children: ReactNode;
}

const ToastContext = createContext<ToastContextProps | undefined>(undefined);

export const ToastHelper: React.FC<ToastProviderProps> = ({ children }) => {
    const toastRef = useRef<Toast>(null);

    const showToast = (severity: 'success' | 'info' | 'warn' | 'error', summary: string, detail: string) => {
        toastRef.current?.show({ severity, summary, detail });
    };

    return (
        <ToastContext.Provider value={{ showToast }}>
            {children}
            <Toast ref={toastRef} />
        </ToastContext.Provider>
    );
};

export const useToast = (): ToastContextProps => {
    const context = useContext(ToastContext);
    if (context === undefined) {
        throw new Error('useToast must be used within a ToastProvider');
    }
    return context;
};
