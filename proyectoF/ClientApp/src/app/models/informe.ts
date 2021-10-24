import { Cita } from "./cita";
import { Doctor } from "./doctor";

export class Informe {
    codigo: string;
    //public List<DetalleProducto> Detalles { get; set; }
    doctor: Doctor;
    //public DetalleProducto Detalle { get; set; }
    diagnostico: string;
    cita: Cita;
}
