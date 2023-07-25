import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useContext, useEffect, useState } from "react";
import Swal from "sweetalert2";
import AuthenticationContext from "../authentication/AuthenticationContext";
import './Ratings.css';

export default function Ratings(props: ratingsProps) {
    const [maximumValueArr, setMaximumValueArr] = useState<number[]>([]);
    const [selectedValue, setSelectedValue] = useState(props.selectedValue);
    const { claims } = useContext(AuthenticationContext);

    useEffect(() => {
        setMaximumValueArr(Array(props.maximumValue).fill(0));
    }, [props.maximumValue])

    function handleMouseOver(rate: number) {
        setSelectedValue(rate);
    }


    function handleClick(rate: number) {
        const userIsLoggedIn = claims.length > 0;
        if (!userIsLoggedIn) {
            Swal.fire({ title: 'Error', text: 'You need to be logged in', icon: 'error' })
            return;
        }

        setSelectedValue(rate);
        props.onChange(rate);
    }

    return <>
        {maximumValueArr.map((_, index) => <FontAwesomeIcon icon="star" key={index}
            className={`fa-lg pointer ${selectedValue >= index + 1 ? 'checked' : null}`}
            onClick={() => handleClick(index + 1)}
            onMouseOver={() => handleMouseOver(index + 1)} />)}
    </>

}
interface ratingsProps {
    maximumValue: number;  //number of stars
    selectedValue: number;
    onChange(rate: number): void;

}