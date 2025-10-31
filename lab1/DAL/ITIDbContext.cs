using Microsoft.EntityFrameworkCore;
using ModelLayer;

namespace lab1.DAL
{
    public class ITIDbContext :DbContext
    {
        public DbSet<Models.Student> Students { get; set; }
        public DbSet<Models.Departments> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }



        //public ITIDbContext()
        //{

        //}

        public ITIDbContext(DbContextOptions<ITIDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=OSAMA;Initial Catalog=ITI2;Integrated Security=True;Encrypt=true;Trust Server Certificate=True ");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Course>(c =>
            c.HasData(
                new Course { Id = 1, CrsName = "C#", CrsDuration = 4 },
                new Course { Id = 2, CrsName = "Java", CrsDuration = 3 },
                new Course { Id = 3, CrsName = "Python", CrsDuration = 5 }
                )


            );

            modelBuilder.Entity<Models.Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DeptID);

            modelBuilder.Entity<Models.Departments>()
                .HasMany(d => d.Students)
                .WithOne(s => s.Department)
                .HasForeignKey(s => s.DeptID);
            modelBuilder.Entity<Models.Departments>().HasKey(d => d.DeptID);

            modelBuilder.Entity<Models.Departments>(d =>
            {

                d.HasData(
                    new Models.Departments { DeptID = 1, DeptName = "CS", Capacity = 30 },
                    new Models.Departments { DeptID = 2, DeptName = "IS", Capacity = 30 },
                    new Models.Departments { DeptID = 3, DeptName = "IT", Capacity = 30 }
                );


            });


            modelBuilder.Entity<StudentCourse>(sc => {

                sc.HasKey(sc =>new { sc.StudentId ,sc.CourseId});



            });

        }
    }
}
