import { Form, Formik, FormikHelpers } from "formik";
import { Link } from "react-router-dom";
import TextField from "../forms/TextField";
import Button from "../utilities/Button";
import { actorCreationDto } from "./actors.model";
import * as Yup from 'yup';
import DateField from "../forms/DateField";
import ImageField from "../forms/ImageField";
import MarkdownField from "../forms/MarkdownField";


export default function ActorForm(props: actorFormProps) {
    return (
        <Formik initialValues={props.model}
            onSubmit={props.onSubmit}
            validationSchema={Yup.object({
                name: Yup.string().required("This field is required").firstLetterUpercase(),
                dateOfBirth: Yup.date().nullable().required("This field is required")
            })}>

            {(formikProps) => (
                <Form>
                    <TextField field="name" displayName="Name" />
                    <DateField field="dateOfBirth" displayName="Date of Birth" />
                    <ImageField field="picture" displayName="Picture" imageUrl={props.model.pictureURL} />

                    <MarkdownField displayName="Biography" field="biography" />

                    <Button disabled={formikProps.isSubmitting} type="submit">Save Changes</Button>
                    <Link to="/actors" className="btn btn-secondary">Cancel</Link>
                </Form>
            )}
        </Formik>
    )
}

interface actorFormProps {
    model: actorCreationDto;
    onSubmit(values: actorCreationDto, action: FormikHelpers<actorCreationDto>): void;
}