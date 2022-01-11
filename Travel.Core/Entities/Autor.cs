using System;
using System.Collections.Generic;
using Travel.Core.Interfaces.Repositories;

#nullable disable

namespace Travel.Core.Entities
{
    public partial class Autor : BaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
    }
}
