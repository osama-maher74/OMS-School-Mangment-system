using lab1.DAL;
using lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace lab1.Repo
{

  //public interface IStudentRepo
  //{

  //      List<Student> GetAll();
  //      Student Get(int id);
  //      Student Insert(Student student); 
  //      Student Update(Student student); 
  //      void Delete(int id);
  //      int Save();

  //  }


    public class StudentRepo : IEntityRepo<Student>
    {
        ITIDbContext dbContext;//= new ITIDbContext();

        public StudentRepo(ITIDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void Delete(int id)
        {
            var student = dbContext.Students.Find(id);
            if (student != null)
            {
                dbContext.Students.Remove(student);
           
            }
           
            //dbContext.Students.Where(s=>s.Id==id).ExecuteDelete(); 

        }

        public Student Get(int id)
        {
           return dbContext.Students.Include(d => d.Department).FirstOrDefault(s => s.Id == id);
        }

        public List<Student> GetAll()
        {
            return dbContext.Students.Include(d => d.Department).ToList(); 
        }

        public Student Insert(Student student)
        {
           dbContext.Students.Add(student);
            return student;
        }
        // the controler is resposible to call save method
        public int Save()
        {
          return  dbContext.SaveChanges();
        }

        public Student Update(Student student)
        {
            dbContext.Students.Update(student);
           
            return student;
        }
    }
}
