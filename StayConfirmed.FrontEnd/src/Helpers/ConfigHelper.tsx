export interface Config {
    APIUrl: string;
    CDN: string;
}

let config: Config | null = null;

export const loadConfig = async (): Promise<void> => {
    const response = await fetch('/Configs.json');
    if (!response.ok) {
        throw new Error(`Failed to fetch configuration: ${response.statusText}`);
    }
    config = await response.json();
};

export const getConfig = (): Config => {
    if (!config) {
        throw new Error('Configuration has not been loaded');
    }
    return config;
};
