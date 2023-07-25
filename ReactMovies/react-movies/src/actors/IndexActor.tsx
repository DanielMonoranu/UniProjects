import { Link } from "react-router-dom";
import { urlActors } from "../endpoints";
import IndexEntity from "../utilities/IndexEntity";
import { actorDto } from "./actors.model";

export default function IndexActor() {
    return (

        <IndexEntity<actorDto> url={urlActors} createURL='actors/create'
            title="Actors"
            entityName="Actor">
            {(actors, buttons) => <>
                <thead>
                    <tr>
                        <th>
                        </th>
                        <th>
                            Name
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {actors?.map(actor => <tr key={actor.id}>
                        <td>
                            {buttons(`actors/edit/${actor.id}`, actor.id)}
                        </td>
                        <td>
                            {actor.name}
                        </td>
                    </tr>)}
                </tbody>
            </>}
        </IndexEntity>


    )

}