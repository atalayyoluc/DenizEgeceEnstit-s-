using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.Users
{
    public class UserListDtos
    {
        public string UserName { get; set; }
        public string InvitedByName { get; set; }
        public string PostTitle { get; set; }
        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
    }
}
