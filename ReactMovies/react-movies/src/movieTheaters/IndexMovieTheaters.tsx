import { ReactElement, JSXElementConstructor } from "react";
import { urlMovieTheaters } from "../endpoints";
import IndexEntity from "../utilities/IndexEntity";
import { movieTheaterDTO } from "./movieTheater.model";

export default function IndexMovieTheaters() {
    return (
        <IndexEntity<movieTheaterDTO>
            url={urlMovieTheaters} entityName="Movie Theater" title="Movie Theaters" createURL="movietheaters/create" >
            {(entities, buttons) => <>
                <thead>
                    <tr>
                        <th>
                        </th>
                        <th>Name</th>
                    </tr>
                </thead>
                <tbody>
                    {entities?.map(entity =>
                        <tr key={entity.id}>
                            <td>
                                {buttons(`movietheaters/edit/${entity.id}`, entity.id)}
                            </td>
                            <td>
                                {entity.name}
                            </td>

                        </tr>)}
                </tbody>

            </>
            }
        </IndexEntity>)
} 