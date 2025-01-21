using DAL.EF;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class ContactRepo
    {
        private CMSContext db;

        public ContactRepo()
        {
            db = new CMSContext();
        }

        public void Create(Contact c)
        {
            db.Contacts.Add(c);
            db.SaveChanges();
        }

        public List<Contact> GetAll()
        {
            return db.Contacts.ToList();
        }

        public List<Contact> GetByName(string name)
        {
            return db.Contacts.Where(c => c.Name == name).ToList();
        }

        public void Update(Contact c)
        {
            var exobj = db.Contacts.Find(c.Id);
            if (exobj != null)
            {
                db.Entry(exobj).CurrentValues.SetValues(c);
                db.SaveChanges();
            }
        }

        public Contact GetById(int id)
        {
            return db.Contacts.Find(id); 
        }

        public void Delete(int id)
        {
            var exobj = db.Contacts.Find(id);
            if (exobj != null)
            {
                db.Contacts.Remove(exobj);
                db.SaveChanges();
            }
        }

        public List<Contact> GetByCategory(string category)
        {
            return db.Contacts.Where(c => c.Category == category).ToList(); 
        }

    }
}
