import { Modulo } from "./modulo";

export class Usuario {
        usuario:string;
        password: string;
        nombre: string;
        apellidos: string;
        tipo: string;
        token: string;
        estado: string;
        //public List<UsuarioRol> Roles { get; set; }
        modulos: Modulo[];
}
