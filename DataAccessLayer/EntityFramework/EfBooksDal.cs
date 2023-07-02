using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBooksDal : GenericRepository<Books>, IBooksDal
    {
        public void Update(Books t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }

    }
}
