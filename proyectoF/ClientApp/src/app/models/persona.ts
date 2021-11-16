import { Usuario } from "./usuario";

export class Persona {
    identificacion: string;
    primerNombre: string;
    segundoNombre: string;
    primerApellido: string;
    segundoApellido: string;
    fechaNacimiento: Date;
    usuario: Usuario;
    edad: number;

    constructor(){
        this.usuario = new Usuario();
    }
}
