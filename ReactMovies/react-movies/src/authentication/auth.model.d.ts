export interface claim {
    name: string;
    value: string;
}
export interface userCredentials {
    email: string;
    password: string;
}
export interface authenticationRespone {   //pt axios.post
    token: string;
    expiration: Date;
}

export interface userDTO {
    id: string;
    email: string;
}