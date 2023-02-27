using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserServices
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);

        IResult AddUser(User user);
        IResult UpdateUser(User user);
        IResult DeleteUser(User user);
    }
}
