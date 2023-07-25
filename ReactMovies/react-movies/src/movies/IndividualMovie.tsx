import { movieDto } from "./movies.model";
import css from './IndividualMovie.module.css';
import { Link } from "react-router-dom";
import Button from "../utilities/Button";
import customConfirm from "../utilities/customConfirm";
import axios from "axios";
import { urlMovies } from "../endpoints";
import { useContext } from "react";
import AlertContext from "../utilities/AlertContext";
import Authorized from "../authentication/Authorized";

export default function IndividualMovie(props: movieDto) {

    const buildPictureLink = () => `/movie/${props.id}`
    const customAlert = useContext(AlertContext);

    function deleteMovie() {
        axios.delete(`${urlMovies}/${props.id}`)
            .then(() => {
                customAlert();
            });
    }

    return (
        <>
            <div className={css.div}>
                <Link to={buildPictureLink()}>
                    <img alt="Poster" src={props.poster} />
                </Link>
                <p>
                    <Link to={buildPictureLink()}>
                        {props.title}
                    </Link>
                </p>
                <Authorized role="admin" authorized={
                    <div>
                        <Link style={{ marginRight: '1rem' }}
                            className="btn btn-info" to={`/movies/edit/${props.id}`}>
                            Edit
                        </Link>
                        <Button className="btn btn-danger" onClick={() =>
                            customConfirm(() => deleteMovie())}
                        >Delete</Button>
                    </div>
                } />
            </div>
        </>
    )
}