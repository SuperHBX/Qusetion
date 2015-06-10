using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace QADAL.EntityFrameWorkCore.Mapping
{
    public class QuestionMap : EntityTypeConfiguration<Models.Question>
    {
        public QuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.content)
                .HasMaxLength(200);

            this.Property(t => t.state)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("question");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.content).HasColumnName("content");
            this.Property(t => t.typeid).HasColumnName("typeid");
            this.Property(t => t.state).HasColumnName("state");
            this.Property(t => t.regman).HasColumnName("regman");
            this.Property(t => t.regdate).HasColumnName("regdate");
            this.Property(t => t.ishot).HasColumnName("ishot");

            // Relationships
            this.HasOptional(t => t.type)
                .WithMany(t => t.questions)
                .HasForeignKey(d => d.typeid);

        }
    }
}
