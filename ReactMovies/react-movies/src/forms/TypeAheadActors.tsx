import axios, { AxiosResponse } from "axios";
import { useState } from "react";
import { AsyncTypeahead, Typeahead } from "react-bootstrap-typeahead";
import { Option } from "react-bootstrap-typeahead/types/types";
import { ReactElement } from "react-markdown/lib/react-markdown";
import { actorCreationDto, actorMovieDTO } from "../actors/actors.model";
import { urlActors } from "../endpoints";
import { movieCreationDTO } from "../movies/movies.model";


export default function TypeAheadActors(props: typeAheadActorsProps) {
    const [actors, setActors] = useState<actorMovieDTO[]>([]);
    const [isLoading, setIsLoading] = useState(false);

    const selected: actorMovieDTO[] = [];
    const [draggedElement, setDraggedElement] = useState<actorMovieDTO | undefined>(undefined);

    function handleSearch(query: string) {
        setIsLoading(true);
        axios.get(`${urlActors}/searchByName/${query}`)
            .then((response: AxiosResponse<actorMovieDTO[]>) => {
                setActors(response.data);
                setIsLoading(false);
            })
    }

    function handleDragStart(actor: actorMovieDTO) {
        setDraggedElement(actor);
    }

    function handleDragOver(actor: actorMovieDTO) {
        if (!draggedElement) {
            return;
        }
        if (actor.id !== draggedElement.id) { //actor e elementul peste care pun draggedElement
            const draggedElementIndex = props.actors.findIndex(x => x.id === draggedElement.id);
            const actorIndex = props.actors.findIndex(x => x.id === actor.id);
            const actors = [...props.actors];
            actors[actorIndex] = draggedElement;  //change the order of the actors
            actors[draggedElementIndex] = actor;
            props.onAdd(actors);
        }

    }

    return (<div className="mb-3">
        <label>{props.displayName}</label >
        <AsyncTypeahead id="typeahead"
            onChange={(actor: Option) => {
                actor = actor as actorMovieDTO[];
                const actorId = actor[0].id as number;

                if (props.actors.findIndex(x => x.id === actorId) === -1) { //it coud not found list of actors with this id
                    actor[0].character = '';
                    props.onAdd([...props.actors, actor[0]]);
                }
                //console.log(actors);
            }}
            options={actors}
            labelKey="name"
            filterBy={() => true} //this is filtered in back
            isLoading={isLoading}
            onSearch={handleSearch}
            placeholder="Write the name of the actor..."
            minLength={1}
            flip={true}
            selected={selected}
            renderMenuItemChildren={(actor: Option) => {
                actor = actor as movieCreationDTO;
                return (
                    <>
                        <img alt="actor" src={actor.picture}
                            style={{
                                height: '64px',
                                marginRight: '10px',
                                width: '64px'
                            }} />
                        <span> {actor.name} </span>
                    </>
                );
            }}
        />

        <ul className="list-group">
            {props.actors.map(actor =>
                <li key={actor.id}
                    draggable={true}  //pt mutat drag drop actori in lista
                    onDragStart={() => handleDragStart(actor)}
                    onDragOver={() => handleDragOver(actor)}  //cand un element este peste altul
                    className="list-group-item list-group-item-action">
                    {props.listUI(actor)}

                    <span className="badge badge-primary badge-pill pointer text-dark" style={{ marginLeft: '0.5rem' }}
                        onClick={() => props.onRemove(actor)} >x
                    </span>
                </li>)}

        </ul>
    </div>)

}
interface typeAheadActorsProps {
    displayName: string;
    actors: actorMovieDTO[];
    onAdd(actors: actorMovieDTO[]): void;
    onRemove(actor: actorMovieDTO): void;
    listUI(actor: actorMovieDTO): ReactElement;

}
