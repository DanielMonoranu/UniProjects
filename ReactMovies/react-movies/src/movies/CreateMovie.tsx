import axios, { AxiosResponse } from "axios";
import { FormikHelpers } from "formik";
import { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { urlMovies } from "../endpoints";
import { genreDTO } from "../genres/genres.model";
import { movieTheaterDTO } from "../movieTheaters/movieTheater.model";
import { convertMovieToFormData } from "../utilities/formDataConvert";
import Loading from "../utilities/Loading";
import MovieForm from "./MovieForm";
import { movieCreationDTO, moviesPostGetDTO } from "./movies.model";

export default function CreateMovie() {
    const [nonSelectedGenres, setNonSelectedGenres] = useState<genreDTO[]>([]);
    const [nonSelectedMovieTheaters, setNonSelectedMovieTheaters] = useState<movieTheaterDTO[]>([]);
    const [loading, setLoading] = useState(true);
    const history = useHistory();
    const [errors, setErrors] = useState<string[]>([]);

    useEffect(() => {
        axios.get(`${urlMovies}/postget`)
            .then((response: AxiosResponse<moviesPostGetDTO>) => {
                setNonSelectedGenres(response.data.genres);
                setNonSelectedMovieTheaters(response.data.movieTheaters);
                setLoading(false);
            })
    }, []);

    async function Create(movie: movieCreationDTO) {
        try {
            const formData = convertMovieToFormData(movie);
            const response = await axios({
                method: 'post',
                url: urlMovies,
                data: formData,
                headers: { 'Content-Type': 'multipart/form-data' }
            })
            history.push(`/movie/${response.data}`);
        } catch (error) {
            console.log(error);

        }
    }


    return (
        <>
            <h3>Create Movie</h3>

            {loading ? <Loading /> :
                <MovieForm model={{ title: "", inTheaters: false, trailer: '' }}
                    onSubmit={async values => await Create(values)}
                    nonSelectedGenres={nonSelectedGenres}
                    selectedGenres={[]}
                    nonSelectedMovieTheaters={nonSelectedMovieTheaters}
                    selectedMovieTheaters={[]}
                    selectedActors={[]} />}

        </>);

};