using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionFTP.Clases
{
    public class XmlCanonico
    {
        string type_doc, consecutivo_id, tipo_documento, documento, lugar_expedicion
            , primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, estado_civil, pais
            , departamento, municipio, fecha_nacimiento, barrio, telefono, celular, correo, fecha_registro
            , genero, direccion, progama, semestre, asunto, descripcion, estado, tipo_transaccion, periodo, creditos, codigo, asignatura
            , grupo, franja, ceremonia, ventanilla, usuario, contraseña,sede,nombre_archivo;

        public string Type_doc { get => type_doc; set => type_doc = value; }
        public string Consecutivo_id { get => consecutivo_id; set => consecutivo_id = value; }
        public string Tipo_documento { get => tipo_documento; set => tipo_documento = value; }
        public string Documento { get => documento; set => documento = value; }
        public string Lugar_expedicion { get => lugar_expedicion; set => lugar_expedicion = value; }
        public string Primer_nombre { get => primer_nombre; set => primer_nombre = value; }
        public string Segundo_nombre { get => segundo_nombre; set => segundo_nombre = value; }
        public string Primer_apellido { get => primer_apellido; set => primer_apellido = value; }
        public string Segundo_apellido { get => segundo_apellido; set => segundo_apellido = value; }
        public string Estado_civil { get => estado_civil; set => estado_civil = value; }
        public string Pais { get => pais; set => pais = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public string Municipio { get => municipio; set => municipio = value; }
        public string Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
        public string Barrio { get => barrio; set => barrio = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Fecha_registro { get => fecha_registro; set => fecha_registro = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Progama { get => progama; set => progama = value; }
        public string Semestre { get => semestre; set => semestre = value; }
        public string Asunto { get => asunto; set => asunto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Tipo_transaccion { get => tipo_transaccion; set => tipo_transaccion = value; }
        public string Periodo { get => periodo; set => periodo = value; }
        public string Creditos { get => creditos; set => creditos = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Asignatura { get => asignatura; set => asignatura = value; }
        public string Grupo { get => grupo; set => grupo = value; }
        public string Franja { get => franja; set => franja = value; }
        public string Ceremonia { get => ceremonia; set => ceremonia = value; }
        public string Ventanilla { get => ventanilla; set => ventanilla = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Sede { get => sede; set => sede = value; }
        public string Nombre_archivo { get => nombre_archivo; set => nombre_archivo = value; }

        public override string ToString()
        {
            return "type_doc: " + this.Type_doc + " consecutivo_id: " + this.Consecutivo_id + " tipo_documento:" + this.Tipo_documento
                + " documento: " + this.Documento + " lugar_expedicion: " + this.Lugar_expedicion + " primer_nombre: " + this.Primer_nombre
                + " segundo_nombre: " + this.Segundo_nombre + " primer_apellido: " + this.Primer_apellido + " segundo_apellido: " + this.Segundo_apellido
                + " estado_civil: " + this.Estado_civil + " pais: " + this.Pais + " departamento: " + this.Departamento + " municipio:" + this.Municipio
                + " fecha_nacimiento: " + this.Fecha_nacimiento + " barrio: " + this.Barrio + " telefono: " + this.Telefono + " celular: " + this.Celular
                + " correo: " + this.Correo + " fecha_registro: " + this.Fecha_registro + " genero: " + this.Genero + " direccion: " + this.Direccion + " progama: " + this.Progama
                + " semestre: " + this.Semestre + " asunto: " + this.Asunto + " descripcion: " + this.Descripcion + " estado: " + this.Estado + " tipo_transaccion: " + this.Tipo_transaccion
                + " periodo: " + this.Periodo + " creditos: " + this.Creditos + " codigo: " + this.Codigo + " asignatura: " + this.Asignatura + " grupo: " + this.Grupo
                + " franja: " + this.Franja + " ceremonia: " + this.Ceremonia + " ventanilla: " + this.Ventanilla + " usuario: " + this.Usuario 
                + " contraseña: " + this.Contraseña + " sede: " + this.Sede + "nombre_archivo" + this.Nombre_archivo;
        }
    }
}
