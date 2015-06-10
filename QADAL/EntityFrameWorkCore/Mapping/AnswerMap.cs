using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace QADAL.EntityFrameWorkCore.Mapping
{
    public class AnswerMap : EntityTypeConfiguration<Models.Answer>
    {
        public AnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.answercontent)
                .HasMaxLength(200);

            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Answer");
            this.Property(t => t.Qid).HasColumnName("Qid");
            this.Property(t => t.anserman).HasColumnName("anserman");
            this.Property(t => t.answerdate).HasColumnName("answerdate");
            this.Property(t => t.answercontent).HasColumnName("answercontent");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.state).HasColumnName("state");

            // Relationships
            this.HasOptional(t => t.question)
                .WithMany(t => t.Answers)
                .HasForeignKey(d => d.Qid);

        }
    }
}
