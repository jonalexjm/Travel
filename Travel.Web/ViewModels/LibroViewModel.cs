using System.Collections.Generic;
using Travel.Core.Entities;

namespace Travel.Web.ViewModels
{
    public class LibroViewModel
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }
        public int? Editoriales { get; set; }

        public List<AutoresHasLibro> AutoresHasLibros { get; set; }

        public virtual Editorial EditorialesNavigation { get; set; }
    }
}
