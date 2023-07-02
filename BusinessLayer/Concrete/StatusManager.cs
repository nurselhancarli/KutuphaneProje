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
    public class StatusManager : IStatusService
    {
        private readonly IStatusDal _statusDal;
        public StatusManager(IStatusDal statusDal)
        {
            _statusDal = statusDal;
        }
        public Status TGetById(int id)
        {
            return _statusDal.GetById(id);
        }

        public List<Status> TGetList()
        {
            return _statusDal.GetList();
        }

        public void TInsert(Status t)
        {
            _statusDal.Insert(t);
        }
    }
}
