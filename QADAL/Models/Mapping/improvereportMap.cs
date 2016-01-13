using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace QADAL.Models.Mapping
{
    public class ImprovereportMap : EntityTypeConfiguration<ImproveReport>
    {
        public ImprovereportMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.title)
                .HasMaxLength(50);

            this.Property(t => t.reportcontent)
                .HasMaxLength(200);

            this.Property(t => t.filename)
                .HasMaxLength(50);

            this.Property(t => t.regman)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Improvereport");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.regmanid).HasColumnName("regmanid");
            this.Property(t => t.regdate).HasColumnName("regdate");
            this.Property(t => t.typeid).HasColumnName("typeid");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.reportcontent).HasColumnName("reportcontent");
            this.Property(t => t.filename).HasColumnName("filename");
            this.Property(t => t.regman).HasColumnName("regman");

            // Relationships
            this.HasOptional(t => t.Type)
                .WithMany(t => t.Improvereports)
                .HasForeignKey(d => d.typeid);

        }
    }
}
