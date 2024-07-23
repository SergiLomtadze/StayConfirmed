import AppSubMenu from './AppSubMenu';
import type { MenuModel } from '@/types';

const AppMenu = () => {
    const model: MenuModel[] = [
        {
            label: 'Favorites',
            icon: null,
            items: [
                {
                    label: 'Dashboards',
                    icon: null,
                    items: [
                        {
                            label: 'E-Commerce',
                            icon: null,
                            to: '/'
                        },
                        {
                            label: 'Banking',
                            icon: null,
                            to: '/dashboards/banking'
                        }
                    ]
                }
            ]
        }
    ];

    return <AppSubMenu model={model} />;
};

export default AppMenu;
