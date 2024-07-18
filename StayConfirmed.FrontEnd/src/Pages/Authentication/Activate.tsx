import React, { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Paths } from "../../Common/Paths";
import { useTranslation } from "react-i18next";
import { getConfig } from "../../Helpers/ConfigHelper";
import axios from "axios";
import { Button } from "primereact/button";

const Activate: React.FC = () => {
    const { token } = useParams<{ token: string }>();
    const { t } = useTranslation();
    const config = getConfig();
    const navigate = useNavigate();
    const [activationStatus, setActivationStatus] = useState<boolean>(false);
    const [activationErrors, setActivationErrors] = useState<string | null>(null);

    const NavigateTo = (path: string) => {
        navigate(Paths[path].value);
    };

    useEffect(() => {
        if (activationStatus) {
            // Redirect or perform any necessary action after successful activation
        }
    }, [activationStatus]);

    const handleActivation = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        try {
            await axios.get(config.APIUrl + "User/ActivateUser/" + token);
            setActivationStatus(true);
            setActivationErrors(null);
        } catch (error) {
            console.error(error);
            setActivationErrors(t("Common.Errors.UserActivation"));
        }
    };

    return (
        <div className="z-5 w-full lg:w-8 px-6 text-center mt-8" style={{ maxWidth: '400px' }}>
            <div className="w-full flex align-items-center justify-content-center m-3">
                <img src={config.CDN + Paths.Logo.value} alt="logo" className="w-25rem" />
            </div>
            <p>
                {t("Auth.ActivateUser.SubHeader")}
            </p>
            {
                activationErrors &&
                <p className="text-danger">
                    {t(activationErrors)}
                </p>
            }
            <form onSubmit={handleActivation} className="mt-5 text-left">
                <div className="flex align-items-center justify-content-between mt-4 gap-3">
                    <Button label={t("Auth.ActivateUser.Button")} type="submit" className="w-100" />
                </div>
                <div className="flex align-items-center justify-content-center mt-4 gap-3">
                    <a onClick={() => NavigateTo('Login')} className="text-primary secondary-button cursor-pointer">
                        {t("Auth.ActivateUser.Link")}
                    </a>
                </div>
            </form>
        </div >
    );
};

export default Activate;
