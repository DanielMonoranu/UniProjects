import { urlGenres } from "../endpoints";
import EditEntity from "../utilities/EditEntity";
import GenreForm from "./GenreForm";
import { genreCreationDTO, genreDTO } from "./genres.model";

export default function EditGenre() {
    return (
        <>

            <EditEntity<genreCreationDTO, genreDTO>
                entityName="Genres" url={urlGenres} indexURL="/genres">
                {(entity, edit) => <GenreForm model={entity}
                    onSubmit={async value => {
                        //when the form is posted
                        await edit(value);
                        //console.log(value);
                    }}
                />}</EditEntity>
        </>

    )

}