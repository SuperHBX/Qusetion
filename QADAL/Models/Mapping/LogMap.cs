using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace QADAL.Models.Mapping
{
    public class LogMap : EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Log");
            this.Property(t => t.DayLog).HasColumnName("DayLog");
            this.Property(t => t.RegMan).HasColumnName("RegMan");
            this.Property(t => t.RegTime).HasColumnName("RegTime");
            this.Property(t => t.Adress).HasColumnName("Adress");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.Id).HasColumnName("Id");
        }
    }
}
