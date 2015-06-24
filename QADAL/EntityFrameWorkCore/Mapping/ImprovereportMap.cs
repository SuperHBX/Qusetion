using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace QADAL.EntityFrameWorkCore.Mapping
{
    public class ImprovereportMap : EntityTypeConfiguration<Models.ImproveReport>
    {
        public ImprovereportMap()
        {
            // Primary Key
            this.HasKey(t => t.regmanid);

            // Properties
            this.Property(t => t.regmanid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.title)
                .HasMaxLength(50);

            this.Property(t => t.reportcontent)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("improvereport");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.regmanid).HasColumnName("regmanid");
            this.Property(t => t.regdate).HasColumnName("regdate");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.reportcontent).HasColumnName("reportcontent");

            // Relationships
            this.HasOptional(t => t.type1)
                .WithMany(t => t.improvereports)
                .HasForeignKey(d => d.type);

        }
    }
}
