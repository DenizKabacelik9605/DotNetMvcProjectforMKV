using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;



namespace DataAccess
{
    public class MkvCrudDbContext:DbContext
    {
        public MkvCrudDbContext(DbContextOptions options):base(options) 
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
