import axios from "axios";
import { useState } from "react";
import { useHistory } from "react-router-dom";
import { urlMovieTheaters } from "../endpoints";
import DisplayErrors from "../utilities/DisplayErrors";
import { movieTheaterCreationDTO } from "./movieTheater.model";
import MovieTheaterForm from "./MovieTheaterFrom";

export default function CreateMovieTheater() {
    const history = useHistory();
    const [errors, setErrors] = useState<string[]>([]);

    async function Create(movieTheater: movieTheaterCreationDTO) {
        await axios.post(urlMovieTheaters, movieTheater)
            .then(function () { history.push('/movietheaters'); })
            .catch(function (error) {
                if (error && error.response) {
                    setErrors(error.response.data);
                    console.log(error)
                }
            });

    }
    return (
        <>
            <h3>Create Movie Theater</h3>
            {/* <DisplayErrors errors={errors} /> */}
            <MovieTheaterForm
                model={{ name: '' }}
                onSubmit={async values => await Create(values)}
            />
        </>

    )

}