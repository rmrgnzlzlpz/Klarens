using Application.Base;
using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class PersonaRequest : IRequest<Persona>
    {
        public string Nombre { get; set; }
        public string NumeroDocumento { get; set; }
        public ComprobanteTipo TipoDocumento { get; set; }
        public DireccionRequest Direccion { get; set; }
        public string Telefono { get; set; }
        public stringa Email { get; set; }
        public Persona ToEntity()
        {
            return new Persona
            {
                Nombre = this.Nombre,
                Documento = new Comprobante { Numero = NumeroDocumento, Tipo = TipoDocumento },
                Direccion = this.Direccion.ToEntity()
            };
        }
        
    }
}