import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from 'axios';
import { useTranslation } from "react-i18next";
import { getConfig } from "../../Helpers/ConfigHelper";
import { Paths } from "../../Common/Paths";
import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';

export const ResetPassword: React.FC = () => {
    const { t } = useTranslation();
    const [email, setEmail] = useState<string>("");
    const [sendStatus, setSendStatus] = useState<boolean>(false);
    const [sendError, setSendErrors] = useState<string | null>(null);
    const navigate = useNavigate();
    const config = getConfig();

    const NavigateTo = (path: string) => {
        navigate(Paths[path].value);
    };

    const handleResetPassword = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        try {
            await axios.post(config.APIUrl + "User/ForgotPassword", { email });
            setSendStatus(true);
            setSendErrors(null);
        } catch (error) {
            console.error(error);
            setSendErrors(t("Common.Errors.SendEmail"));
        }
    };

    return (
        sendStatus ?
            (
                <div className="z-5 w-full lg:w-8 px-6 text-center mt-8" style={{ maxWidth: '400px' }}>
                    <div className="w-full flex align-items-center justify-content-center m-3">
                        <img src={config.CDN + Paths.Logo.value} alt="logo" className="w-25rem" />
                    </div>
                    {/*<h1 className="text-4xl font-light mt-4 text-primary-500">*/}
                    {/*    {t("Auth.ResetPassword.Header")}*/}
                    {/*</h1>*/}
                    <p>
                        {t("Auth.ResetPassword.SubHeaderSuccess")}
                    </p>
                    <div className="flex align-items-center justify-content-center mt-4 gap-3">
                        <a onClick={() => NavigateTo('Login')} className="text-primary secondary-button cursor-pointer">
                            {"Auth.ResetPassword.Link"}
                        </a>
                    </div>
                </div>
            )
            :
            (
                <div className="z-5 w-full lg:w-8 px-6 text-center mt-8" style={{ maxWidth: '400px' }}>
                    <div className="w-full flex align-items-center justify-content-center m-3">
                        <img src={config.CDN + Paths.Logo.value} alt="logo" className="w-25rem" />
                    </div>
                    {/*<h1 className="text-4xl font-light mt-4 text-primary-500">*/}
                    {/*    {t("Auth.ResetPassword.Header")}*/}
                    {/*</h1>*/}
                    <p>
                        {t("Auth.ResetPassword.SubHeader")}
                    </p>
                    {
                        sendError &&
                        <p className="text-danger">
                            {t(sendError)}
                        </p>
                    }
                    <form onSubmit={handleResetPassword} className="mt-5 text-left">
                        <label htmlFor="email" className="block mb-2" style={{ color: '#4c566a' }}>
                            {t("Auth.Email")}
                        </label>
                        <InputText id="email" type="email" className="w-full" value={email} onChange={(e) => setEmail(e.target.value)} required />
                        <div className="flex align-items-center justify-content-center mt-4 gap-3">
                            <Button label={t("Auth.ResetPassword.Button")} type="submit" className="w-10rem"></Button>
                            <a onClick={() => NavigateTo('Login')} className="text-primary secondary-button cursor-pointer">
                                {t("Auth.ResetPassword.Link")}
                            </a>
                        </div>
                    </form>
                </div >
            )
    );
};

export default ResetPassword;
