import './MultipleSelector.css';

export default function MultipleSelector(props: multipleSelectorProps) {

    function select(item: multipleSelectorModel) {
        const selected = [...props.selected, item];    //?concat ce era cu noul item  
        const nonSelected = props.nonSelected.filter(value => value !== item);
        props.onChange(selected, nonSelected);  //transmit to parent
    }

    function deselect(item: multipleSelectorModel) { //for deselecting something that was selected
        const nonSelected = [...props.nonSelected, item];
        const selected = props.selected.filter(value => value !== item);
        props.onChange(selected, nonSelected);
    }

    function selectAll() {
        const selected = [...props.selected, ...props.nonSelected]; //concat ce a fost selectat cu ce nu a fost selectat
        const nonSelected: multipleSelectorModel[] = [];
        props.onChange(selected, nonSelected);
    }
    function deselectAll() {
        const nonSelected = [...props.nonSelected, ...props.selected]; //concat ce a fost selectat cu ce nu a fost selectat
        const selected: multipleSelectorModel[] = [];
        props.onChange(selected, nonSelected);
    }


    return (
        <div className="mb-3">
            <label>{props.displayName}</label>
            <div className="multiple-selector">
                <p>NonSelected </p>
                <ul>
                    {props.nonSelected.map(item =>
                        <li key={item.key} onClick={() => select(item)}>{item.value}</li>
                    )}
                </ul>
                <div className="multiple-selector-buttons">
                    <button type="button" onClick={selectAll}>{'>>'}</button>
                    <button type="button" onClick={deselectAll}>{'<<'}</button>
                </div>
                <label>Selected</label>
                <ul>
                    {props.selected.map(item =>
                        <li key={item.key} onClick={() => deselect(item)}>{item.value}</li>
                    )}
                </ul>
            </div>
        </div>

    );
}
interface multipleSelectorProps {
    displayName: string;
    selected: multipleSelectorModel[];
    nonSelected: multipleSelectorModel[];
    onChange(selected: multipleSelectorModel[],
        nonSelected: multipleSelectorModel[]): void;

}

export interface multipleSelectorModel {
    key: number;
    value: string;

}