using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSchool.Model
{
    public class CLS_User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserGuid { get; set; }
        public string UserNickName { get; set; }
        public string UserRole { get; set; }
    }
}
