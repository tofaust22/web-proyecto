import { Usuario } from "./usuario";

export class Persona {
    identificacion: string;
    primerNombre: string;
    segundoNombre: string;
    primerApellido: string;
    segundoApellido: string;
    fechaNacimiento: Date;
    usuario: Usuario;

    constructor(){
        this.usuario = new Usuario();
    }
}
