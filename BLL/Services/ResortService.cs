using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using AutoMapper;
using BLL.Dto.Requests;
using BLL.Dto.Responses;
using BLL.Services.Interface;
using DAL.Entity;
using DAL.Repository.Interface;

namespace BLL.Services
{
    public class ResortService : IResortService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ResortService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public ResortDto AddResort(ResortPostRequest request)
        {
            var resort = mapper.Map<Resort>(request);
            unitOfWork.Resorts.Create(resort);
            unitOfWork.Save();
            return mapper.Map<ResortDto>(resort);
        }

        public ResortDto GetResort(int id)
        {
            var resort = unitOfWork.Resorts.Get(id);
            if(resort == null)
                throw new KeyNotFoundException($"Resort with key:{id} not found");
            return mapper.Map<ResortDto>(resort);
        }

        public IEnumerable<ResortDto> GetResorts()
        {
            var resorts = unitOfWork.Resorts.GetAll();
            return mapper.Map<IEnumerable<ResortDto>>(resorts);
        }

        public void UpdateResort(ResortUpdateRequest request)
        {
            var resort = mapper.Map<Resort>(request);
            try
            {
                unitOfWork.Resorts.Update(resort);
                unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new KeyNotFoundException($"Resort with key:{request.Id} not found");
            }
        }

        public void DeleteResort(int id)
        {
            var resort = unitOfWork.Resorts.Get(id);
            if(resort == null)
                throw new KeyNotFoundException($"Resort with key:{id} not found");
            unitOfWork.Resorts.Delete(resort);
            unitOfWork.Save();
        }
    }
}
