using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

    public class PixeonContext : DbContext
    {
        public PixeonContext (DbContextOptions<PixeonContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPI.Model.Tarefas> Tarefas { get; set; }
    }
