using Application.Base;
using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class DireccionRequest : IRequest<Direccion>
    {
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Barrio { get; set; }
        public DireccionTipo TipoDireccion { get; set; }
        public string Numero { get; set; }

        public Direccion ToEntity()
        {
            return new Direccion
            {
                Pais = this.Pais,
                Ciudad = this.Ciudad,
                Barrio = this.Barrio,
                Tipo = this.TipoDireccion,
                Numero = this.Numero
            };
        }
    }
}