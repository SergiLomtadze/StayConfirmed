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
    const navigate = useNavigate();
    const config = getConfig();

    const NavigateTo = (path: string) => {
        navigate(Paths[path].value);
    };

    const handleResetPassword = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        try {
            await axios.post("/User/ForgotPassword", { email });
            alert("Password reset link has been sent to your email.");
            navigate("/login");
        } catch (error) {
            console.error("There was an error sending the reset password email!", error);
            alert("Failed to send reset password email. Please try again.");
        }
    };

    return (
        <div className="z-5 w-full lg:w-8 px-6 text-center mt-8" style={{ maxWidth: '400px' }}>
            <div className="w-full flex align-items-center justify-content-center">
                <img src={config.CDN + Paths.Logo.value} alt="logo" className="w-6rem" />
            </div>
            <h1 className="text-4xl font-light mt-4 text-primary-500">
                {t("Auth.ResetPassword.Header")}
            </h1>
            <p>
                {t("Auth.ResetPassword.SubHeader")}
            </p>
            <div className="mt-5 text-left">
                <label htmlFor="username" className="block mb-2" style={{ color: '#4c566a' }}>
                    {t("Auth.Username")}
                </label>
                <InputText id="username" type="text" className="w-full" />
                <div className="flex align-items-center justify-content-between mt-4 gap-3">
                    <Button label={t("Auth.ResetPassword.Button")} className="w-10rem"></Button>
                    <a onClick={() => NavigateTo('Login')} className="text-primary secondary-button cursor-pointer">
                        {t("Auth.ResetPassword.Link")}
                    </a>
                </div>
            </div>
        </div>
    );
};

export default ResetPassword;
