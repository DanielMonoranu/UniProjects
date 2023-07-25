import { useParams } from "react-router-dom"
import { transform } from "typescript"
import { urlActors } from "../endpoints"
import EditEntity from "../utilities/EditEntity"
import { convertActorToFormData } from "../utilities/formDataConvert"
import ActorForm from "./ActorForm"
import { actorCreationDto, actorDto } from "./actors.model"

export default function EditActor() {
    function transformActor(actor: actorDto): actorCreationDto {

        return {
            name: actor.name,
            pictureURL: actor.picture,
            biography: actor.biography,
            dateOfBirth: new Date(actor.dateOfBirth),
            // ar trebui dat si picture https://stackoverflow.com/questions/25046301/convert-url-to-file-or-blob-for-filereader-readasdataurl
        }
    }

    return (
        <EditEntity<actorCreationDto, actorDto>
            url={urlActors} indexURL="/actors" entityName="Actor"
            transformFormData={convertActorToFormData}
            transform={transformActor}
        >
            {(entity, edit) =>
                <ActorForm model={entity} onSubmit={async values =>
                    await edit(values)
                }></ActorForm>
            }
        </EditEntity>


    )

}