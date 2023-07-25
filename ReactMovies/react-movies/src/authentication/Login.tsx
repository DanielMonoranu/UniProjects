import axios, { AxiosResponse } from "axios";
import { useContext, useState } from "react";
import { useHistory } from "react-router-dom";
import { urlAccounts } from "../endpoints";
import DisplayErrors from "../utilities/DisplayErrors";
import { authenticationRespone, userCredentials } from "./auth.model";
import AuthenticationContext from "./AuthenticationContext";
import AuthForm from "./AuthForm";
import { getClaims, saveToken } from "./JWTHandler";

export default function Login() {
    const [error, setError] = useState<string>('');
    const { update } = useContext(AuthenticationContext);
    const history = useHistory();

    async function login(credentials: userCredentials) {
        setError('');
        await axios.post<authenticationRespone>(`${urlAccounts}/login`, credentials)
            .then((response: AxiosResponse<any>) => {
                console.log(response.data);
                saveToken(response.data);
                update(getClaims());
                history.push('/');
            })
            .catch(function (error) {
                console.log(error.response.data);
                if (error && error.response) {
                    setError(error.response.data);
                }
            });
    }
    return <>
        <h3>Login</h3>
        <DisplayErrors singleError={error} />
        <AuthForm model={{ email: '', password: '' }} onSubmit={async values => await login(values)} /></>
}

