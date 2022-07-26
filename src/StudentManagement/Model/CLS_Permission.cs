using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSchool.Model
{
    public class CLS_Permission : CLS_Student
    {
        public int PermissionId { get; set; }
        public string date { get; set; }
        public string Reason { get; set; }
    }
}
