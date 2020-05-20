using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Dto.Requests;
using BLL.Dto.Responses;
using BLL.Interface;
using DAL.Entity;
using DAL.Interface;

namespace BLL.Services
{
    public class ResortService : IResortService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ResortService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ResortDto AddResort(ResortPostRequest request)
        {
            var resort = _mapper.Map<Resort>(request);
            _unitOfWork.Resorts.Create(resort);
            _unitOfWork.Save();
            return _mapper.Map<ResortDto>(resort);
        }

        public ResortDto GetResort(int id)
        {
            var resort = _unitOfWork.Resorts.Get(id);
            if(resort == null)
                throw new KeyNotFoundException($"Resort with key:{id} not found");
            return _mapper.Map<ResortDto>(resort);
        }

        public IEnumerable<ResortDto> GetResorts()
        {
            var resorts = _unitOfWork.Resorts.GetAll();
            return _mapper.Map<IEnumerable<ResortDto>>(resorts);
        }

        public void UpdateResort(ResortUpdateRequest request)
        {
            var resort = _mapper.Map<Resort>(request);
            try
            {
                _unitOfWork.Resorts.Update(resort);
                _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(resort == null)
                    throw new KeyNotFoundException($"Resort with key:{request.Id} not found");
            }
        }

        public void DeleteResort(int id)
        {
            var resort = _unitOfWork.Resorts.Get(id);
            if(resort == null)
                throw new KeyNotFoundException($"Resort with key:{id} not found");
            _unitOfWork.Resorts.Delete(resort);
            _unitOfWork.Save();
        }
    }
}
