import { isRouteErrorResponse, useNavigate, useRouteError } from 'react-router-dom';
import { Divider } from 'primereact/divider';
import { Button } from 'primereact/button';
import { Icon } from '../Common/Icons/Icon';

export const Error = () => {
    const navigate = useNavigate();
    const navigateToDashboard = () => {
        navigate('/');
    };

    const error = useRouteError();

    if (isRouteErrorResponse(error)) {
        console.error(error.data);
    }


    return (
        <div className="fixed w-full h-full top-0 left-0 opacity-70 bg-primary-reverse">
            <div className="flex align-items-center justify-content-center relative">
                <div className="h-screen flex justify-content-center align-items-center w-full lg:w-6">
                    <div className="z-5 w-6 h-6">
                        <Icon Name="Error" Classes="text-red-500" />
                        <h1 className="text-6xl font-light my-4 mx-0 text-red-500">Error Occured</h1>
                        <Divider className="w-7rem"></Divider>
                        <p className="mt-4 text-lg text-color">Something went wrong.</p>
                        <Button label="Go To Dashboard" onClick={navigateToDashboard} className="mt-5 border-none bg-red-500"></Button>
                    </div>
                </div>
            </div>

            <svg xmlns="http://www.w3.org/2000/svg" xmlnsXlink="http://www.w3.org/1999/xlink" className="absolute bottom-0 w-screen" viewBox="0 0 1440 250">
                <defs>
                    <linearGradient id="c" x1="50%" x2="50%" y1="0%" y2="100%">
                        <stop offset="0%" stopColor="var(--red-200)" />
                        <stop offset="99.052%" stopColor="var(--red-300)" />
                    </linearGradient>
                    <path id="b" d="M0 202c142.333-66.667 249-90 320-70 106.5 30 122 83.5 195 83.5h292c92.642-106.477 190.309-160.81 293-163 102.691-2.19 216.025 47.643 340 149.5v155.5H0V202z" />
                    <filter id="a" width="105.1%" height="124.3%" x="-2.6%" y="-12.8%" filterUnits="objectBoundingBox">
                        <feOffset dy="-2" in="SourceAlpha" result="shadowOffsetOuter1" />
                        <feGaussianBlur in="shadowOffsetOuter1" result="shadowBlurOuter1" stdDeviation="12" />
                        <feColorMatrix in="shadowBlurOuter1" values="0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0.11 0" />
                    </filter>
                    <linearGradient id="d" x1="50%" x2="50%" y1="0%" y2="99.142%">
                        <stop offset="0%" stopColor="var(--red-300)" />
                        <stop offset="100%" stopColor="var(--red-500)" />
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
    );
}

