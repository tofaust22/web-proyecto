import { Especialidad } from "./especialidad";
import { Persona } from "./persona";

export class Doctor extends Persona {
    codigo: string;
    especialidad: Especialidad;
}
