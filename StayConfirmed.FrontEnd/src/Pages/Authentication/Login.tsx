import React from 'react';
import { getConfig } from '../../Helpers/ConfigHelper';
import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';
import { useTranslation } from 'react-i18next';
import { Paths } from '../../Common/Paths';
import { useNavigate } from 'react-router-dom';
import { Card } from 'primereact/card';

export const Login: React.FC = () => {
    const { t } = useTranslation();
    const config = getConfig();
    const navigate = useNavigate();

    const NavigateTo = (path: string) => {
        navigate(Paths[path].value);
    };

    return (
        <div className="z-5 w-full lg:w-8 px-6 text-center mt-8" style={{ maxWidth: '400px' }}>
            <Card>
                <div className="w-full flex align-items-center justify-content-center m-3">
                    <img src={config.CDN + Paths.Logo.value} alt="logo" className="w-25rem" />
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
                    <InputText id="username" type="text" className="w-full" />
                    <label htmlFor="password" className="block mb-2 mt-3" style={{ color: '#4c566a' }}>
                        {t("Auth.Password")}
                    </label>
                    <InputText id="password" type="password" className="w-full" />
                    <div className="flex align-items-center justify-content-center mt-4 gap-3">
                        <Button label={t("Auth.Login.Button")} className="w-10rem"></Button>
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
            </Card>
        </div>
    );
};

export default Login;
