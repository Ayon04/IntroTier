using DAL.EF;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class TaskRepo
    {
        private CMSContext db;

        public TaskRepo()
        {
            db = new CMSContext();
        }

        public void Create(Task c)
        {
            db.Tasks.Add(c);
            db.SaveChanges();
        }

        public List<Task> GetAll()
        {
            return db.Tasks.ToList();
        }

        public void Update(Task c)
        {
            var exobj = db.Tasks.Find(c.Id);
            if (exobj != null)
            {
                db.Entry(exobj).CurrentValues.SetValues(c);
                db.SaveChanges();
            }
        }

        public Task GetById(int id)
        {
            return db.Tasks.Find(id); 
        }


    }
}
