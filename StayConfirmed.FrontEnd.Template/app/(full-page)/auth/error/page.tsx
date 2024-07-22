'use client';
import { useRouter } from 'next/navigation';
import { Button } from 'primereact/button';
import React from 'react';

import type { Page } from '@/types';

const Error: Page = () => {
    const router = useRouter();
    const navigateToDashboard = () => {
        router.push('/');
    };

    return (
        <>
            <div
                className="overflow-hidden m-0 relative h-screen bg-cover bg-center"
                style={{
                    backgroundImage: 'url(/layout/images/pages/exception/bg-access.png)'
                }}
            >
                <div className="text-center text-5xl pt-5 font-bold text-0">
                    <div className="inline-block py-1 px-2 text-900 surface-ground">
                        <span>Error</span>
                    </div>
                    <span>Occured</span>
                </div>
                <div className="w-full absolute bottom-0 text-center surface-900 h-14rem">
                    <div className="w-full absolute text-center z-1" style={{ top: '-36px' }}>
                        <img src="/layout/images/pages/exception/icon-error.png" alt="avalon-react" />
                    </div>
                    <div className="w-29rem relative text-white" style={{ marginLeft: '-200px', left: '50%', top: '30px' }}>
                        <div className="p-3">
                            <h3 className="m-0 mb-2 text-0">An error occured.</h3>
                            <p className="m-0 text-0">Please contact system administrator.</p>
                        </div>
                        <Button onClick={navigateToDashboard} label="Go To Dashboard"></Button>
                    </div>
                </div>
            </div>{' '}
        </>
    );
};

export default Error;