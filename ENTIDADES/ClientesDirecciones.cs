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
    
    public partial class ClientesDirecciones
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public short Altura { get; set; }
        public string Dpto { get; set; }
        public Nullable<byte> Piso { get; set; }
        public int CiudadId { get; set; }
        public Nullable<short> ClienteId { get; set; }
    
        public virtual Ciudades Ciudades { get; set; }
        public virtual Clientes Clientes { get; set; }
    }
}