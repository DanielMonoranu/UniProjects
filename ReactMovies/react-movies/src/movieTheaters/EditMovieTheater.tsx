import { ReactElement, JSXElementConstructor } from "react";
import { urlMovieTheaters } from "../endpoints";
import EditEntity from "../utilities/EditEntity";
import { movieTheaterCreationDTO, movieTheaterDTO } from "./movieTheater.model";
import MovieTheaterForm from "./MovieTheaterFrom";

export default function EditMovieTheater() {
    return (
        <EditEntity<movieTheaterCreationDTO, movieTheaterDTO> entityName="Movie Theater" url={urlMovieTheaters} indexURL="/movietheaters">
            {(entity, edit) =>
                <MovieTheaterForm
                    model={entity} onSubmit={async values => await edit(values)} />
            }
        </EditEntity >
    )

}