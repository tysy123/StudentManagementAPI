using StudentManagerAPI.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagerAPI.Models
{
    public class StudentFilterModel
    {
        public FilterEnum FilterType { get; set; }
        public string KeyWord { get; set; }
    }
}
