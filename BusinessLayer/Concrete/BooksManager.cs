using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BooksManager : IBooksService
    {
        private readonly IBooksDal _booksDal;
        public BooksManager(IBooksDal booksDal)
        {
            _booksDal = booksDal;
        }
        public Books TGetById(int id)
        {
            return _booksDal.GetById(id);
        }

        public List<Books> TGetList()
        {
            return _booksDal.GetList();
        }

        public void TInsert(Books t)
        {
            _booksDal.Insert(t);
        }

        public void TUpdate(Books t)
        {
            _booksDal.Update(t);

        }
    }
}
