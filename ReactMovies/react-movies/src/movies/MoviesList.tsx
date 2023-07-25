import { movieDto } from './movies.model';
import IndividualMovie from './IndividualMovie';
import css from './MoviesList.module.css';
import Loading from '../utilities/Loading';
import GenericList from '../utilities/GenericList';

export default function MoviesList(props: moviesListProps) {

    return <GenericList
        list={props.movies}>
        <div className={css.div}>
            {props.movies?.map((movie) =>
                <IndividualMovie {...movie} key={movie.id} />
            )}
        </div >
    </GenericList>
}
interface moviesListProps {
    movies?: movieDto[];

}