﻿using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IApplicationDbContext
    {
        public DbSet<Hotel> Hotels{ get; set; }
        public int SaveChanges();

    }
}
