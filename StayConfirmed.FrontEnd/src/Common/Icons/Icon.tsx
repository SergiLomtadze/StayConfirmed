import React, { useState, useEffect } from 'react';

interface IconProps {
    Name: string;
    Classes: string | null;
}

interface IconsData {
    [key: string]: { value: string };
}

export const Icon: React.FC<IconProps> = ({ Name, Classes = null }) => {
    const [icons, setIcons] = useState<IconsData | null>(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchIcons = async () => {
            try {
                const response = await fetch('/Icons.json');
                if (!response.ok) {
                    throw new Error(`Failed to fetch icons: ${response.statusText}`);
                }
                const data: IconsData = await response.json();
                setIcons(data);
            } catch (err) {
                setError(err.message);
            } finally {
                setLoading(false);
            }
        };

        fetchIcons();
    }, []);

    if (loading) return <span>Loading...</span>;
    if (error) return <span>Error: {error}</span>;

    const icon = icons?.[Name] || { value: Name };

    return (
        <span className={"material-symbols-outlined " + Classes}>
            {icon.value}
        </span>
    );
};
