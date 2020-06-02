using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionFTP.Clases
{
    class XmlCanonico
    {
        string type_doc, consecutivo_id, tipo_documento, documento, lugar_expedicion
            , primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, estado_civil, pais
            , departamento, municipio, fecha_nacimiento, barrio, telefono, celular, correo, fecha_registro
            , genero, direccion, progama, semestre, asunto, descripcion, estado, tipo_transaccion, periodo, creditos, codigo, asignatura
            , grupo, franja, ceremonia, ventanilla, usuario, contraseña;

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

        public override string ToString()
        {
            return "type_doc: " + this.type_doc + " consecutivo_id: " + this.consecutivo_id + " tipo_documento:" + this.tipo_documento
                + " documento: " + this.documento + " lugar_expedicion: " + this.lugar_expedicion + " primer_nombre: " + this.primer_nombre
                + " segundo_nombre: " + this.segundo_nombre + " primer_apellido: " + this.primer_apellido + " segundo_apellido: " + this.segundo_apellido
                + " estado_civil: " + this.estado_civil + " pais: " + this.pais + " departamento: " + this.departamento + " municipio:" + this.municipio
                + " fecha_nacimiento: " + this.fecha_nacimiento + " barrio: " + this.barrio + " telefono: " + this.telefono + " celular: " + this.celular
                + " correo: " + this.correo + " fecha_registro: " + this.fecha_registro + " genero: " + this.genero + " direccion: " + this.direccion + " progama: " + this.progama
                + " semestre: " + this.semestre + " asunto: " + this.asunto + " descripcion: " + this.descripcion + " estado: " + this.estado + " tipo_transaccion: " + this.tipo_transaccion
                + " periodo: " + this.periodo + " creditos: " + this.creditos + " codigo: " + this.codigo + " asignatura: " + this.asignatura + " grupo: " + this.grupo
                + " franja: " + this.franja + " ceremonia: " + this.ceremonia + " ventanilla: " + this.ventanilla + " usuario: " + this.usuario 
                + " contraseña: " + this.contraseña;
        }
    }
}
