import { Form, Formik, FormikHelpers } from "formik";
import { movieCreationDTO } from "./movies.model";
import * as Yup from 'yup'
import Button from "../utilities/Button";
import { Link } from "react-router-dom";
import TextField from "../forms/TextField";
import DateField from "../forms/DateField";
import ImageField from "../forms/ImageField";
import CheckboxField from "../forms/CheckboxField";
import MultipleSelector, { multipleSelectorModel } from "../forms/MultipleSelector";
import { genreDTO } from "../genres/genres.model";
import { useState } from "react";
import { movieTheaterDTO } from "../movieTheaters/movieTheater.model";
import { Typeahead } from "react-bootstrap-typeahead";
import TypeAheadActors from "../forms/TypeAheadActors";
import { actorMovieDTO } from "../actors/actors.model";
import MarkdownField from "../forms/MarkdownField";

export default function MovieForm(props: movieFormProps) {
    const [selectedGenres, setSelectedGenres] = useState(mapToModel(props.selectedGenres));
    const [nonSelectedGenres, setNonSelectedGenres] = useState(mapToModel(props.nonSelectedGenres));

    const [selectedMovieTheaters, setselectedMovieTheaters] = useState(mapToModel(props.selectedMovieTheaters));
    const [nonselectedMovieTheaters, setNonselectedMovieTheaters] = useState(mapToModel(props.nonSelectedMovieTheaters));

    function mapToModel(items: { id: number, name: string }[]): multipleSelectorModel[] {
        return items.map(item => {
            return { key: item.id, value: item.name }
        })
    }
    const [selectedActors, setSelectedActors] = useState(props.selectedActors);
    return (
        <Formik
            initialValues={props.model}
            onSubmit={(values, actions) => {  //sa stim informatii despre ce am ales
                values.genresIds = selectedGenres.map(item => item.key);
                values.movieTheatersIds = selectedMovieTheaters.map(item => item.key);
                values.selectedActors = selectedActors;
                props.onSubmit(values, actions);
            }}

            validationSchema={Yup.object({ title: Yup.string().required('This field is required').firstLetterUpercase() })}>
            {(formikProps) => (
                <Form>
                    <TextField displayName="Title" field="title" />
                    <CheckboxField displayName="In Theaters" field="inTheaters" />
                    <TextField displayName="Trailer" field="trailer" />
                    <DateField displayName="ReleaseDate" field="releaseDate" />
                    <ImageField displayName="Poster" field={"poster"} imageUrl={props.model.posterURL} />

                    <MarkdownField displayName="Summary" field="summary" />
                    <MultipleSelector displayName="Genres"
                        selected={selectedGenres}
                        nonSelected={nonSelectedGenres}
                        onChange={(selected, noSelected) => {
                            setSelectedGenres(selected);
                            setNonSelectedGenres(noSelected);
                        }} />

                    <MultipleSelector displayName="Movie Theaters"
                        selected={selectedMovieTheaters}
                        nonSelected={nonselectedMovieTheaters}
                        onChange={(selected, noSelected) => {
                            setselectedMovieTheaters(selected);
                            setNonselectedMovieTheaters(noSelected);
                        }} />

                    <TypeAheadActors displayName="Actors" actors={selectedActors}

                        onRemove={actor => {
                            const actors = selectedActors.filter(x => x !== actor);
                            setSelectedActors(actors);
                        }}
                        onAdd={actors => {
                            setSelectedActors(actors);
                        }}
                        listUI={(actor: actorMovieDTO) => <>
                            {actor.name}/<input placeholder="Character" type="text"  //pentru a face o lista de actori selectati
                                value={actor.character} onChange={e => {
                                    const index = selectedActors.findIndex(x => x.id === actor.id);
                                    const actors = [...selectedActors];
                                    actors[index].character = e.currentTarget.value;
                                    setSelectedActors(actors);
                                }} />
                        </>}

                    />

                    <Button disabled={formikProps.isSubmitting} type='submit'>Save Changes</Button>
                    <Link className="btn btn-secondary" to="/genres">Cancel</Link>
                </Form>
            )}
        </Formik>
    )

}
interface movieFormProps {
    model: movieCreationDTO;
    onSubmit(values: movieCreationDTO, actions: FormikHelpers<movieCreationDTO>): void;
    selectedGenres: genreDTO[];
    nonSelectedGenres: genreDTO[];
    selectedMovieTheaters: movieTheaterDTO[];
    nonSelectedMovieTheaters: movieTheaterDTO[];
    selectedActors: actorMovieDTO[];
}