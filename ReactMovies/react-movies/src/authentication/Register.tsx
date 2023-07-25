import axios, { AxiosResponse } from "axios";
import { FormikHelpers } from "formik";
import { useContext, useState } from "react";
import { useHistory } from "react-router-dom";
import { urlAccounts } from "../endpoints";
import DisplayErrors from "../utilities/DisplayErrors";
import { authenticationRespone, userCredentials } from "./auth.model";
import AuthenticationContext from "./AuthenticationContext";
import AuthForm from "./AuthForm";
import { getClaims, saveToken } from "./JWTHandler";

export default function Register() {
    const [errors, setErrors] = useState<[]>([]);
    const { update } = useContext(AuthenticationContext);
    const history = useHistory();

    async function register(credentials: userCredentials) {

        await axios.post<authenticationRespone>(`${urlAccounts}/create`, credentials)
            .then((response: AxiosResponse<any>) => {
                console.log(response.data);
                saveToken(response.data);
                update(getClaims());
                history.push('/');
            })
            .catch(function (error) {
                console.log(error.response.data);
                if (error && error.response) {
                    //setErrors(error.response.data);
                }
            });
    }

    return <>
        <h3>Register</h3>
        <DisplayErrors errors={errors} />
        <AuthForm model={{ email: '', password: '' }}
            onSubmit={async values => await register(values)}></AuthForm>
    </>
}