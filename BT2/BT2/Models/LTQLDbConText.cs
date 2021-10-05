using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BT2.Models
{
    public partial class LTQLDbConText : DbContext
    {
        public LTQLDbConText()
            : base("name=LTQLDbConText")
        {
        }

        public virtual DbSet<PerSon> PerSons { get; set; }
        public virtual DbSet<InfoPerSon> InfoPerSons { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }        
        public virtual DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        
    }
}
