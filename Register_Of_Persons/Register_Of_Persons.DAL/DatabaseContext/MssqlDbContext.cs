using Microsoft.EntityFrameworkCore;
using Register_Of_Persons.DAL.Entity;

namespace Register_Of_Persons.DAL.DatabaseContext
{
    public class MssqlDbContext : DbContext
    {
        public MssqlDbContext(DbContextOptions<MssqlDbContext> options) 
            : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<PersonSkill> PersonSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonSkill>()
                .Property(ps => ps.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PersonSkill>().HasKey(x => new { x.Id, x.PersonId, x.SkillId });

            modelBuilder.Entity<PersonSkill>()
                .HasOne(x => x.Skill)
                .WithMany(i => i.PersonSkills)
                .HasForeignKey(x => x.SkillId);

            modelBuilder.Entity<PersonSkill>()
                .HasOne(x => x.Person)
                .WithMany(i => i.PersonSkills)
                .HasForeignKey(x => x.PersonId);
        }
    }
}