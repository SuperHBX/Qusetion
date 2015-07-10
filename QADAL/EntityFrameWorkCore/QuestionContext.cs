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
            AutomaticMigrationsEnabled = true;//�κ�Model Class���޸Ľ����Զ��������ݿ�
            AutomaticMigrationDataLossAllowed = true;//���Խ����Զ�Ǩ���ڼ�����ݶ�ʧ��ֵ
        }
    }
}
