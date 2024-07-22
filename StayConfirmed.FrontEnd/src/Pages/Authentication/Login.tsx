import React from 'react';
import { getConfig } from '../../Helpers/ConfigHelper';
import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';
import { useTranslation } from 'react-i18next';
import { Paths } from '../../Common/Paths';
import { useNavigate } from 'react-router-dom';
import { useForm } from 'react-hook-form';
import { Card } from 'primereact/card';
import { classNames } from 'primereact/utils';
import { FloatLabel } from 'primereact/floatlabel';
import { useToast } from '../../Helpers/ToastHelper';
import AuthService from '../../Helpers/Authentication/AuthService';
import axios from 'axios';

interface FormData {
    Email: string;
    Password: string;
}

export const Login: React.FC = () => {
    const { t } = useTranslation();
    const navigate = useNavigate();
    const { register, handleSubmit, formState: { errors } } = useForm<FormData>();
    const config = getConfig();
    const { showToast } = useToast();

    const onSubmit = async (data: FormData) => {
        try {
            const response = await AuthService.login(data.Email, data.Password);
            navigate(Paths['Home'].value); // Assuming you have a Dashboard route
            showToast('success', 'Success', t("Auth.Login.Success"));
        } catch (error) {
            if (axios.isAxiosError(error)) {
                showToast('error', 'Error', error.response?.data.message || t("Auth.Login.Fail"));
            } else {
                showToast('error', 'Error', t("Auth.Login.Error"));
            }
        }
    };


    function formFooter() {
        return (
            <>
                <Button type="submit" label={t("Auth.Login.Button")} className="w-100" />
                <div className="flex align-items-center justify-content-center mt-4 gap-3">
                    <Button label={t("Auth.Login.Link")} className="p-button-text" onClick={() => navigate(Paths['ResetPassword'].value)} />
                    <Button label={t("Auth.Login.Register")} className="p-button-text" onClick={() => navigate(Paths['Register'].value)} />
                </div>
            </>
        );
    }

    function formHeader() {
        return (
            <>
                <img src={`${config.CDN}${Paths.Icon.value}`} alt="logo" className="w-5rem" />
                <h1 className="text-4xl font-light mt-4 text-primary-500">
                    {t("Auth.Login.Header")}
                </h1>
                <p>{t("Auth.Login.SubHeader")}</p>
            </>
        );
    }

    return (
        <div className="z-5 w-full px-6 text-center mt-8" style={{ maxWidth: '500px' }}>
            <form onSubmit={handleSubmit(onSubmit)} className="p-fluid">
                <Card footer={formFooter} header={formHeader}>
                    <div className="row mb-3">
                        <div className="col-md-12 mb-4">
                            <FloatLabel>
                                <label htmlFor="UserName">
                                    {t("Auth.Login.Form.User.Username")}
                                </label>
                                <InputText
                                    id="UserName"
                                    {
                                    ...register(
                                        'Email',
                                        {
                                            required: t("Auth.Login.Form.User.Username") + " " + t("Auth.Login.Form.Required")
                                        })
                                    }
                                    className={
                                        classNames({ 'p-invalid': errors.Email })
                                    } />
                            </FloatLabel>
                            {
                                errors.Email &&
                                <small className="p-error">
                                    {errors.Email.message}
                                </small>
                            }
                        </div>
                    </div>
                    <div className="row mb-3">
                        <div className="col-md-12">
                            <FloatLabel>
                                <label htmlFor="Password">
                                    {t("Auth.Login.Form.User.Password")}
                                </label>
                                <InputText
                                    id="Password"
                                    type="password"
                                    {
                                    ...register(
                                        'Password',
                                        {
                                            required: t("Auth.Login.Form.User.Password") + " " + t("Auth.Login.Form.Required")
                                        })
                                    }
                                    className={
                                        classNames({ 'p-invalid': errors.Password })
                                    } />
                            </FloatLabel>
                            {
                                errors.Password &&
                                <small className="p-error">
                                    {errors.Password.message}
                                </small>
                            }
                        </div>
                    </div>

                </Card>
            </form>
        </div >
    );
};

export default Login;