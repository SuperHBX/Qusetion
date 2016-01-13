using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace QADAL.Models.Mapping
{
    public class Select_OptionMap : EntityTypeConfiguration<Select_Option>
    {
        public Select_OptionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Select_Option");
            this.Property(t => t.SelectName).HasColumnName("SelectName");
            this.Property(t => t.party_id_from).HasColumnName("party_id_from");
            this.Property(t => t.SelectItem1).HasColumnName("SelectItem1");
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.Value).HasColumnName("Value");
            this.Property(t => t.sort).HasColumnName("sort");
            this.Property(t => t.note).HasColumnName("note");
            this.Property(t => t.Id).HasColumnName("Id");
        }
    }
}
