using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace QADAL.Models.Mapping
{
    public class TypeMap : EntityTypeConfiguration<Type>
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
            this.ToTable("Type");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.typename).HasColumnName("typename");
            this.Property(t => t.img).HasColumnName("img");
        }
    }
}
