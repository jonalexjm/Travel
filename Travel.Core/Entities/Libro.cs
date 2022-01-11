using System;
using System.Collections.Generic;
using Travel.Core.Interfaces.Repositories;

#nullable disable

namespace Travel.Core.Entities
{
    public partial class Libro : BaseEntity
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }
        public int? Editoriales { get; set; }

        public virtual Editorial EditorialesNavigation { get; set; }
    }
}
