using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using HarvestBandFestival.Controllers;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using HarvestBandFestival.Models;

namespace HarvestBandFestival.Tests.Services
{
    [TestClass]
    public class ServicesTest
    {

        private Mock<IGenericRepository> _repo;

        [TestInitialize]
        public void Initialize()
        {
            _repo = new Mock<IGenericRepository>();

        }

        [TestMethod]
        public void TestToSeeIfaUserCanEditABandHesNotSupposedTo()
        {
            // arrange
            var controller = new BandsController(_repo.Object);

            var userMock = new Mock<IPrincipal>();
            

            var contextMock = new Mock<HttpContextBase>();
            contextMock.Setup(ctx => ctx.User)
                       .Returns(userMock.Object);

            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.Setup(con => con.HttpContext)
                                 .Returns(contextMock.Object);

            controller.ControllerContext = controllerContextMock.Object;

            _repo.Setup(r => r.Find<Band>(1))
                              .Returns(new Band { PrimaryContact = new ApplicationUser { UserName = "cwessel@codercamps.com" } } );

     
            var result = controller.Index();
            // act


            // assert
            Assert.AreEqual(((ViewResult)result).ViewName, "Index");
        }
    }
}
