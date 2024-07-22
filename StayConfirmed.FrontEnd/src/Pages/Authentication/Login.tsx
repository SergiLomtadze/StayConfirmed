import React from 'react';
import { useForm, Controller } from 'react-hook-form';
import { getConfig } from '../../Helpers/ConfigHelper';
import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';
import { useTranslation } from 'react-i18next';
import { Paths } from '../../Common/Paths';
import { useNavigate } from 'react-router-dom';
import { Card } from 'primereact/card';
import axios from 'axios';

export const Login: React.FC = () => {
    const { t } = useTranslation();
    const config = getConfig();
    const navigate = useNavigate();
    const { control, handleSubmit, formState: { errors } } = useForm();

    const NavigateTo = (path: string) => {
        navigate(Paths[path].value);
    };

    const handleLogin = async (data) => {
        try {
            await axios.post(config.APIUrl + "User/ForgotPassword", { email: data.email });
            // Assuming you set some state for sending status and errors
            setSendStatus(true);
            setSendErrors(null);
        } catch (error) {
            console.error(error);
            setSendErrors(t("Common.Errors.SendEmail"));
        }
    };

    return (
        <div className="z-5 w-full lg:w-8 px-6 text-center mt-8" style={{ maxWidth: '500px' }}>
            <Card>
                <form onSubmit={handleSubmit(handleLogin)}>
                    <div className="w-full flex align-items-center justify-content-center">
                        <img src={config.CDN + Paths.Icon.value} alt="logo" className="w-5rem" />
                    </div>
                    <h1 className="text-4xl font-light mt-4 text-primary-500">
                        {t("Auth.Login.Header")}
                    </h1>
                    <p>
                        {t("Auth.Login.SubHeader")}
                    </p>
                    <div className="mt-5 text-left">
                        <label htmlFor="username" className="block mb-2" style={{ color: '#4c566a' }}>
                            {t("Auth.Username")}
                        </label>
                        <Controller
                            name="username"
                            control={control}
                            defaultValue=""
                            rules={{ required: t("Auth.UsernameRequired") }}
                            render={({ field }) => <InputText id="username" {...field} type="text" className="w-full" />}
                        />
                        {errors.username && <span className="text-red-500">{errors.username.message}</span>}

                        <label htmlFor="password" className="block mb-2 mt-3" style={{ color: '#4c566a' }}>
                            {t("Auth.Password")}
                        </label>
                        <Controller
                            name="password"
                            control={control}
                            defaultValue=""
                            rules={{ required: t("Auth.PasswordRequired") }}
                            render={({ field }) => <InputText id="password" {...field} type="password" className="w-full" />}
                        />
                        {errors.password && <span className="text-red-500">{errors.password.message}</span>}

                        <div className="flex align-items-center justify-content-center mt-4 gap-3">
                            <Button label={t("Auth.Login.Button")} className="w-100"></Button>
                        </div>
                        <div className="flex align-items-center justify-content-center mt-4 gap-3">
                            <a onClick={() => NavigateTo('ResetPassword')} className="text-primary secondary-button cursor-pointer">
                                {t("Auth.Login.Link")}
                            </a>
                            <a onClick={() => NavigateTo('Register')} className="text-primary secondary-button cursor-pointer">
                                {t("Auth.Login.Register")}
                            </a>
                        </div>
                    </div>
                </form>
            </Card>
        </div>
    );
};

export default Login;