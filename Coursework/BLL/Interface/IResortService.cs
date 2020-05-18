using System.Collections.Generic;
using BLL.Dto.Requests;
using BLL.Dto.Responses;

namespace BLL.Interface
{
    internal interface IResortService
    {
        ResortDto AddResort(ResortPostRequest request);
        ResortDto GetResort(int id);
        IEnumerable<ResortDto> GetResorts();
        void UpdateResort(ResortUpdateRequest request);
        void DeleteResort(int id);
    }
}