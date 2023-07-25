import CreateActor from "./actors/CreateActor";
import CreateGenre from "./genres/CreateGenre";
import EditActor from "./actors/EditActor";
import EditGenre from "./genres/EditGenre";
import IndexGenres from "./genres/IndexGenres";
import CreateMovie from "./movies/CreateMovie";
import EditMovie from "./movies/EditMovie";
import FilterMovies from "./movies/FilterMovies";
import LandingPage from "./movies/LandingPage";
import CreateMovieTheater from "./movieTheaters/CreateMovieTheater";
import EditMovieTheater from "./movieTheaters/EditMovieTheater";
import IndexMovieTheaters from "./movieTheaters/IndexMovieTheaters";
import RedirectToLandingPage from "./utilities/RedirectToLandingPage";
import IndexActor from "./actors/IndexActor";
import MovieDetails from "./movies/MovieDetails";
import Register from "./authentication/Register";
import Login from "./authentication/Login";
import IndexUsers from "./authentication/IndexUsers";

const routes = [
    { path: "/", component: LandingPage, exact: true, },

    { path: "/genres", component: IndexGenres, exact: true, isAdmin: true },
    { path: "/genres/create", component: CreateGenre, isAdmin: true },
    { path: "/genres/edit/:id(\\d+)", component: EditGenre, isAdmin: true },

    { path: "/actors", component: IndexActor, exact: true, isAdmin: true },
    { path: "/actors/create", component: CreateActor, isAdmin: true },
    { path: "/actors/edit/:id(\\d+)", component: EditActor, isAdmin: true },

    { path: "/movietheaters", component: IndexMovieTheaters, exact: true, isAdmin: true },
    { path: "/movietheaters/create", component: CreateMovieTheater, isAdmin: true },
    { path: "/movietheaters/edit/:id(\\d+)", component: EditMovieTheater, isAdmin: true },

    { path: "/movies/create", component: CreateMovie, isAdmin: true },
    { path: "/movies/edit/:id(\\d+)", component: EditMovie, isAdmin: true },
    { path: "/movies/filter", component: FilterMovies },
    { path: "/movie/:id(\\d+)", component: MovieDetails }, // \\d+ = number

    { path: "/register", component: Register },
    { path: "/login", component: Login },
    { path: "/users", component: IndexUsers, isAdmin: true },

    { path: "*", component: RedirectToLandingPage },
];
export default routes;