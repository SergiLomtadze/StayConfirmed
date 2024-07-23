import React, { useState } from 'react';
import { InputText } from 'primereact/inputtext';
import { FloatLabel } from 'primereact/floatlabel';
import { Button } from 'primereact/button';
import { useTranslation } from 'react-i18next';
import { InputMask } from 'primereact/inputmask';
import { Paths } from '../../Common/Paths';
import { useNavigate } from 'react-router-dom';
import { Card } from 'primereact/card';
import { SubmitHandler, useForm } from 'react-hook-form';
import { classNames } from 'primereact/utils';
import { validateEmail, validatePassword, validateVAT } from '../../Common/Utility';
import axios from 'axios';
import { getConfig } from '../../Helpers/ConfigHelper';
import { useToast } from '../../Helpers/ToastHelper';

interface FormData {
    CompanyName: string | null;
    VAT: string | null;
    Phone: number | null;
    CompanyEmail: string | null;
    Address: string | null;
    City: string | null;
    ZIP: number | null;
    Region: string | null;
    Province: string | null;
    UserName: string | null;
    UserSurname: string | null;
    UserEmail: string | null;
    Password: string | null;
    ConfirmPassword: string | null;
}

const defaultValues: FormData = {
    CompanyName: '',
    VAT: '',
    Phone: null,
    CompanyEmail: null,
    Address: null,
    City: null,
    ZIP: null,
    Region: null,
    Province: null,
    UserName: null,
    UserSurname: null,
    UserEmail: null,
    Password: null,
    ConfirmPassword: null
};

const Register: React.FC = () => {
    const { t } = useTranslation();
    const { showToast } = useToast();
    const navigate = useNavigate();
    const {
        register,
        handleSubmit,
        watch,
        formState: { errors }
    } = useForm<FormData>({ defaultValues });
    const config = getConfig();

    const [RegisterSuccess, setRegisterSuccess] = useState<boolean>(false);

    const onSubmit: SubmitHandler<FormData> = async (data: FormData) => {
        try {
            const resp = await axios.post(`${config.APIUrl}Registration/Register`, data);
            setRegisterSuccess(true);
        } catch (error: unknown) {
            if (axios.isAxiosError(error)) {
                showToast('error', 'Error', "error");
            } else {
                showToast('error', 'Error', "error");
            }
        }
    };

    const NavigateTo = (path: string) => {
        navigate(Paths[path].value);
    };

    const footerTemplate = () => (
        <>
            {
                RegisterSuccess !== true &&
                <div className="row">
                    <div className="col">
                        <Button type="submit" label={t("Auth.Register.Button")} />
                    </div>
                </div>
            }
            <div className="row">

                <div className="col">
                    <a onClick={() => NavigateTo('Login')} className="text-primary secondary-button cursor-pointer">
                        {t("Auth.Register.Link")}
                    </a>
                </div>
            </div>
        </>
    )

    const password = watch('Password', defaultValues.Password); // Ensure the type is string

    return (
        <div className="z-5 w-full lg:w-8 px-6 text-center mt-2" style={{ minWidth: '90vw' }}>
            <form onSubmit={handleSubmit(onSubmit)} className="p-fluid">
                <Card title={t("Auth.Register.Header")} footer={footerTemplate} >
                    {
                        RegisterSuccess === true ?
                            <>
                                <div className="row">
                                    <div className="col">
                                        <h5>{t("Auth.Register.Success")}</h5>
                                    </div>
                                </div>
                            </>
                            :
                            <div className="row">
                                <div className="col" style={{ overflowY: "auto", overflowX: "hidden", maxHeight: "65vh" }}>
                                    <div className="row">
                                        <div className="col">
                                            <h4>{t("Auth.Register.Form.Company.Header")}</h4>
                                        </div>
                                    </div>
                                    <div className="row mb-3">
                                        <div className="col-md-6 mb-4">
                                            <FloatLabel>
                                                <label htmlFor="CompanyName">{t("Auth.Register.Form.Company.Name")}</label>
                                                <InputText
                                                    id="CompanyName"
                                                    {
                                                    ...register(
                                                        'CompanyName',
                                                        {
                                                            required: t("Auth.Register.Form.Company.Name") + " " + t("Auth.Register.Form.Required")
                                                        })
                                                    }
                                                    className={
                                                        classNames({ 'p-invalid': errors.CompanyName })
                                                    } />
                                            </FloatLabel>
                                            {
                                                errors.CompanyName &&
                                                <small className="p-error">
                                                    {errors.CompanyName.message}
                                                </small>
                                            }
                                        </div>
                                        <div className="col-md-6 mb-4">
                                            <FloatLabel>
                                                <label htmlFor="CompanyVAT">{t("Auth.Register.Form.Company.VAT")}</label>
                                                <InputText
                                                    id="CompanyVAT"
                                                    {
                                                    ...register('VAT',
                                                        {
                                                            required: t("Auth.Register.Form.Company.VAT") + " " + t("Auth.Register.Form.Required"),
                                                            validate: (value: string | null) => value && validateVAT(value) || t("Auth.Register.Form.Company.VAT") + " " + t("Auth.Register.Form.Invalid")
                                                        })
                                                    }
                                                    className={
                                                        classNames({ 'p-invalid': errors.VAT })
                                                    } />
                                            </FloatLabel>
                                            {
                                                errors.VAT &&
                                                <small className="p-error">
                                                    {errors.VAT.message}
                                                </small>
                                            }
                                        </div>
                                        <div className="col-md-6 mb-4">
                                            <FloatLabel>
                                                <label htmlFor="CompanyPhone">{t("Auth.Register.Form.Company.Phone")}</label>
                                                <InputMask
                                                    mask="+99-9999999999"
                                                    id="CompanyPhone"
                                                    {
                                                    ...register(
                                                        'Phone',
                                                        {
                                                            required: t("Auth.Register.Form.Company.Phone") + " " + t("Auth.Register.Form.Required")
                                                        })
                                                    }
                                                    className={
                                                        classNames({ 'p-invalid': errors.Phone })
                                                    } />
                                            </FloatLabel>
                                            {
                                                errors.Phone &&
                                                <small className="p-error">
                                                    {errors.Phone.message}
                                                </small>
                                            }
                                        </div>
                                        <div className="col-md-6 mb-4">
                                            <FloatLabel>
                                                <label htmlFor="CompanyEmail">{t("Auth.Register.Form.Company.Email")}</label>
                                                <InputText
                                                    id="CompanyEmail"
                                                    keyfilter="email"
                                                    {
                                                    ...register(
                                                        'CompanyEmail',
                                                        {
                                                            required: t("Auth.Register.Form.Company.Email") + " " + t("Auth.Register.Form.Required"),
                                                            validate: (value: string | null) => value && validateEmail(value) || t("Auth.Register.Form.Company.Email") + " " + t("Auth.Register.Form.Invalid")
                                                        })
                                                    }
                                                    className={
                                                        classNames({ 'p-invalid': errors.CompanyEmail })
                                                    } />
                                            </FloatLabel>
                                            {
                                                errors.CompanyEmail &&
                                                <small className="p-error">
                                                    {errors.CompanyEmail.message}
                                                </small>
                                            }
                                        </div>
                                        <div className="col-md-12 mb-4">
                                            <FloatLabel>
                                                <label htmlFor="CompanyAddress">{t("Auth.Register.Form.Company.Address")}</label>
                                                <InputText
                                                    id="CompanyAddress"
                                                    {
                                                    ...register(
                                                        'Address',
                                                        {
                                                            required: t("Auth.Register.Form.Company.Address") + " " + t("Auth.Register.Form.Required")
                                                        })
                                                    }
                                                    className={
                                                        classNames({ 'p-invalid': errors.Address })
                                                    } />
                                            </FloatLabel>
                                            {
                                                errors.Address &&
                                                <small className="p-error">
                                                    {errors.Address.message}
                                                </small>
                                            }
                                        </div>
                                        <div className="col-md-3 mb-4">
                                            <FloatLabel>
                                                <label htmlFor="CompanyCity">{t("Auth.Register.Form.Company.City")}</label>
                                                <InputText
                                                    id="CompanyCity"
                                                    {
                                                    ...register(
                                                        'City',
                                                        {
                                                            required: t("Auth.Register.Form.Company.City") + " " + t("Auth.Register.Form.Required")
                                                        })
                                                    }
                                                    className={
                                                        classNames({ 'p-invalid': errors.City })
                                                    } />
                                            </FloatLabel>
                                            {
                                                errors.City &&
                                                <small className="p-error">
                                                    {errors.City.message}
                                                </small>
                                            }
                                        </div>
                                        <div className="col-md-3 mb-4">
                                            <FloatLabel>
                                                <label htmlFor="CompanyZIP">{t("Auth.Register.Form.Company.ZIP")}</label>
                                                <InputText
                                                    id="CompanyZIP"
                                                    {
                                                    ...register('ZIP')
                                                    }
                                                    className={
                                                        classNames({ 'p-invalid': errors.ZIP })
                                                    } />
                                            </FloatLabel>
                                            {
                                                errors.ZIP &&
                                                <small className="p-error">
                                                    {errors.ZIP.message}
                                                </small>
                                            }
                                        </div>
                                        <div className="col-md-3 mb-4">
                                            <FloatLabel>
                                                <label htmlFor="CompanyRegion">{t("Auth.Register.Form.Company.Region")}</label>
                                                <InputText
                                                    id="CompanyRegion"
                                                    {
                                                    ...register('Region')
                                                    }
                                                    className={
                                                        classNames({ 'p-invalid': errors.Region })
                                                    } />
                                            </FloatLabel>
                                            {
                                                errors.Region &&
                                                <small className="p-error">
                                                    {errors.Region.message}
                                                </small>
                                            }
                                        </div>
                                        <div className="col-md-3 mb-4">
                                            <FloatLabel>
                                                <label htmlFor="CompanyProvince">{t("Auth.Register.Form.Company.Province")}</label>
                                                <InputText
                                                    id="CompanyProvince"
                                                    {
                                                    ...register('Province')
                                                    }
                                                    className={
                                                        classNames({ 'p-invalid': errors.Province })
                                                    } />
                                            </FloatLabel>
                                            {
                                                errors.Province &&
                                                <small className="p-error">
                                                    {errors.Province.message}
                                                </small>
                                            }
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="col">
                                            <h4>{t("Auth.Register.Form.User.Header")}</h4>
                                        </div>
                                    </div>
                                    <div className="row mb-3">
                                        <div className="col-md-6 mb-4">
                                            <FloatLabel>
                                                <label htmlFor="UserName">{t("Auth.Register.Form.User.Name")}</label>
                                                <InputText
                                                    id="UserName"
                                                    {
                                                    ...register(
                                                        'UserName',
                                                        {
                                                            required: t("Auth.Register.Form.User.Name") + " " + t("Auth.Register.Form.Required")
                                                        })
                                                    }
                                                    className={
                                                        classNames({ 'p-invalid': errors.UserName })
                                                    } />
                                            </FloatLabel>
                                            {
                                                errors.UserName &&
                                                <small className="p-error">
                                                    {errors.UserName.message}
                                                </small>
                                            }
                                        </div>
                                        <div className="col-md-6 mb-4">
                                            <FloatLabel>
                                                <label htmlFor="UserSurname">{t("Auth.Register.Form.User.Surname")}</label>
                                                <InputText
                                                    id="UserSurname"
                                                    {
                                                    ...register(
                                                        'UserSurname',
                                                        {
                                                            required: t("Auth.Register.Form.User.Surname") + " " + t("Auth.Register.Form.Required")
                                                        })
                                                    }
                                                    className={
                                                        classNames({ 'p-invalid': errors.UserSurname })
                                                    } />
                                            </FloatLabel>
                                            {
                                                errors.UserSurname &&
                                                <small className="p-error">
                                                    {errors.UserSurname.message}
                                                </small>
                                            }
                                        </div>
                                        <div className="col-md-12 mb-4">
                                            <FloatLabel>
                                                <label htmlFor="UserEmail">{t("Auth.Register.Form.User.Email")}</label>
                                                <InputText
                                                    id="UserEmail"
                                                    {
                                                    ...register(
                                                        'UserEmail',
                                                        {
                                                            required: t("Auth.Register.Form.User.Email") + " " + t("Auth.Register.Form.Required"),
                                                            validate: (value) => value && validateEmail(value) || t("Auth.Register.Form.Company.Email") + " " + t("Auth.Register.Form.Invalid")
                                                        })
                                                    }
                                                    className={
                                                        classNames({ 'p-invalid': errors.UserEmail })
                                                    } />
                                            </FloatLabel>
                                            {
                                                errors.UserEmail &&
                                                <small className="p-error">
                                                    {errors.UserEmail.message}
                                                </small>
                                            }
                                        </div>
                                        <div className="col-md-6 mb-4">
                                            <FloatLabel>
                                                <label htmlFor="UserPassword">{t("Auth.Register.Form.User.Password")}</label>
                                                <InputText
                                                    id="UserPassword"
                                                    type="password"
                                                    {
                                                    ...register(
                                                        'Password',
                                                        {
                                                            required: t("Auth.Register.Form.User.Password") + " " + t("Auth.Register.Form.Required"),
                                                            validate: (value) => value && validatePassword(value) || t("Auth.Register.Form.User.Password") + " " + t("Auth.Register.Form.Invalid")
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
                                        <div className="col-md-6 mb-4">
                                            <FloatLabel>
                                                <label htmlFor="UserPasswordRepeat">{t("Auth.Register.Form.User.PasswordRepeat")}</label>
                                                <InputText
                                                    id="UserPasswordRepeat"
                                                    type="password"
                                                    {
                                                    ...register(
                                                        'ConfirmPassword',
                                                        {
                                                            required: t("Auth.Register.Form.User.PasswordRepeat") + " " + t("Auth.Register.Form.Required"),
                                                            validate: (value) => value && value === password || t("Auth.Register.Form.User.PasswordRepeat") + " " + t("Auth.Register.Form.Mismatch")
                                                        })
                                                    }
                                                    className={
                                                        classNames({ 'p-invalid': errors.ConfirmPassword })
                                                    } />
                                            </FloatLabel>
                                            {
                                                errors.ConfirmPassword &&
                                                <small className="p-error">
                                                    {errors.ConfirmPassword.message}
                                                </small>
                                            }
                                        </div>
                                    </div>
                                </div>
                            </div>
                    }
                </Card>
            </form>
        </div>
    );
};

export default Register;
