import React from 'react';
import { Icons } from './Icons';

interface IconProps {
    Name: string;
}

export const Icon: React.FC<IconProps> = ({ Name }) => {
    const icon = Icons[Name] || { value: Name };


    return (
        <span className="material-symbols-outlined">
            {icon.value}
        </span>
    );
};
