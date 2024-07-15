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
    ActivateUser: {
        value: "/auth/activate-user"
    },
    ActivateUserRequest: {
        value: "/auth/activate-user-request"
    },
    Logo: {
        value: "images/logo-white.png"
    },
};
