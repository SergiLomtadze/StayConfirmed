import { changeLanguage } from 'i18next';
import React, { ReactNode, useEffect, useState } from 'react';
import ReactCountryFlag from 'react-country-flag';
import { useTranslation } from 'react-i18next';

interface LayoutProps {
    children: ReactNode;
}

const Layout: React.FC<LayoutProps> = ({ children }) => {
    const { i18n } = useTranslation();
    const [activeLanguage, setActiveLanguage] = useState<string>(i18n.language);

    useEffect(() => {
        setActiveLanguage(i18n.language);
    }, [i18n.language]);

    return (
        <div className="bg-primary-reverse bg-primary-50">
            <div className="flex justify-content-end me-3">
                <button
                    className={`btn btn-language`}
                    onClick={() => changeLanguage('en')}>
                    <ReactCountryFlag
                        countryCode="GB"
                        svg
                        title="English"
                        style={{
                            width: activeLanguage === 'en' ? '2.5em' : '2em',
                            height: activeLanguage === 'en' ? '2.5em' : '2em',
                            filter: activeLanguage === 'en' ? 'none' : 'blur(0.7px)',
                            transition: 'all 0.2s ease-in-out'
                        }} />
                </button>
                <button
                    className={`btn btn-language`}
                    onClick={() => changeLanguage('it')}>
                    <ReactCountryFlag
                        countryCode="IT"
                        svg
                        title="Italian"
                        style={{
                            width: activeLanguage === 'it' ? '2.5em' : '2em',
                            height: activeLanguage === 'it' ? '2.5em' : '2em',
                            filter: activeLanguage === 'it' ? 'none' : 'blur(0.7px)',
                            transition: 'all 0.2s ease-in-out'
                        }} />
                </button>
            </div>
            <div className="flex justify-content-center">
                <div className="w-full lg:w-5 h-screen text-center flex justify-content-center align-items-start">
                    {children}
                </div>
                <svg xmlns="http://www.w3.org/2000/svg" xmlnsXlink="http://www.w3.org/1999/xlink" className="svg-background" viewBox="0 0 1440 250" preserveAspectRatio="xMidYMid slice">
                    <defs>
                        <linearGradient id="c" x1="50%" x2="50%" y1="0%" y2="100%">
                            <stop offset="0%" stopColor="var(--primary-200)" />
                            <stop offset="99.052%" stopColor="var(--primary-300)" />
                        </linearGradient>
                        <path id="b" d="M0 202c142.333-66.667 249-90 320-70 106.5 30 122 83.5 195 83.5h292c92.642-106.477 190.309-160.81 293-163 102.691-2.19 216.025 47.643 340 149.5v155.5H0V202z" />
                        <filter id="a" width="105.1%" height="124.3%" x="-2.6%" y="-12.8%" filterUnits="objectBoundingBox">
                            <feOffset dy="-2" in="SourceAlpha" result="shadowOffsetOuter1" />
                            <feGaussianBlur in="shadowOffsetOuter1" result="shadowBlurOuter1" stdDeviation="12" />
                            <feColorMatrix in="shadowBlurOuter1" values="0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0.11 0" />
                        </filter>
                        <linearGradient id="d" x1="50%" x2="50%" y1="0%" y2="99.142%">
                            <stop offset="0%" stopColor="var(--primary-300)" />
                            <stop offset="100%" stopColor="var(--primary-500)" />
                        </linearGradient>
                    </defs>
                    <g fill="none" fillRule="evenodd">
                        <g transform="translate(0 .5)">
                            <use fill="#000" filter="url(#a)" xlinkHref="#b" />
                            <use fill="url(#c)" xlinkHref="#b" />
                        </g>
                        <path fill="url(#d)" d="M0 107c225.333 61.333 364.333 92 417 92 79 0 194-79.5 293-79.5S914 244 1002 244s156-45 195-68.5c26-15.667 107-74.167 243-175.5v357.5H0V107z" transform="translate(0 .5)" />
                    </g>
                </svg>

            </div>
        </div>
    );
};

export default Layout;