using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using BLL.Dto.Requests;
using BLL.Dto.Responses;
using BLL.Services;
using BLL.Tests.Fixture;
using BLL.Tests.Test.Abstract;
using DAL.Entity;
using Moq;
using Xunit;

namespace BLL.Tests.Test
{
    public class TourVariantServiceTest : ServiceTest, IClassFixture<TourVariantsFixture>
    {
        private TourVariantsFixture fixture;
        private TourVariantsService service;

        public TourVariantServiceTest(TourVariantsFixture fixture)
        {
            this.fixture = fixture;
            service = new TourVariantsService(mockUnit.Object, mockMapper.Object, null);
        }

        [Fact]
        public void AddTourVariantSuccessful()
        {
            mockMapper.Setup(x => x.Map<TourVariant>(It.IsAny<TourVariantPostRequest>())).Returns(fixture.TourVariant);
            mockMapper.Setup(x => x.Map<TourVariantDto>(It.IsAny<TourVariant>())).Returns(fixture.TourVariantDto);
            
            mockUnit.Setup(x => x.TourVariants.Create(It.IsAny<TourVariant>()));
            mockUnit.Setup(x => x.Save());

            var result = service.AddTourVariant(fixture.TourVariantPostRequest);
        
            mockMapper.VerifyAll();
            mockUnit.VerifyAll();
            Assert.True(result == fixture.TourVariantDto);
        }
        
        [Fact]
        public void AddTourVariantThrowsException()
        {
            mockMapper.Setup(x => x.Map<TourVariant>(It.IsAny<TourVariantPostRequest>())).Returns(fixture.TourVariant);
            
            mockUnit.Setup(x => x.TourVariants.Create(It.IsAny<TourVariant>()));
            mockUnit.Setup(x => x.Save()).Throws(new DbUpdateException());

            Assert.Throws<KeyNotFoundException>(() => service.AddTourVariant(fixture.TourVariantPostRequest));
            mockMapper.VerifyAll();
            mockUnit.VerifyAll();
        }
        
        [Fact]
        public void UpdateTourVariantSuccessful()
        {
            mockMapper.Setup(x => x.Map<TourVariant>(It.IsAny<TourVariantUpdateRequest>())).Returns(fixture.TourVariant);
            
            mockUnit.Setup(x => x.TourVariants.Update(It.IsAny<TourVariant>()));
            mockUnit.Setup(x => x.Save());
        
            service.UpdateTourVariant(fixture.TourVariantUpdateRequest);
            mockMapper.VerifyAll();
            mockUnit.VerifyAll();
        }
        
        [Fact]
        public void UpdateTourVariantThrowsKeyNotFoundException()
        {
            mockMapper.Setup(x => x.Map<TourVariant>(It.IsAny<TourVariantUpdateRequest>())).Returns(fixture.TourVariant);
            
            mockUnit.Setup(x => x.TourVariants.Update(It.IsAny<TourVariant>()));
            mockUnit.Setup(x => x.Save()).Throws(new DbUpdateConcurrencyException());
        
            Assert.Throws<KeyNotFoundException>(() => service.UpdateTourVariant(fixture.TourVariantUpdateRequest));
            mockMapper.VerifyAll();
            mockUnit.VerifyAll();
        }
        
        [Fact]
        public void UpdateTourVariantThrowsInvalidOperationException()
        {
            mockMapper.Setup(x => x.Map<TourVariant>(It.IsAny<TourVariantUpdateRequest>())).Returns(fixture.TourVariant);
            
            mockUnit.Setup(x => x.TourVariants.Update(It.IsAny<TourVariant>()));
            mockUnit.Setup(x => x.Save()).Throws(new InvalidOperationException());
        
            Assert.Throws<InvalidOperationException>(() => service.UpdateTourVariant(fixture.TourVariantUpdateRequest));
            mockMapper.VerifyAll();
            mockUnit.VerifyAll();
        }
        
        [Fact]
        public void DeleteTourVariantSuccessful()
        {
            mockUnit.Setup(x => x.TourVariants.Get(It.IsAny<int>())).Returns(fixture.TourVariant);
            mockUnit.Setup(x => x.TourVariants.Delete(It.IsAny<TourVariant>()));
            mockUnit.Setup(x => x.Save());
        
            service.DeleteTourVariant(1);
            mockUnit.VerifyAll();
        }
        
        [Fact]
        public void DeleteTourVariantThrowsException()
        {
            mockUnit.Setup(x => x.TourVariants.Get(It.IsAny<int>())).Returns(fixture.NullTourVariant);
            mockUnit.Setup(x => x.TourVariants.Delete(It.IsAny<TourVariant>()));
            mockUnit.Setup(x => x.Save());
            
            Assert.Throws<KeyNotFoundException>(() => service.DeleteTourVariant(1));
            mockUnit.Verify(x => x.TourVariants.Get(1), Times.Once);
            mockUnit.Verify(x => x.TourVariants.Delete(fixture.NullTourVariant), Times.Never);
            mockUnit.Verify(x => x.Save(), Times.Never);
        }
    }
}