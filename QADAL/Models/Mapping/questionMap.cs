using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace QADAL.Models.Mapping
{
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.state)
                .HasMaxLength(10);

            this.Property(t => t.regman)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Question");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.content).HasColumnName("content");
            this.Property(t => t.typeid).HasColumnName("typeid");
            this.Property(t => t.state).HasColumnName("state");
            this.Property(t => t.regman).HasColumnName("regman");
            this.Property(t => t.regdate).HasColumnName("regdate");
            this.Property(t => t.ishot).HasColumnName("ishot");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.regmanid).HasColumnName("regmanid");

            // Relationships
            this.HasOptional(t => t.Type)
                .WithMany(t => t.Questions)
                .HasForeignKey(d => d.typeid);

        }
    }
}
