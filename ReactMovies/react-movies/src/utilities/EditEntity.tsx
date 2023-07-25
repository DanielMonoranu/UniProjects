import axios, { AxiosResponse } from "axios";
import { useEffect, useState } from "react";
import { ReactElement } from "react-markdown/lib/react-markdown";
import { useHistory, useParams } from "react-router-dom";
import DisplayErrors from "./DisplayErrors";
import Loading from "./Loading";

export default function EditEntity<TCreation, TRead>
    (props: editEntityProps<TCreation, TRead>) {

    const history = useHistory();
    const { id }: any = useParams();  //sa luam din link
    const [entity, setEntity] = useState<TCreation>();
    const [errors, setErrors] = useState<string[]>([]);

    useEffect(() => {
        axios.get(`${props.url}/${id}`)
            .then((response: AxiosResponse<TRead>) => {
                setEntity(props.transform(response.data));
            })
    }, [id]);

    async function edit(entityToEdit: TCreation) {
        if (props.transformFormData) {
            const formData = props.transformFormData(entityToEdit);
            await axios({
                method: 'put',
                url: `${props.url}/${id}`,
                data: formData,
                headers: { 'Content-Type': 'multipart/form-data' }
            }).then(function () {
                history.push(props.indexURL);
            })
                .catch(function (error) {
                    if (error && error.response) {
                        console.log(entityToEdit);

                        setErrors(error.response.data);
                    }
                });
        } else {
            await axios.put(`${props.url}/${id}`, entityToEdit)
                .then(function () { history.push(props.indexURL); })
                .catch(function (error) {
                    if (error && error.response) {
                        console.log(props.transformFormData);
                        setErrors(error.response.data);
                    }
                })
        }

    }

    return (<>
        <h3>Edit {props.entityName}</h3>
        <DisplayErrors errors={errors} />
        {entity ? props.children(entity, edit) : <Loading />}
    </>

    )
}
interface editEntityProps<TCreation, TRead> {
    entityName: string;
    url: string;
    indexURL: string;
    transform(entity: TRead): TCreation;
    transformFormData?(model: TCreation): FormData;  //doar pt actor, nu si pt genre avem nevoie de form
    children(entity: TCreation, edit: (entity: TCreation) => void): ReactElement;
}

EditEntity.defaultProps = {
    transform: (entity: any) => entity
}