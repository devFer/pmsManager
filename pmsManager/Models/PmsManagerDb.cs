using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace pmsManager.Models
{
    public interface IPmsManagerDb : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;   
    }

    public class PmsManagerDb : DbContext, IPmsManagerDb
    {
        public PmsManagerDb()
            : base("name=DefaultConnection")
        {

        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Pms> PmsSet { get; set; }
        public DbSet<ImpExpAssociated> formats { get; set; }

        IQueryable<T> IPmsManagerDb.Query<T>()
        {
            return Set<T>();
        }
    }

}