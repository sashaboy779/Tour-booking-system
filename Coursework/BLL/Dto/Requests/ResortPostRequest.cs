using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto.Requests
{
    public class ResortPostRequest
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
