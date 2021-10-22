import { Persona } from "./persona";

export class Paciente extends Persona {
    genero: string
    direccion: string;
    telefono: string;
    tipoAseguradora: string;
    ocupacion: string;
    departamentoResidencia: string;
    email: string;
}
