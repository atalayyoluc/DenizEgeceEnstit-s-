using Entity.Dtos.Users;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Abstractions
{
    public interface IUserService
    {
        List<UserListDtos> GetAllUser();
    }
}
