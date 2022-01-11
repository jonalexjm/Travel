﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Core.Entities;
using Travel.Core.Interfaces.Repositories;
using Travel.Infrastructure.Data;

namespace Travel.Infrastructure.Repositories
{
    public class EditorialRepository : BaseRepository<Editorial>, IEditorialRepository
    {
        public EditorialRepository(TravelDbContext context) : base(context)
        {
        }
    }
}
