import axios from "axios";
import { ErrorMessage, Field, Form, Formik } from "formik";
import { useState } from "react";
import { Link, useHistory } from "react-router-dom";
import { urlGenres } from "../endpoints";
import DisplayErrors from "../utilities/DisplayErrors";
import GenreForm from "./GenreForm";
import { genreCreationDTO } from "./genres.model";


export default function CreateGenre() {
    const history = useHistory();
    const [errors, setErrors] = useState<string[]>([]);

    async function create(genre: genreCreationDTO) {
        await axios.post(urlGenres, genre).then(function () { history.push('/genres'); })
            .catch(function (error) {
                console.error(error);
                if (error && error.response) {
                    setErrors(error.response.data);
                }
            });
    }

    return (
        <>
            <h3>Create Genre</h3>
            <DisplayErrors errors={errors} />
            <GenreForm model={{ name: "" }}
                onSubmit={async value => {
                    //when the form is posted
                    await create(value);
                    console.log(value);
                }}
            />



        </>

    )

}