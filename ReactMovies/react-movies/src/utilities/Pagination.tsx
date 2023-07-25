import { useEffect, useState } from "react";

export default function Pagination(props: paginationProps) {
    const [linkModels, setLinkModels] = useState<linkModel[]>([]);

    function selectPage(link: linkModel) {
        if (link.page === props.currentPage) {
            return;
        }
        if (!link.enabled) {
            return;
        }
        props.onChange(link.page);
    }

    function getClass(link: linkModel) {
        if (link.active) {
            return "active pointer";
        }
        if (!link.enabled) {
            return "disabled";
        }
        return "pointer";
    }

    useEffect(() => {
        const previousPageEnabled = props.currentPage !== 1; //daca nu suntem la prima pagina
        const previousPage = props.currentPage - 1;
        const links: linkModel[] = [];

        links.push({
            page: previousPage,
            enabled: previousPageEnabled,
            text: 'Previous',
            active: false,
        })
        for (let i = 1; i <= props.totalAmountOfPages; i++) {
            if (i >= props.currentPage - props.radio && i <= props.currentPage + props.radio) {
                links.push({
                    text: `${i}`,
                    active: props.currentPage === i, //daca  suntem pe pagina
                    enabled: true,
                    page: i
                })
            }
        }

        const nextPageEnabled = props.currentPage !== props.totalAmountOfPages &&
            props.totalAmountOfPages > 0;
        const nextPage = props.currentPage + 1;
        links.push({
            page: nextPage,
            enabled: nextPageEnabled,
            text: 'Next',
            active: false,
        })

        setLinkModels(links);

    }, [props.currentPage, props.totalAmountOfPages, props.radio])

    return <nav>
        <ul className="pagination justify-content-center">
            {linkModels.map((link) => <li key={link.text}
                onClick={() => selectPage(link)}
                className={`page-item cursor ${getClass(link)}`}>

                <span className="page-link">{link.text}</span>
            </li>

            )}
        </ul>
    </nav >
}
interface linkModel {
    page: number;
    enabled: boolean;
    text: string;
    active: boolean;
}

interface paginationProps {
    currentPage: number;
    totalAmountOfPages: number;
    radio: number;
    onChange(page: number): void;
}
Pagination.defaultProps = {
    radio: 3
}