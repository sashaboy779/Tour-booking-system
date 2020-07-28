using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using BLL.Dto.Requests;
using BLL.Dto.Responses;
using BLL.Services;
using BLL.Services.Interface;
using BLL.Tests.Fixture;
using BLL.Tests.Test.Abstract;
using DAL.Entity;
using Moq;
using Xunit;

namespace BLL.Tests.Test
{
    public class ToursServiceTest : ServiceTest, IClassFixture<TourFixture>
    {
        private readonly TourFixture fixture;
        private readonly IToursService service;

        public ToursServiceTest(TourFixture fixture)
        {
            this.fixture = fixture;
            service = new ToursService(mockMapper.Object, mockUnit.Object);
        }

        [Fact]
        public void AddTourSuccessful()
        {
            mockMapper.Setup(x => x.Map<Tour>(It.IsAny<TourPostRequest>())).Returns(fixture.Tour);
            mockMapper.Setup(x => x.Map<TourDto>(It.IsAny<Tour>())).Returns(fixture.TourDto);
            
            mockUnit.Setup(x => x.Tours.Create(It.IsAny<Tour>()));
            mockUnit.Setup(x => x.Save());

            var result = service.AddTour(fixture.TourPostRequest);
        
            mockMapper.VerifyAll();
            mockUnit.VerifyAll();
            Assert.True(result == fixture.TourDto);
        }
        
        [Fact]
        public void AddTourThrowsException()
        {
            mockMapper.Setup(x => x.Map<Tour>(It.IsAny<TourPostRequest>())).Returns(fixture.Tour);
            
            mockUnit.Setup(x => x.Tours.Create(It.IsAny<Tour>()));
            mockUnit.Setup(x => x.Save()).Throws(new DbUpdateException());
        
            Assert.Throws<KeyNotFoundException>(() => service.AddTour(fixture.TourPostRequest));
            mockMapper.VerifyAll();
            mockUnit.VerifyAll();
        }
        
        [Fact]
        public void UpdateTourSuccessful()
        {
            mockMapper.Setup(x => x.Map<Tour>(It.IsAny<TourUpdateRequest>())).Returns(fixture.Tour);
            
            mockUnit.Setup(x => x.Tours.Update(It.IsAny<Tour>()));
            mockUnit.Setup(x => x.Save());
        
            service.UpdateTour(fixture.TourUpdateRequest);
            mockMapper.VerifyAll();
            mockUnit.VerifyAll();
        }
        
        [Fact]
        public void UpdateTourThrowsException()
        {
            mockMapper.Setup(x => x.Map<Tour>(It.IsAny<TourUpdateRequest>())).Returns(fixture.NullTour);
            
            mockUnit.Setup(x => x.Tours.Update(It.IsAny<Tour>()));
            mockUnit.Setup(x => x.Save()).Throws(new DbUpdateConcurrencyException());
        
            Assert.Throws<KeyNotFoundException>(() => service.UpdateTour(fixture.TourUpdateRequest));
            mockMapper.VerifyAll();
            mockUnit.VerifyAll();
        }
        
        [Fact]
        public void DeleteTourSuccessful()
        {
            mockUnit.Setup(x => x.Tours.Get(It.IsAny<int>())).Returns(fixture.Tour);
            mockUnit.Setup(x => x.Tours.Delete(It.IsAny<Tour>()));
            mockUnit.Setup(x => x.Save());

            service.DeleteTour(1);
            mockUnit.VerifyAll();
        }
        
        [Fact]
        public void DeleteTourThrowsException()
        {
            mockUnit.Setup(x => x.Tours.Get(It.IsAny<int>())).Returns(fixture.NullTour);

            Assert.Throws<KeyNotFoundException>(() => service.DeleteTour(1));
            mockUnit.VerifyAll();
        }
    }
}