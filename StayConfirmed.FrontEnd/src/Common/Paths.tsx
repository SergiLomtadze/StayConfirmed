export interface PathValue {
    value: string;
}

export const Paths: { [key: string]: PathValue } = {
    Login: {
        value: '/auth/login'
    },
    Register: {
        value: '/auth/register'
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
    LogoFull: {
        value: "images/logo-white.png"
    },
    Logo: {
        value: "images/logo-white.png"
    },
    Icon: {
        value: "images/icon.png"
    }
};
