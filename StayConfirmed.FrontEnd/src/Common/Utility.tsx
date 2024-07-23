import * as jsvat from 'jsvat';

export const validateVAT = async (value: string) => {
    const vatNumberWithCountryCode = `IT${value}`; // Assuming FI for Finland as an example
    const result = jsvat.checkVAT(vatNumberWithCountryCode, jsvat.countries);
    return result.isValid;
};

export const validateEmail = (email: string): boolean => {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
};

export const validatePassword = (password: string): boolean => {
    const minLength = 6;
    const hasUpperCase = /[A-Z]/.test(password);
    const hasLowerCase = /[a-z]/.test(password);
    const hasDigit = /\d/.test(password);
    const hasNonAlphanumeric = /[\W_]/.test(password); // Matches any non-word character or underscore

    return password.length >= minLength && hasUpperCase && hasLowerCase && hasDigit && hasNonAlphanumeric;
};