using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Dto.Requests;
using BLL.Dto.Responses;

namespace BLL.Interface
{
    public interface IResortService
    {
        ResortDto AddResort(ResortPostRequest request);
        ResortDto GetResort(int id);
        IEnumerable<ResortDto> GetResorts();
        void UpdateResort(ResortUpdateRequest request);
        void DeleteResort(int id);
    }
}
