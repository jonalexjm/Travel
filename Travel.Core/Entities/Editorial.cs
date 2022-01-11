using System;
using System.Collections.Generic;
using Travel.Core.Interfaces.Repositories;

#nullable disable

namespace Travel.Core.Entities
{
    public partial class Editorial : BaseEntity
    {
        public Editorial()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sede { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
