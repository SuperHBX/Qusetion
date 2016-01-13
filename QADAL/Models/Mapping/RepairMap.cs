using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace QADAL.Models.Mapping
{
    public class RepairMap : EntityTypeConfiguration<Repair>
    {
        public RepairMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Repair");
            this.Property(t => t.Regman).HasColumnName("Regman");
            this.Property(t => t.Regtime).HasColumnName("Regtime");
            this.Property(t => t.Manager).HasColumnName("Manager");
            this.Property(t => t.RepairState).HasColumnName("RepairState");
            this.Property(t => t.RepairType).HasColumnName("RepairType");
            this.Property(t => t.RepairNote).HasColumnName("RepairNote");
            this.Property(t => t.CheckMan).HasColumnName("CheckMan");
            this.Property(t => t.CheckTime).HasColumnName("CheckTime");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CheckNote).HasColumnName("CheckNote");
            this.Property(t => t.CheckSate).HasColumnName("CheckSate");
        }
    }
}
