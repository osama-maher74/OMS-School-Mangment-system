using lab1.DAL;
using lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace lab1.Repo
{

    //public interface IDEpartmentRepo
    //{

    //    List<Departments> GetAll();
    //    Departments Get(int id);
    //    Departments Insert(Departments department);
    //    Departments Update(Departments department);
    //    void Delete(int id);
    //    int Save();
    //}
    public class DEpartmentRepo : IEntityRepo<Departments>
    {

        ITIDbContext dbContext;// = new ITIDbContext();

        public DEpartmentRepo(ITIDbContext _dbContext)
        {
            dbContext= _dbContext;
        }
        public void Delete(int id)
        {
            var department = dbContext.Departments.Include(d => d.Students).FirstOrDefault(d => d.DeptID == id);
            if (department.Students.Count==0)
            {
                dbContext.Departments.Remove(department);
            }
            else
            {
                department.Status = false;
                //dbContext.Departments.Update(department);
                Update(department);
            }
        }

        public Departments Get(int id)
        {
           return dbContext.Departments.Find(id);
        }

        public List<Departments> GetAll()
        {
            return dbContext.Departments.Where(d=>d.Status==true).ToList();
        }

        public Departments Insert(Departments department)
        {
            dbContext.Departments.Add(department);
            return department;
        }

        public int Save()
        {
            return dbContext.SaveChanges();
        }

        public Departments Update(Departments department)
        {
            dbContext.Departments.Update(department);
            return department;
        }
    }
}
