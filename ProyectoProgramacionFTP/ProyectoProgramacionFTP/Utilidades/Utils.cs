using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionFTP.Utilidades
{
    public class Utils
    {
        public string SetNombreCarpSegXml(string consecutivo)
        {
            string nombreCarpeta;
            switch (consecutivo)
            {
                case "SOLI":
                    nombreCarpeta = "XML_SOLI";
                    break;
                case "SOLMAFI":
                    nombreCarpeta = "XML_SOLMAFI";
                    break;
                case "SOLMAAC":
                    nombreCarpeta = "XML_SOLMAAC";
                    break;
                case "SOLGRA":
                    nombreCarpeta = "XML_SOLGRA";
                    break;
                case "SOLCREES":
                    nombreCarpeta = "XML_SOLCREES";
                    break;
                case "SOLCANMA":
                    nombreCarpeta = "XML_SOLCANMA";
                    break;
                default: nombreCarpeta = "SIN_FORMATO";
                    break;
            }
            return nombreCarpeta;

        }

        public string[] ObtenerEncabezadosCanonico(string[] headers, string[] body)
        {
            int cantHeaders = headers.Length;
            string[] headersCanonic = new string[37];
            int[] indice = new int[37];
            for (int i = 0; i < cantHeaders; i++)
            {
                if (headers[i].Equals("type_doc"))
                {
                    headersCanonic[0] = "<type_doc>"+ body[i] + "</type_doc>";
                    indice[0] = 1;
                }
                else
                {
                    if (indice[0] == 0)
                    {
                        headersCanonic[0] = "<type_doc></type_doc>";
                    }
                }
                //

                if (headers[i].Equals("soli_id") || headers[i].Equals("somafi_id") || headers[i].Equals("solmac_id")
                    || headers[i].Equals("solgra_id") || headers[i].Equals("solcrees_id") || headers[i].Equals("solcanma"))
                {
                    headersCanonic[1] = "<consecutivo_id>" + body[i] + "</consecutivo_id>";
                    indice[1] = 1;
                }
                else
                {
                    if (indice[1] == 0)
                    {
                        headersCanonic[1] = "<consecutivo_id></consecutivo_id>";
                    }
                }
                //
                if (headers[i].Equals("tipo_documento"))
                {
                    headersCanonic[2] = "<tipo_documento>" + body[i] + "</tipo_documento>";
                    indice[2] = 1;
                }
                else
                {
                    if (indice[2] == 0)
                    {
                        headersCanonic[2] = "<tipo_documento></tipo_documento>";
                    }
                }
                //
                if (headers[i].Equals("documento") || headers[i].Equals("numero_documento"))
                {
                    headersCanonic[3] = "<documento>" + body[i] + "</documento>";
                    indice[3] = 1;
                }
                else
                {
                    if (indice[3] == 0)
                    {
                        headersCanonic[3] = "<documento></documento>";
                    }
                }
                //
                if (headers[i].Equals("lugar_expedicion"))
                {
                    headersCanonic[4] = "<lugar_expedicion>" + body[i] + "</lugar_expedicion>";
                    indice[4] = 1;
                }
                else
                {
                    if (indice[4] == 0)
                    {
                        headersCanonic[4] = "<lugar_expedicion></lugar_expedicion>";
                    }
                }
                //
                if (headers[i].Equals("primer_nombre") || headers[i].Equals("nombre"))
                {
                    headersCanonic[5] = "<primer_nombre>" + body[i] + "</primer_nombre>";
                    indice[5] = 1;
                }
                else
                {
                    if (indice[5] == 0)
                    {
                        headersCanonic[5] = "<primer_nombre></primer_nombre>";
                    }
                }
                //
                if (headers[i].Equals("segundo_nombre"))
                {
                    headersCanonic[6] = "<segundo_nombre>" + body[i] + "</segundo_nombre>";
                    indice[6] = 1;
                }
                else
                {
                    if (indice[6] == 0)
                    {
                        headersCanonic[6] = "<segundo_nombre></segundo_nombre>";
                    }
                }
                //
                if (headers[i].Equals("primer_apellido") || headers[i].Equals("apellidos"))
                {
                    headersCanonic[7] = "<primer_apellido>" + body[i] + "</primer_apellido>";
                    indice[7] = 1;
                }
                else
                {
                    if (indice[7] == 0)
                    {
                        headersCanonic[7] = "<primer_apellido></primer_apellido>";
                    }
                }

                if (headers[i].Equals("segundo_apellido"))
                {
                    headersCanonic[8] = "<segundo_apellido>" + body[i] + "</segundo_apellido>";
                    indice[8] = 1;
                }
                else
                {
                    if (indice[8] == 0)
                    {
                        headersCanonic[8] = "<segundo_apellido></segundo_apellido>";
                    }
                }

                if (headers[i].Equals("estado_civil"))
                {
                    headersCanonic[9] = "<estado_civil>" + body[i] + "</estado_civil>";
                    indice[9] = 1;
                }
                else
                {
                    if (indice[9] == 0)
                    {
                        headersCanonic[9] = "<estado_civil></estado_civil>";
                    }
                }

                if (headers[i].Equals("pais_origen"))
                {
                    headersCanonic[10] = "<pais>" + body[i] + "</pais>";
                    indice[10] = 1;
                }
                else
                {
                    if (indice[10] == 0)
                    {
                        headersCanonic[10] = "<pais></pais>";
                    }
                }

                if (headers[i].Equals("dpmt_origen"))
                {
                    headersCanonic[11] = "<departamento>" + body[i] + "</departamento>";
                    indice[11] = 1;
                }
                else
                {
                    if (indice[11] == 0)
                    {
                        headersCanonic[11] = "<departamento></departamento>";
                    }
                }

                if (headers[i].Equals("mpio_origen"))
                {
                    headersCanonic[12] = "<municipio>" + body[i] + "</municipio>";
                    indice[12] = 1;
                }
                else
                {
                    if (indice[12] == 0)
                    {
                        headersCanonic[12] = "<municipio></municipio>";
                    }
                }

                if (headers[i].Equals("fecha_nacimiento"))
                {
                    headersCanonic[13] = "<fecha_nacimiento>" + body[i] + "</fecha_nacimiento>";
                    indice[13] = 1;
                }
                else
                {
                    if (indice[13] == 0)
                    {
                        headersCanonic[13] = "<fecha_nacimiento></fecha_nacimiento>";
                    }
                }

                if (headers[i].Equals("barrio"))
                {
                    headersCanonic[14] = "<barrio>" + body[i] + "</barrio>";
                    indice[14] = 1;
                }
                else
                {
                    if (indice[14] == 0)
                    {
                        headersCanonic[14] = "<barrio></barrio>";
                    }
                }

                if (headers[i].Equals("tele_contacto"))
                {
                    headersCanonic[15] = "<telefono>" + body[i] + "</telefono>";
                    indice[15] = 1;
                }
                else
                {
                    if (indice[15] == 0)
                    {
                        headersCanonic[15] = "<telefono></telefono>";
                    }
                }

                if (headers[i].Equals("tele_movil"))
                {
                    headersCanonic[16] = "<celular>" + body[i] + "</celular>";
                    indice[16] = 1;
                }
                else
                {
                    if (indice[16] == 0)
                    {
                        headersCanonic[16] = "<celular></celular>";
                    }
                }
                //
                if (headers[i].Equals("correo") || headers[i].Equals("email"))
                {
                    headersCanonic[17] = "<correo>" + body[i] + "</correo>";
                    indice[17] = 1;
                }
                else
                {
                    if (indice[17] == 0)
                    {
                        headersCanonic[17] = "<correo></correo>";
                    }
                }
                //
                if (headers[i].Equals("fecha_registro"))
                {
                    headersCanonic[18] = "<fecha_registro>" + body[i] + "</fecha_registro>";
                    indice[18] = 1;
                }
                else
                {
                    if (indice[18] == 0)
                    {
                        headersCanonic[18] = "<fecha_registro></fecha_registro>";
                    }
                }
                //
                if (headers[i].Equals("genero") || headers[i].Equals("sexo"))
                {
                    headersCanonic[19] = "<genero>" + body[i] + "</genero>";
                    indice[19] = 1;
                }
                else
                {
                    if (indice[19] == 0)
                    {
                        headersCanonic[19] = "<genero></genero>";
                    }
                }
                //
                if (headers[i].Equals("direccion_residencia"))
                {
                    headersCanonic[20] = "<direccion>" + body[i] + "</direccion>";
                    indice[20] = 1;
                }
                else
                {
                    if (indice[20] == 0)
                    {
                        headersCanonic[20] = "<direccion></direccion>";
                    }
                }
                //
                if (headers[i].Equals("program_academico") || headers[i].Equals("progama"))
                {
                    headersCanonic[21] = "<progama>" + body[i] + "</progama>";
                    indice[21] = 1;
                }
                else
                {
                    if (indice[21] == 0)
                    {
                        headersCanonic[21] = "<progama></progama>";
                    }
                }
                //
                if (headers[i].Equals("semestre"))
                {
                    headersCanonic[22] = "<semestre>" + body[i] + "</semestre>";
                    indice[22] = 1;
                }
                else
                {
                    if (indice[22] == 0)
                    {
                        headersCanonic[22] = "<semestre></semestre>";
                    }
                }
                //
                if (headers[i].Equals("asunto_solicitud"))
                {
                    headersCanonic[23] = "<asunto>" + body[i] + "</asunto>";
                    indice[23] = 1;
                }
                else
                {
                    if (indice[23] == 0)
                    {
                        headersCanonic[23] = "<asunto></asunto>";
                    }
                }
                //
                if (headers[i].Equals("descrip_solicitud"))
                {
                    headersCanonic[24] = "<descripcion>" + body[i] + "</descripcion>";
                    indice[24] = 1;
                }
                else
                {
                    if (indice[24] == 0)
                    {
                        headersCanonic[24] = "<descripcion></descripcion>";
                    }
                }
                //
                if (headers[i].Equals("estado_matricula"))
                {
                    headersCanonic[25] = "<estado>" + body[i] + "</estado>";
                    indice[25] = 1;
                }
                else
                {
                    if (indice[25] == 0)
                    {
                        headersCanonic[25] = "<estado></estado>";
                    }
                }
                //
                if (headers[i].Equals("tipo_matricula"))
                {
                    headersCanonic[26] = "<tipo_transaccion>" + body[i] + "</tipo_transaccion>";
                    indice[26] = 1;
                }
                else
                {
                    if (indice[26] == 0)
                    {
                        headersCanonic[26] = "<tipo_transaccion></tipo_transaccion>";
                    }
                }
                //
                if (headers[i].Equals("periodo_matricula"))
                {
                    headersCanonic[27] = "<periodo>" + body[i] + "</periodo>";
                    indice[27] = 1;
                }
                else
                {
                    if (indice[27] == 0)
                    {
                        headersCanonic[27] = "<periodo></periodo>";
                    }
                }
                //
                if (headers[i].Equals("credito_matriculado"))
                {
                    headersCanonic[28] = "<creditos>" + body[i] + "</creditos>";
                    indice[28] = 1;
                }
                else
                {
                    if (indice[28] == 0)
                    {
                        headersCanonic[28] = "<creditos></creditos>";
                    }
                }
                //
                if (headers[i].Equals("codigo_asignatura"))
                {
                    headersCanonic[29] = "<codigo>" + body[i] + "</codigo>";
                    indice[29] = 1;
                }
                else
                {
                    if (indice[29] == 0)
                    {
                        headersCanonic[29] = "<codigo></codigo>";
                    }
                }
                //
                if (headers[i].Equals("nombre_asignatura"))
                {
                    headersCanonic[30] = "<asignatura>" + body[i] + "</asignatura>";
                    indice[30] = 1;
                }
                else
                {
                    if (indice[30] == 0)
                    {
                        headersCanonic[30] = "<asignatura></asignatura>";
                    }
                }
                //
                if (headers[i].Equals("grupo_asignatura"))
                {
                    headersCanonic[31] = "<grupo>" + body[i] + "</grupo>";
                    indice[31] = 1;
                }
                else
                {
                    if (indice[31] == 0)
                    {
                        headersCanonic[31] = "<grupo></grupo>";
                    }
                }
                //
                if (headers[i].Equals("franja_asignatura"))
                {
                    headersCanonic[32] = "<franja>" + body[i] + "</franja>";
                    indice[32] = 1;
                }
                else
                {
                    if (indice[32] == 0)
                    {
                        headersCanonic[32] = "<franja></franja>";
                    }
                }
                //
                if (headers[i].Equals("ceremonia"))
                {
                    headersCanonic[33] = "<ceremonia>" + body[i] + "</ceremonia>";
                    indice[33] = 1;
                }
                else
                {
                    if (indice[33] == 0)
                    {
                        headersCanonic[33] = "<ceremonia></ceremonia>";
                    }
                }
                //
                if (headers[i].Equals("ventanilla"))
                {
                    headersCanonic[34] = "<ventanilla>" + body[i] + "</ventanilla>";
                    indice[34] = 1;
                }
                else
                {
                    if (indice[34] == 0)
                    {
                        headersCanonic[34] = "<ventanilla></ventanilla>";
                    }
                }
                //
                if (headers[i].Equals("usuario"))
                {
                    headersCanonic[35] = "<usuario>" + body[i] + "</usuario>";
                    indice[35] = 1;
                }
                else
                {
                    if (indice[35] == 0)
                    {
                        headersCanonic[35] = "<usuario></usuario>";
                    }
                }
                //
                if (headers[i].Equals("contrasena"))
                {
                    headersCanonic[36] = "<contrasena>" + body[i] + "</contrasena>";
                    indice[36] = 1;
                }
                else
                {
                    if (indice[36] == 0)
                    {
                        headersCanonic[36] = "<contrasena></contrasena>";
                    }
                }
            }
            return headersCanonic;
        }

        public string SetNombreCarpetaCola(string consecutivo)
        {
            string nombreCarpeta;
            switch (consecutivo)
            {
                case "SOLI":
                    nombreCarpeta = "Alta";
                    break;
                case "SOLMAFI":
                    nombreCarpeta = "Baja";
                    break;
                case "SOLMAAC":
                    nombreCarpeta = "Media";
                    break;
                case "SOLGRA":
                    nombreCarpeta = "Alta";
                    break;
                case "SOLCREES":
                    nombreCarpeta = "Baja";
                    break;
                case "SOLCANMA":
                    nombreCarpeta = "Media";
                    break;
                default:
                    nombreCarpeta = "Alta";
                    break;
            }
            return nombreCarpeta;
        }
    }
}
