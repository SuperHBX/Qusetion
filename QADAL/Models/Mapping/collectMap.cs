using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace QADAL.Models.Mapping
{
    public class CollectMap : EntityTypeConfiguration<Collect>
    {
        public CollectMap()
        {
            // Primary Key
            this.HasKey(t => new { t.personid, t.Qid });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.personid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Qid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.name)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Collect");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.personid).HasColumnName("personid");
            this.Property(t => t.Qid).HasColumnName("Qid");
            this.Property(t => t.collecttime).HasColumnName("collecttime");
            this.Property(t => t.name).HasColumnName("name");

            // Relationships
            this.HasRequired(t => t.Question)
                .WithMany(t => t.Collects)
                .HasForeignKey(d => d.Qid);

        }
    }
}
