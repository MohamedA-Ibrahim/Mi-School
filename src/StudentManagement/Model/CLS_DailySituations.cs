using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSchool.Model
{
    public class CLS_DailySituations : CLS_Student
    {
        public int DailyId { get; set; }
        public string date { get; set; }
        public string Problem { get; set; }
        public string Solution { get; set; }
    }
}
