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
    public class ResortServiceTest : ServiceTest, IClassFixture<ResortFixture>
    {
        private readonly ResortFixture fixture;
        private readonly IResortService service;

        public ResortServiceTest(ResortFixture fixture)
        {
            this.fixture = fixture;
            service = new ResortService(mockMapper.Object, mockUnit.Object);
        }

        [Fact]
        public void AddResortSuccessful()
        {
            mockMapper.Setup(x => x.Map<Resort>(It.IsAny<ResortPostRequest>())).Returns(fixture.Resort);
            mockMapper.Setup(x => x.Map<ResortDto>(It.IsAny<Resort>())).Returns(fixture.ResortDto);
            
            mockUnit.Setup(x => x.Resorts.Create(It.IsAny<Resort>()));
            mockUnit.Setup(x => x.Save());

            var result = service.AddResort(fixture.ResortPostRequest);
        
            mockMapper.VerifyAll();
            mockUnit.VerifyAll();
            Assert.True(result == fixture.ResortDto);
        }
        
        [Fact]
        public void UpdateResortSuccessful()
        {
            mockMapper.Setup(x => x.Map<Resort>(It.IsAny<ResortUpdateRequest>())).Returns(fixture.Resort);
            
            mockUnit.Setup(x => x.Resorts.Update(It.IsAny<Resort>()));
            mockUnit.Setup(x => x.Save());
        
            service.UpdateResort(fixture.ResortUpdateRequest);
            
            mockMapper.VerifyAll();
            mockUnit.VerifyAll();
        }
        
        [Fact]
        public void UpdateResortThrowsException()
        {
            mockMapper.Setup(x => x.Map<Resort>(It.IsAny<ResortUpdateRequest>())).Returns(fixture.Resort);
            
            mockUnit.Setup(x => x.Resorts.Update(It.IsAny<Resort>()));
            mockUnit.Setup(x => x.Save()).Throws(new DbUpdateConcurrencyException());
        
            Assert.Throws<KeyNotFoundException>(() => service.UpdateResort(fixture.ResortUpdateRequest));
            mockMapper.VerifyAll();
            mockUnit.VerifyAll();
        }
        
        [Fact]
        public void DeleteResortSuccessful()
        {
            mockUnit.Setup(x => x.Resorts.Get(It.IsAny<int>())).Returns(fixture.Resort);
            mockUnit.Setup(x => x.Resorts.Delete(It.IsAny<Resort>()));
            mockUnit.Setup(x => x.Save());

            service.DeleteResort(1);
            mockUnit.VerifyAll();
        }
        
        [Fact]
        public void DeleteResortThrowsException()
        {
            mockUnit.Setup(x => x.Resorts.Get(It.IsAny<int>())).Returns(fixture.NullResort);

            Assert.Throws<KeyNotFoundException>(() => service.DeleteResort(1));
            mockUnit.VerifyAll();
        }
    }
}