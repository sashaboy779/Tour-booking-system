using AutoMapper;
using DAL.Interface;
using Moq;

namespace BLL.Tests.Test.Abstract
{
    public abstract class ServiceTest
    {
        protected Mock<IMapper> mockMapper;
        protected Mock<IUnitOfWork> mockUnit;

        public ServiceTest()
        {
            mockMapper = new Mock<IMapper>();
            mockUnit = new Mock<IUnitOfWork>();
        }
    }
}