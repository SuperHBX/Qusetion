using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;

namespace QADAL.EntityFrameWorkCore
{
    public partial class QuestionContext : DbContext, UnitOfWorkCore.IUnitOfWork
    {
        static QuestionContext()
        {
            Database.SetInitializer<QuestionContext>(null);
        }

        public QuestionContext()
            : base("Name=QuestionContext")
        {
        }

        public DbSet<Models.Answer> Answers { get; set; }
        public DbSet<Models.Collect> collects { get; set; }
        public DbSet<Models.ImproveReport> improvereports { get; set; }
        public DbSet<Models.Question> questions { get; set; }
       
        public DbSet<Models.Type> types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Mapping.AnswerMap());
            modelBuilder.Configurations.Add(new Mapping.CollectMap());
            modelBuilder.Configurations.Add(new Mapping.ImprovereportMap());
            modelBuilder.Configurations.Add(new Mapping.QuestionMap());          
            modelBuilder.Configurations.Add(new Mapping.TypeMap());
        }

        public void Save()
        {
            try
            {
                this.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool IsNotSubmit { get; set; }
    }
    internal sealed class EFDbMigrationsConfiguration : DbMigrationsConfiguration<QuestionContext>
    {
        public EFDbMigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = true;//任何Model Class的修改将会自动更新数据库
            AutomaticMigrationDataLossAllowed = true;//可以接受自动迁移期间的数据丢失的值
        }
    }
}
