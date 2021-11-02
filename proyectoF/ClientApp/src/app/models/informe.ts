import { Cita } from "./cita";
import { Doctor } from "./doctor";
import { Producto } from "./producto";

export class Informe {
    codigo: string;
    productos: Producto[];
    doctor: Doctor;
    idDoctor: string;
    idPaciente: string;
    diagnostico: string;
    estado: boolean;
    cita: Cita;
}
