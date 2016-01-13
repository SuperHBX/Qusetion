using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace QADAL.Models.Mapping
{
    public class AnswerMap : EntityTypeConfiguration<Answer>
    {
        public AnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.answerman)
                .HasMaxLength(50);

            this.Property(t => t.answermanid)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Answer");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Qid).HasColumnName("Qid");
            this.Property(t => t.answerman).HasColumnName("answerman");
            this.Property(t => t.answerdate).HasColumnName("answerdate");
            this.Property(t => t.answercontent).HasColumnName("answercontent");
            this.Property(t => t.state).HasColumnName("state");
            this.Property(t => t.answermanid).HasColumnName("answermanid");

            // Relationships
            this.HasOptional(t => t.Question)
                .WithMany(t => t.Answers)
                .HasForeignKey(d => d.Qid);

        }
    }
}
