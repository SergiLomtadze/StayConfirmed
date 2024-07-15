export interface PathValue {
    value: string;
}

export const Paths: { [key: string]: PathValue } = {
    Login: {
        value: '/auth/login'
    },
    ResetPassword: {
        value: '/auth/reset-password'
    },
    Logo: {
        value: "images/logo-white.png"
    }
};
