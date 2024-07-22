import { classNames } from 'primereact/utils';
import React, { useContext, useEffect, useRef } from 'react';
import { Tooltip } from 'primereact/tooltip';
import { LayoutContext } from './context/layoutcontext';
import { useNavigate, useLocation } from 'react-router-dom';
import { Icon } from '../../Common/Icons/Icon';
import AuthService from '../../Helpers/Authentication/AuthService';

const AppMenuProfile = () => {
    const { layoutState, layoutConfig, isSlim, isHorizontal, onMenuProfileToggle } = useContext(LayoutContext);
    const navigate = useNavigate();
    const location = useLocation();
    const ulRef = useRef<HTMLUListElement | null>(null);

    const hiddenClassName = classNames({ hidden: layoutConfig.menuMode === 'drawer' && !layoutState.sidebarActive });

    const toggleMenu = () => {
        if (layoutState.menuProfileActive) {
            setTimeout(() => {
                if (ulRef.current) {
                    ulRef.current.style.maxHeight = '0';
                    ulRef.current.style.opacity = '0';
                    if (isHorizontal()) {
                        ulRef.current.style.transform = 'scaleY(0.8)';
                    }
                }
            }, 1);
        } else {
            setTimeout(() => {
                if (ulRef.current) {
                    ulRef.current.style.maxHeight = ulRef.current.scrollHeight + 'px';
                    ulRef.current.style.opacity = '1';
                    if (isHorizontal()) {
                        ulRef.current.style.transform = 'scaleY(1)';
                    }
                }
            }, 1);
        }
        onMenuProfileToggle();
    };

    useEffect(() => {
        if (layoutState.menuProfileActive) toggleMenu();
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [location]);

    const tooltipValue = (tooltipText: string) => {
        return isSlim() ? tooltipText : null;
    };

    return (
        <React.Fragment>
            <div className="layout-menu-profile">
                <Tooltip target={'.avatar-button'} content={tooltipValue('Profile') as string} />
                <button className="avatar-button p-link border-noround d-flex justify-content-between align-items-center" onClick={toggleMenu}>
                    <span>
                        <strong>Amy Elsner</strong>
                        <small>Webmaster</small>
                    </span>
                    <Icon Name="ChevronDown" Classes="layout-menu-profile-toggler ms-auto" />
                </button>

                <ul ref={ulRef} className={classNames('menu-transition', { overlay: isHorizontal() })} style={{ overflow: 'hidden', maxHeight: 0, opacity: 0 }}>
                    {layoutState.menuProfileActive && (
                        <>
                            <li>
                                <button className="p-link" onClick={() => AuthService.logout}>
                                    <Icon Name="Logout" Classes="pe-5"/>
                                    <span className={hiddenClassName}>Logout</span>
                                </button>
                            </li>
                        </>
                    )}
                </ul>
            </div>
        </React.Fragment>
    );
};

export default AppMenuProfile;
