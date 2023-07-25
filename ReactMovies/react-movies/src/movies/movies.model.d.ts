import { actorMovieDTO } from "../actors/actors.model";
import { genreDTO } from "../genres/genres.model";
import { movieTheaterDTO } from "../movieTheaters/movieTheater.model";

export interface movieDto {
    id: number;
    title: string;
    poster: string;
    inTheaters: boolean;
    trailer: string;
    releaseDate: Date;
    summary?: string;
    genres: genreDTO[];
    moviesTheaters: movieTheaterDTO[];
    actors: actorMovieDTO[];
    userVote: number;
    averageVote: number;
}

export interface movieCreationDTO {
    summary?: string;
    title: string;
    inTheaters: boolean;
    trailer: string;
    releaseDate?: Date;
    poster?: File;
    posterURL?: string;
    genresIds?: number[];
    movieTheatersIds?: number[];
    selectedActors?: actorMovieDTO[];
}

export interface landingPageDto {
    inTheaters?: movieDto[];
    upcomingReleases?: movieDto[];
}

export interface moviesPostGetDTO {  //pt cand primesc toate genres si movie theaters
    genres: genreDTO[];
    movieTheaters: movieTheaterDTO[];
}

export interface moviesPutGetDTO { //pt actualizat un film
    movie: movieDto,
    selectedGenres: genreDTO[];
    nonSelectedGenres: genreDTO[];
    selectedMovieTheaters: movieTheaterDTO[];
    nonSelectedMovieTheaters: movieTheaterDTO[];
    actors: actorMovieDTO[];
}