using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Travel.Core.Interfaces.Repositories;

#nullable disable

namespace Travel.Core.Entities
{
    public partial class AutoresHasLibro : BaseEntity
    {
        [Key]
        public int? AutoresId { get; set; }
        public int? LibrosIsbn { get; set; }

        public virtual Autor Autores { get; set; }
        public virtual Libro LibrosIsbnNavigation { get; set; }
    }
}
