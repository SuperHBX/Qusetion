using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace QADAL.EntityFrameWorkCore.Mapping
{
    public class TypeMap : EntityTypeConfiguration<Models.Type>
    {
        public TypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.typename)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("type");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.typename).HasColumnName("typename");
        }
    }
}
