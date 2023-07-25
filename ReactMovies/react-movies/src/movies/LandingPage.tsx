import axios, { AxiosResponse } from "axios";
import { useEffect, useState } from "react";
import Authorized from "../authentication/Authorized";
import { urlMovies } from "../endpoints";
import AlertContext from "../utilities/AlertContext";
import { landingPageDto } from "./movies.model";
import MoviesList from "./MoviesList";

export default function LandingPage() {
    const [movies, setMovies] = useState<landingPageDto>({});

    useEffect(() => {
        loadData()
    }, []);


    function loadData() {
        axios.get(urlMovies).then((response: AxiosResponse<landingPageDto>) => {
            setMovies(response.data);
        })
    }

    return (
        <AlertContext.Provider value={() => {
            loadData();
        }}>
            <h3>In Theaters:</h3>
            <MoviesList movies={movies.inTheaters} />

            <h3>Upcoming Releases:</h3>
            <MoviesList movies={movies.upcomingReleases} />
        </AlertContext.Provider >
    );
}