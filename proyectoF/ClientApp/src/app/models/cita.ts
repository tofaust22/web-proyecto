import { Doctor } from "./doctor";
import { Paciente } from "./paciente";

export class Cita {
    codigo: string;
    fechaRegistro: Date;
    estado: string
    observaciones: string
    doctor: Doctor;
    paciente: Paciente;
}
