import { forwardRef, useContext, useImperativeHandle, useRef } from 'react';
import { Link } from 'react-router-dom';
import { LayoutContext } from './context/layoutcontext';
import { Ripple } from 'primereact/ripple';
import { Icon } from '../../Common/Icons/Icon';
import { getConfig } from '../../Helpers/ConfigHelper';
import { Paths } from '../../Common/Paths';

const AppTopbar = forwardRef<AppTopbarRef>((props, ref) => {
    const { onMenuToggle, onTopbarMenuToggle } = useContext(LayoutContext);
    const menubuttonRef = useRef<HTMLAnchorElement>(null);
    const mobileButtonRef = useRef<HTMLAnchorElement>(null);
    const config = getConfig();

    const onMenuButtonClick = () => {
        onMenuToggle();
    };

    const onMobileTopbarMenuButtonClick = () => {
        onTopbarMenuToggle();
    };

    useImperativeHandle(ref, () => ({
        menubutton: menubuttonRef.current
    }));

    return (
        <div className="layout-topbar">
            <div className="layout-topbar-start">
                <Link className="layout-topbar-logo" to="/">
                    <img src={config.CDN + Paths.LogoFull.value} alt="logo" style={{ width:"14rem"}} />
                </Link>
                <a ref={menubuttonRef} className="p-ripple layout-menu-button" onClick={onMenuButtonClick}>
                    <Icon Name="Menu" />
                    <Ripple />
                </a>

                <a ref={mobileButtonRef} className="p-ripple layout-topbar-mobile-button" onClick={onMobileTopbarMenuButtonClick}>
                    <Icon Name="Menu" />
                    <Ripple />
                </a>
            </div>

            <div className="layout-topbar-end">
                <div className="layout-topbar-actions-end">
                    <ul className="layout-topbar-items">
                        {/*<li className="layout-topbar-search">*/}
                        {/*    <input type="text" placeholder="Search" />*/}
                        {/*    <Icon Name="Menu" />*/}
                        {/*</li>*/}
                        {/*<li>*/}
                        {/*    <StyleClass nodeRef={bellRef} selector="@next" enterClassName="hidden" enterActiveClassName="px-scalein" leaveToClassName="hidden" leaveActiveClassName="px-fadeout" hideOnOutsideClick>*/}
                        {/*        <a className="p-ripple" ref={bellRef}>*/}
                        {/*            <Icon Name="Notifications" />*/}
                        {/*            <Ripple />*/}
                        {/*        </a>*/}
                        {/*    </StyleClass>*/}
                        {/*    <div className="hidden">*/}
                        {/*        <ul className="list-none p-0 m-0">*/}
                        {/*            <li>*/}
                        {/*                <a className="py-2 px-3 flex gap-2 cursor-pointer text-color hover:text-primary">*/}
                        {/*                    <i className="pi pi-fw pi-sliders-h text-lg"></i>*/}
                        {/*                    <span>Pending tasks</span>*/}
                        {/*                </a>*/}
                        {/*            </li>*/}
                        {/*            <li>*/}
                        {/*                <a className="py-2 px-3 flex gap-2 cursor-pointer text-color hover:text-primary">*/}
                        {/*                    <i className="pi pi-fw pi-calendar text-lg"></i>*/}
                        {/*                    <span>Meeting today at 3pm</span>*/}
                        {/*                </a>*/}
                        {/*            </li>*/}
                        {/*            <li>*/}
                        {/*                <a className="py-2 px-3 flex gap-2 cursor-pointer text-color hover:text-primary">*/}
                        {/*                    <i className="pi pi-fw pi-download text-lg"></i>*/}
                        {/*                    <span>Download documents</span>*/}
                        {/*                </a>*/}
                        {/*            </li>*/}
                        {/*            <li>*/}
                        {/*                <a className="py-2 px-3 flex gap-2 cursor-pointer text-color hover:text-primary">*/}
                        {/*                    <i className="pi pi-fw pi-bookmark text-lg"></i>*/}
                        {/*                    <span>Book flight</span>*/}
                        {/*                </a>*/}
                        {/*            </li>*/}
                        {/*        </ul>*/}
                        {/*    </div>*/}
                        {/*</li>*/}
                        {/*<li>*/}
                        {/*    <StyleClass nodeRef={tableRef} selector="@next" enterClassName="hidden" enterActiveClassName="px-scalein" leaveToClassName="hidden" leaveActiveClassName="px-fadeout" hideOnOutsideClick>*/}
                        {/*        <a className="p-ripple" ref={tableRef}>*/}
                        {/*            <i className="pi pi-envelope"></i>*/}
                        {/*            <Ripple />*/}
                        {/*        </a>*/}
                        {/*    </StyleClass>*/}
                        {/*    <div className="hidden">*/}
                        {/*        <ul className="list-none p-0 m-0 flex flex-column text-color">*/}
                        {/*            <li>*/}
                        {/*                <a className="cursor-pointer flex align-items-center px-3 py-2 gap-3 hover:text-primary">*/}
                        {/*                    <img src="/layout/images/avatar/avatar5.png" className="w-3rem h-3rem" alt="avatar5" />*/}
                        {/*                    <span>Give me a call</span>*/}
                        {/*                </a>*/}
                        {/*            </li>*/}
                        {/*            <li>*/}
                        {/*                <a className="cursor-pointer flex align-items-center px-3 py-2 gap-3 hover:text-primary">*/}
                        {/*                    <img src="/layout/images/avatar/avatar1.png" className="w-3rem h-3rem" alt="avatar1" />*/}
                        {/*                    <span>Sales reports attached</span>*/}
                        {/*                </a>*/}
                        {/*            </li>*/}
                        {/*            <li>*/}
                        {/*                <a className="cursor-pointer flex align-items-center px-3 py-2 gap-3 hover:text-primary">*/}
                        {/*                    <img src="/layout/images/avatar/avatar2.png" className="w-3rem h-3rem" alt="avatar2" />*/}
                        {/*                    <span>About your invoice</span>*/}
                        {/*                </a>*/}
                        {/*            </li>*/}
                        {/*            <li>*/}
                        {/*                <a className="cursor-pointer flex align-items-center px-3 py-2 gap-3 hover:text-primary">*/}
                        {/*                    <img src="/layout/images/avatar/avatar3.png" className="w-3rem h-3rem" alt="avatar3" />*/}
                        {/*                    <span>Meeting today at 10pm</span>*/}
                        {/*                </a>*/}
                        {/*            </li>*/}
                        {/*            <li>*/}
                        {/*                <a className="cursor-pointer flex align-items-center px-3 py-2 gap-3 hover:text-primary">*/}
                        {/*                    <img src="/layout/images/avatar/avatar4.png" className="w-3rem h-3rem" alt="avatar4" />*/}
                        {/*                    <span>Out of office</span>*/}
                        {/*                </a>*/}
                        {/*            </li>*/}
                        {/*        </ul>*/}
                        {/*    </div>*/}
                        {/*</li>*/}
                        {/*<li>*/}
                        {/*    <StyleClass nodeRef={avatarRef} selector="@next" enterClassName="hidden" enterActiveClassName="px-scalein" leaveToClassName="hidden" leaveActiveClassName="px-fadeout" hideOnOutsideClick>*/}
                        {/*        <a className="p-ripple" ref={avatarRef}>*/}
                        {/*            <i className="pi pi-cog"></i> <Ripple />*/}
                        {/*        </a>*/}
                        {/*    </StyleClass>*/}
                        {/*    <div className="hidden">*/}
                        {/*        <ul className="list-none p-0 m-0">*/}
                        {/*            <li>*/}
                        {/*                <a className="py-2 px-3 flex gap-2 cursor-pointer text-color hover:text-primary">*/}
                        {/*                    <i className="pi pi-fw pi-palette text-lg"></i>*/}
                        {/*                    <span>Change Theme</span>*/}
                        {/*                </a>*/}
                        {/*            </li>*/}
                        {/*            <li>*/}
                        {/*                <a className="py-2 px-3 flex gap-2 cursor-pointer text-color hover:text-primary">*/}
                        {/*                    <i className="pi pi-fw pi-star text-lg"></i>*/}
                        {/*                    <span>Favorites</span>*/}
                        {/*                </a>*/}
                        {/*            </li>*/}
                        {/*            <li>*/}
                        {/*                <a className="py-2 px-3 flex gap-2 cursor-pointer text-color hover:text-primary">*/}
                        {/*                    <i className="pi pi-fw pi-lock text-lg"></i>*/}
                        {/*                    <span>Lock Screen</span>*/}
                        {/*                </a>*/}
                        {/*            </li>*/}
                        {/*            <li>*/}
                        {/*                <a className="py-2 px-3 flex gap-2 cursor-pointer text-color hover:text-primary">*/}
                        {/*                    <i className="pi pi-fw pi-image text-lg"></i>*/}
                        {/*                    <span>Wallpaper</span>*/}
                        {/*                </a>*/}
                        {/*            </li>*/}
                        {/*        </ul>*/}
                        {/*    </div>*/}
                        {/*</li>*/}
                    </ul>
                </div>
            </div>
        </div>
    );
});

AppTopbar.displayName = 'AppTopbar';

export default AppTopbar;
