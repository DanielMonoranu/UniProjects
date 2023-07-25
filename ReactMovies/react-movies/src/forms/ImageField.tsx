import { useFormikContext } from "formik";
import { ChangeEvent, useState } from "react"

export default function ImageField(props: imageFieldProps) {
    //styling:
    const divStyle = { marginTop: '10px' };
    const imgStyle = { width: '450px' };
    //state variables:
    const [imageBase64, setImageBase64] = useState('');
    const [imageURL, setImageURL] = useState(props.imageUrl);
    const { values } = useFormikContext<any>();

    const handleOnChange = (eventArgs: ChangeEvent<HTMLInputElement>) => {
        if (eventArgs.currentTarget.files) {
            const file = eventArgs.currentTarget.files[0];
            if (file) {
                toBase64(file).then((base64Representation: string) =>
                    setImageBase64(base64Representation))
                    .catch(error => console.error(error));
                values[props.field] = file;
                setImageURL('');
            }
            else {
                setImageBase64('');
            }
        }
    }

    const toBase64 = (file: File) => {
        return new Promise<string>((resolve, reject) => {
            const reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onload = () => resolve(reader.result as string);
            reader.onerror = (error) => reject(error);
        });
    }

    return (<div className="mb-3">
        <label>{props.displayName}</label>
        <div>
            <input type="file" accept=".jpg,.jpeg,.png" onChange={handleOnChange} />
        </div>
        {imageBase64 ? <div>
            <div style={divStyle}>
                <img style={imgStyle} src={imageBase64} alt="selected" />
            </div>
        </div> : null}
        {imageURL ? <div>
            <div style={divStyle}>
                <img style={imgStyle} src={imageURL} alt="selected" />
            </div>
        </div> : null}
    </div>)

}

interface imageFieldProps {
    displayName: string;
    imageUrl: string;
    field: string;
}
ImageField.defaultProps = {
    imageUrl: '',
}