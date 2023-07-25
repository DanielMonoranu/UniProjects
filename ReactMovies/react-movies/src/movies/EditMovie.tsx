import axios, { AxiosResponse } from "axios";
import { useEffect, useState } from "react";
import { useHistory, useParams } from "react-router-dom";
import { actorMovieDTO } from "../actors/actors.model";
import { urlMovies } from "../endpoints";
import { genreDTO } from "../genres/genres.model";
import DisplayErrors from "../utilities/DisplayErrors";
import { convertMovieToFormData } from "../utilities/formDataConvert";
import Loading from "../utilities/Loading";
import MovieForm from "./MovieForm";
import { movieCreationDTO, moviesPutGetDTO } from "./movies.model";

export default function EditMovie() {
    const { id }: any = useParams();
    const [movie, setMovie] = useState<movieCreationDTO>();
    const [moviePutGet, setMoviePutGet] = useState<moviesPutGetDTO>();
    const history = useHistory();
    const [errors, setErrors] = useState<string[]>([]);

    useEffect(() => {
        axios.get(`${urlMovies}/PutGet/${id}`)
            .then((response: AxiosResponse<moviesPutGetDTO>) => {
                const model: movieCreationDTO = {
                    title: response.data.movie.title,
                    inTheaters: response.data.movie.inTheaters,
                    trailer: response.data.movie.trailer,
                    posterURL: response.data.movie.poster,
                    summary: response.data.movie.summary,
                    releaseDate: new Date(response.data.movie.releaseDate),
                };
                setMovie(model);
                setMoviePutGet(response.data);
            })
    }, [id]);


    async function Edit(movieToEdit: movieCreationDTO) {
        const formData = convertMovieToFormData(movieToEdit);
        await axios({
            method: 'put',
            url: `${urlMovies}/${id}`,
            data: formData,
            headers: { 'Content-Type': 'multipart/form-data' }
        }).then(() => { history.push(`/movie/${id}`) })
            .catch((error) => {
                if (error && error.response) {
                    setErrors(error.response.data);
                }
            })
    }


    return (
        <>
            <h3>Edit Movie</h3>
            <DisplayErrors errors={errors} />
            {movie && moviePutGet ? <MovieForm model={movie}
                onSubmit={async movie => await Edit(movie)}
                nonSelectedGenres={moviePutGet.nonSelectedGenres}
                selectedGenres={moviePutGet.selectedGenres}
                selectedMovieTheaters={moviePutGet.selectedMovieTheaters}
                nonSelectedMovieTheaters={moviePutGet.nonSelectedMovieTheaters}
                selectedActors={moviePutGet.actors} /> : <Loading />}

        </>);

};