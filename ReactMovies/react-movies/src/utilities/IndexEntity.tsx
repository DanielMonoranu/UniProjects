import axios, { AxiosResponse } from "axios";
import { useEffect, useState } from "react";
import { ReactElement } from "react-markdown/lib/react-markdown";
import { Link } from "react-router-dom";
import Button from "./Button";
import customConfirm from "./customConfirm";
import GenericList from "./GenericList";
import Pagination from "./Pagination";
import RecordsPerPageSelect from "./RecordsPerPageSelect";

export default function IndexEntity<T>(props: indexEntityProps<T>) {
    const [entities, setEntities] = useState<T[]>();
    const [totalAmountOfPages, setTotalAmountOfPages] = useState(0);
    const [recordsPerPage, setRecordsPerPage] = useState(5);
    const [page, setPage] = useState(1);

    useEffect(() => {
        loadData();
    }, [page, recordsPerPage]);

    function loadData() {
        axios.get(props.url, { params: { page, recordsPerPage } })
            .then((response: AxiosResponse<T[]>) => {
                const totalAmountOfRecords = parseInt(response.headers['totalamountofrecords'], 10);
                setTotalAmountOfPages(Math.ceil(totalAmountOfRecords / recordsPerPage));
                setEntities(response.data);
                //console.log(response.data);
            })
    }


    async function deleteEntity(id: number) {
        await axios.delete(`${props.url}/${id}`)

            .catch(function (error) {
                if (error && error.response) {
                    console.error(error.response.data);
                }
            })
        loadData();

    }

    const buttons = (editUrl: string, id: number) =>
        <> <Link className="btn btn-success"
            to={editUrl}>Edit</Link>
            <Button onClick={() => customConfirm(() => deleteEntity(id))}
                className="btn btn-danger">Delete</Button>

        </>

    return (<>
        <h3>{props.title}</h3>
        {props.createURL ?
            <Link className="btn btn-primary" to={props.createURL} >Create {props.entityName}</Link> : null}

        <RecordsPerPageSelect onChangeRecords={amountOfRecords => {
            setPage(1);
            setRecordsPerPage(amountOfRecords);
        }
        } />
        <Pagination
            currentPage={page}
            totalAmountOfPages={totalAmountOfPages}
            onChange={newPage => setPage(newPage)}
        ></Pagination>
        <GenericList list={entities} >
            <table className="table table-striped">
                {props.children(entities!, buttons)}

            </table>
        </GenericList>
    </>)
}
interface indexEntityProps<T> {
    url: string;
    entityName?: string;
    title: string;
    createURL?: string;
    children(entities: T[],
        buttons: (editUrl: string, id: number) => ReactElement): ReactElement
}