﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Core.Entities;

namespace Travel.Core.Interfaces.Repositories
{
    public interface ILibroRepository : IRepository<Libro>
    {
        Task<List<Libro>> ObtenerLibrosConEditoriales();
    }
}
