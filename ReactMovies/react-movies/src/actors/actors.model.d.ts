export interface actorCreationDto {
    name: string;
    dateOfBirth?: Date;
    picture?: File;
    pictureURL?: string;
    biography?: string;
}
export interface actorDto {
    id: number;
    name: string;
    biography: string;
    dateOfBirth: Date;
    picture: string;
}

export interface actorMovieDTO {
    id: number;
    name: string;
    character: string;
    picture: string;
}
