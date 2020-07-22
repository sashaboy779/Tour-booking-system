using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL.Dto.Responses;
using BLL.Services;
using BLL.Tests.Fixture;
using BLL.Tests.Test.Abstract;
using DAL.Entity;
using Moq;
using Xunit;
using TourType = BLL.Dto.Enums.TourType;

namespace BLL.Tests.Test
{
    public class SearchServiceTest : ServiceTest, IClassFixture<SearchFixture>
    {
        private SearchFixture fixture;

        public SearchServiceTest(SearchFixture fixture)
        {
            this.fixture = fixture;
        }
        
        [Fact]
        public void GetTourByIdTest()
        {
            mockMapper.Setup(x => x.Map<TourDto>(It.IsAny<Tour>())).Returns(fixture.TourDto);
            mockUnit.Setup(x => x.Tours.Get(It.IsAny<int>())).Returns(fixture.Tour);
            
            var service = new SearchService(mockUnit.Object, mockMapper.Object);
            var result = service.GetTourById(1);
            
            mockMapper.Verify(x => x.Map<TourDto>(fixture.Tour), Times.Once);
            mockUnit.Verify(x => x.Tours.Get(1), Times.Once);
            Assert.True(result.Id == 1);
            Assert.True(result.Name == "Test Tour");
        }
        
        [Fact]
        public void GetResortByIdTest()
        {
            mockMapper.Setup(x => x.Map<ResortDto>(It.IsAny<Resort>())).Returns(fixture.ResortDto);
            mockUnit.Setup(x => x.Resorts.Get(It.IsAny<int>())).Returns(fixture.Resort);
            
            var service = new SearchService(mockUnit.Object, mockMapper.Object);
            var result = service.GetResortById(1);
            
            mockMapper.Verify(x => x.Map<ResortDto>(fixture.Resort), Times.Once);
            mockUnit.Verify(x => x.Resorts.Get(1), Times.Once);
            Assert.True(result.Id == 1);
            Assert.True(result.Name == "Test Resort");
        }
        
        [Fact]
        public void GetResortTest()
        {
            mockMapper.Setup(x => x.Map<List<ResortDto>>(It.IsAny<List<Resort>>())).Returns(fixture.ResortsDto);
            mockUnit.Setup(x => x.Resorts.Find(It.IsAny<Expression<Func<Resort, bool>>>())).Returns(fixture.Resorts);
            
            var service = new SearchService(mockUnit.Object, mockMapper.Object);
            var result = service.GetResorts(fixture.ResortParameters);
                
            mockMapper.Verify(x => x.Map<List<ResortDto>>(fixture.Resorts), Times.Once);
            mockUnit.Verify(x => x.Resorts.Find(It.IsAny<Expression<Func<Resort, bool>>>()), Times.Once);
            Assert.Equal(result, fixture.ResortsDto);
        }
        
        [Fact]
        public void GetToursTest()
        {
            mockMapper.Setup(x => x.Map<DAL.Entity.TourType>(It.IsAny<TourType>())).Returns(fixture.TourType);
            mockMapper.Setup(x => x.Map<List<TourDto>>(It.IsAny<List<Tour>>())).Returns(fixture.ToursDto);
            
            mockUnit.Setup(x => x.Tours.Find(It.IsAny<Expression<Func<Tour, bool>>>())).Returns(fixture.Tours);
            
            var service = new SearchService(mockUnit.Object, mockMapper.Object);
            var result = service.GetTours(fixture.TourParameters);
                
            mockMapper.Verify(x => x.Map<DAL.Entity.TourType>(fixture.TourParameters.TourType), Times.Once);
            mockMapper.Verify(x => x.Map<List<TourDto>>(fixture.Tours), Times.Once);
            mockUnit.Verify(x => x.Tours.Find(It.IsAny<Expression<Func<Tour, bool>>>()), Times.Once);
            Assert.Equal(result, fixture.ToursDto);
        }

        [Fact]
        public void GetToursByRatingMoreTest()
        {
            mockMapper.Setup(x => x.Map<List<TourDto>>(It.IsAny<List<Tour>>())).Returns(fixture.ToursDto);
            mockUnit.Setup(x => x.Tours.Find(It.IsAny<Expression<Func<Tour, bool>>>())).Returns(fixture.Tours);
            
            var service = new SearchService(mockUnit.Object, mockMapper.Object);
            var result = service.GetToursByRatingMore(1);
                
            mockMapper.Verify(x => x.Map<List<TourDto>>(fixture.Tours), Times.Once);
            mockUnit.Verify(x => x.Tours.Find(It.IsAny<Expression<Func<Tour, bool>>>()), Times.Once);
            Assert.Equal(result, fixture.ToursDto);
        }
    }
}