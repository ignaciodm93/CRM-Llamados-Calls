//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ENTIDADES
{
    using System;
    using System.Collections.Generic;
    
    public partial class LlamadosDestinatarios
    {
        public byte UsuarioId { get; set; }
        public int LlamadoId { get; set; }
        public string Comentarios { get; set; }
    
        public virtual Llamados Llamados { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}