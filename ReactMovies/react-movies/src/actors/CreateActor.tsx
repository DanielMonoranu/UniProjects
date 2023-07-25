import axios from "axios";
import { FormikHelpers } from "formik";
import { useState } from "react";
import { useHistory } from "react-router-dom";
import { urlActors } from "../endpoints";
import DisplayErrors from "../utilities/DisplayErrors";
import { convertActorToFormData } from "../utilities/formDataConvert";
import ActorForm from "./ActorForm";
import { actorCreationDto } from "./actors.model";

export default function CreateActor() {
    const [errors, setErrors] = useState<string[]>([]);
    const history = useHistory();

    async function Create(actor: actorCreationDto) {

        const formData = convertActorToFormData(actor);
        await axios({
            method: 'post', url: urlActors,
            data: formData,
            headers: { 'Content-Type': 'multipart/form-data' }
        }).then(function () { history.push('/actors'); }).catch(function (error) {
            console.log(error.response.data);
            if (error && error.response) {
                setErrors(error.response.data);
                console.log(error.response.data);
            }
        });
    }


    return (
        <>
            <h3>Create Actor</h3>
            <DisplayErrors errors={errors} />
            <ActorForm model={{
                name: '',
                dateOfBirth: undefined,
            }}
                onSubmit={async values => await Create(values)}
            />

        </>

    )

}