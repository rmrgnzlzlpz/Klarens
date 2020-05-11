using Domain.Base;

namespace Domain.ValueObjects
{
    public class Direccion : Entity<int>
    {
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Barrio { get; set; }
        public DireccionTipo Tipo { get; set; }
        public string Numero { get; set; }
    }

    public enum DireccionTipo
    {
        Calle = 0, Carrera = 1, Diagonal = 2, Transversal = 3
    }
}