using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Content> Contents { get; set; }
        DbSet<ContentDescription> ContentDescriptions { get; set; }
        DbSet<ContentType> ContentTypes { get; set; }
        DbSet<Rate> Rates { get; set; }

        public EFDbContext(): base("DefaultConnection")
        {
        }
    }
}
