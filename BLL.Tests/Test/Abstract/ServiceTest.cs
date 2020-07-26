using AutoMapper;
using DAL.Repository.Interface;
using Moq;

namespace BLL.Tests.Test.Abstract
{
    public abstract class ServiceTest
    {
        protected readonly Mock<IMapper> mockMapper;
        protected readonly Mock<IUnitOfWork> mockUnit;

        protected ServiceTest()
        {
            mockMapper = new Mock<IMapper>();
            mockUnit = new Mock<IUnitOfWork>();
        }
    }
}