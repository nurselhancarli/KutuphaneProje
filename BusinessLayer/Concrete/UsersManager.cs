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
    public class UsersManager : IUsersService
    {
        private readonly IUsersDal _usersDal;
        public UsersManager(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }
        public Users TGetById(int id)
        {
            return _usersDal.GetById(id);
        }

        public List<Users> TGetList()
        {
            return _usersDal.GetList();
        }

        public void TInsert(Users t)
        {
            _usersDal.Insert(t);
        }
    }
}
