export default function DisplayErrors(props: displayErrorProps) {
    const style = { color: 'red' };

    return (
        <>
            {props.errors ? <ul style={style}>
                {props.errors.map((error, index) =>
                    <li key={index}>{error}</li>)}
            </ul> : null}
            {props.singleError ? <ul style={style}> <li>{props.singleError}</li></ul> : null}
        </>
    )
}
interface displayErrorProps {
    errors?: string[];
    singleError?: string;
}