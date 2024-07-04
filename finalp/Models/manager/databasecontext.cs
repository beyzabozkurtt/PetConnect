using System.Data.Entity;

namespace finalp.Models.manager
{
    public class databasecontext : DbContext
    {
        public DbSet<tbl_adopt> adopt_tablosu { get; set; }


        public DbSet<iletisim> iletisim_tablosu { get; set; }

        public DbSet<User> users { get; set; }

        public DbSet<ilanlar> ilanlars { get; set; }
        public DbSet<blog> blogs { get; set; }

        public DbSet<bagislar> bagis { get; set; }

    }
}