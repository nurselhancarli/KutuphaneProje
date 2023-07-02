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
    public class PersonnelManager : IPersonnelService
    {
        private readonly IPersonnelDal _personnelDal;
        public PersonnelManager(IPersonnelDal personnelDal)
        {
            _personnelDal = personnelDal;
        }
        public Personnel TGetById(int id)
        {
            return _personnelDal.GetById(id);
        }

        public List<Personnel> TGetList()
        {
            return _personnelDal.GetList();
        }

        public void TInsert(Personnel t)
        {
            _personnelDal.Insert(t);
        }
    }

}
