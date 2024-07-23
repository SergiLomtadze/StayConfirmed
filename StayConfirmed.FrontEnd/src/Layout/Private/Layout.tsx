import React, { useCallback, useContext, useRef } from 'react';
import { LayoutContext } from './context/layoutcontext';
import { classNames} from 'primereact/utils';
import { useMountEffect, useUnmountEffect } from 'primereact/hooks';
import { PrimeReactContext } from 'primereact/api';
import AppSidebar from './AppSidebar';
import AppTopbar from './AppTopbar';

const Layout = (props: ChildContainerProps) => {
    const { layoutConfig, layoutState, setLayoutState} = useContext(LayoutContext);
    const { setRipple } = useContext(PrimeReactContext);
    const topbarRef = useRef<AppTopbarRef>(null);
    const sidebarRef = useRef<HTMLDivElement>(null);
    const timeoutRef = useRef<NodeJS.Timeout | null>(null);

    useMountEffect(() => {
        setRipple?.(layoutConfig.ripple);
    });

    const onMouseEnter = useCallback(() => {
        if (!layoutState.anchored) {
            if (timeoutRef.current) {
                clearTimeout(timeoutRef.current);
                timeoutRef.current = null;
            }
            setLayoutState((prevLayoutState) => ({
                ...prevLayoutState,
                sidebarActive: true
            }));
        }
    }, [layoutState.anchored, setLayoutState]);

    const onMouseLeave = useCallback(() => {
        if (!layoutState.anchored) {
            if (!timeoutRef.current) {
                timeoutRef.current = setTimeout(() => {
                    setLayoutState((prevLayoutState) => ({
                        ...prevLayoutState,
                        sidebarActive: false
                    }));
                }, 300);
            }
        }
    }, [layoutState.anchored, setLayoutState]);

    useUnmountEffect(() => {
        if (timeoutRef.current) {
            clearTimeout(timeoutRef.current);
        }
    });

    const containerClassName = classNames('layout-topbar-' + layoutConfig.topbarTheme, 'layout-menu-' + layoutConfig.menuTheme, 'layout-menu-profile-' + layoutConfig.menuProfilePosition, {
        'layout-overlay': layoutConfig.menuMode === 'overlay',
        'layout-static': layoutConfig.menuMode === 'static',
        'layout-slim': layoutConfig.menuMode === 'slim',
        'layout-slim-plus': layoutConfig.menuMode === 'slim-plus',
        'layout-horizontal': layoutConfig.menuMode === 'horizontal',
        'layout-reveal': layoutConfig.menuMode === 'reveal',
        'layout-drawer': layoutConfig.menuMode === 'drawer',
        'p-input-filled': layoutConfig.inputStyle === 'filled',
        'layout-sidebar-dark': layoutConfig.colorScheme === 'dark',
        'p-ripple-disabled': !layoutConfig.ripple,
        'layout-static-inactive': layoutState.staticMenuDesktopInactive && layoutConfig.menuMode === 'static',
        'layout-overlay-active': layoutState.overlayMenuActive,
        'layout-mobile-active': layoutState.staticMenuMobileActive,
        'layout-topbar-menu-active': layoutState.topbarMenuActive,
        'layout-menu-profile-active': layoutState.menuProfileActive,
        'layout-sidebar-active': layoutState.sidebarActive,
        'layout-sidebar-anchored': layoutState.anchored
    });

    return (
        <React.Fragment>
            <div className={classNames('layout-container', containerClassName)}>
                <AppTopbar ref={topbarRef} />
                <div ref={sidebarRef} className="layout-sidebar" onMouseEnter={onMouseEnter} onMouseLeave={onMouseLeave}>
                    <AppSidebar />
                </div>
                <div className="layout-content-wrapper">
                    <div>
                        <div className="layout-content">{props.children}</div>
                    </div>
                </div>
            </div>
        </React.Fragment>
    );
};

export default Layout;
