import { authenticationRespone, claim } from "./auth.model";

const tokenKey = 'token';
const expirationKey = 'token-expiration';


export function saveToken(authData: authenticationRespone) {
    localStorage.setItem(tokenKey, authData.token);
    localStorage.setItem(expirationKey, authData.expiration.toString());
}

export function getClaims(): claim[] {
    const token = localStorage.getItem(tokenKey);
    if (!token) return [];
    const expiration = localStorage.getItem(expirationKey)!;

    const expirationDate = new Date(expiration)

    if (expirationDate <= new Date()) {
        logout();
        return []; //token has expired
    }
    const dataToken = JSON.parse(atob(token.split('.')[1])); //1=middle part of the token
    const response: claim[] = [];
    for (const property in dataToken) {
        response.push({ name: property, value: dataToken[property] });
    }
    return response;
}

export function logout() {
    localStorage.removeItem(tokenKey);
    localStorage.removeItem(expirationKey);
}

export function getToken() {
    return localStorage.getItem(tokenKey);
}