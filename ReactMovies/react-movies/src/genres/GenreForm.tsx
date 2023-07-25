import { Form, Formik, FormikHelpers } from "formik";
import Button from "../utilities/Button";
import * as Yup from 'yup';
import TextField from "../forms/TextField";
import { Link } from "react-router-dom";
import { genreCreationDTO } from "./genres.model";


export default function GenreForm(props: genreFormProps) {

    return (<Formik initialValues={props.model}
        onSubmit={props.onSubmit}
        validationSchema={Yup.object({
            name: Yup.string().required("This field is required").max(50, "Max length is 50 characters")
                .firstLetterUpercase()
        })}>

        {(formikProps) => (
            <Form>
                <TextField field="name" displayName="Name"></TextField>
                <Button disabled={formikProps.isSubmitting} type="submit">Save Changes</Button>

                <Link className="btn btn-socondary" to="/genres" >Cancel</Link>
            </Form>
        )}

    </Formik >)
}

interface genreFormProps {
    model: genreCreationDTO;
    onSubmit(values: genreCreationDTO, action: FormikHelpers<genreCreationDTO>): void;
}