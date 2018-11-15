using System;
using System.Web.Mvc;
using System.Net;
//using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieStore.Controllers;
using MovieStore.Models;
using Moq;

/*
using System.Web.Mvc;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieStore.Controllers;
using MovieStore.Models;
using Moq;
*/

namespace MovieStore.Tests.Controllers
{
    [TestClass]
    public class MovieStoreControllerTest
    {
        [TestMethod]
        public void MovieStore_Index_TestView()
        {
            // Arrange
            MoviesController controller = new MoviesController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_ListOfMovies()
        {
            // Arrange
            MoviesController controller = new MoviesController();

            // Act
            var result = controller.ListOfMovies();

            // Assert
            Assert.AreEqual("Terminator 1", result[0].Title);
            Assert.AreEqual("Terminator 2", result[1].Title);
            Assert.AreEqual("Terminator 3", result[2].Title);
        }

        [TestMethod]
        public void MovieStore_IndexRedirect_Success()
        {
            // Arrange
            MoviesController controller = new MoviesController();

            // Act
            var result = controller.IndexRedirect(1) as RedirectToRouteResult;

            //Assert
            Assert.AreEqual("Create", result.RouteValues["action"]);
            Assert.AreEqual("HomeController", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void MovieStore_IndexRedirect_BadRequest()
        {
            // Arrange
            MoviesController controller = new MoviesController();

            // Act
            var result = controller.IndexRedirect(0) as HttpStatusCodeResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode) result.StatusCode);

        }

        [TestMethod]
        public void MovieStore_ListFromDb()
        {
            // Arrange

            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock <DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();     // Error starts from here

            var list = new List<Movie> {
                        new Movie {MovieId=1, Title="Jaws" },
                        new Movie {MovieId=2, Title="Despicable Me" }

            }.AsQueryable();
          
            mockSet.As<IQueryable>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.As<IQueryable>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.As<IQueryable>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            
            //Controller needs a mock object for Dependency Injection
            MoviesController controller = new MoviesController(mockContext.Object);
            
            // Act
            ViewResult result = controller.ListFromDb() as ViewResult;
            List<Movie> resultModel = result.Model as List<Movie>;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("jaws", resultModel[0].Title);
            Assert.AreEqual("Despicable Me", resultModel[1].Title);
        }
    }
}


/*
using System;
using System.Web.Mvc;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieStore.Controllers;
using MovieStore.Models;
using Moq;

namespace MovieStore.Tests.Controllers
{
    [TestClass]
    public class MovieStoreControllerTest
    {
        [TestMethod]
        public void MovieStore_Index_TestView()
        {
            // Arrange
            MoviesController controller = new MoviesController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_ListOfMovies()
        {
            // Arrange
            MoviesController controller = new MoviesController();

            // Act
            var result = controller.ListOfMovies();

            // Assert
            Assert.AreEqual("Terminator 1", result[0].Title);
            Assert.AreEqual("Terminator 2", result[1].Title);
            Assert.AreEqual("Terminator 3", result[2].Title);
        }

        [TestMethod]
        public void MovieStore_IndexRedirect_Success()
        {
            // Arrange
            MoviesController controller = new MoviesController();

            // Act
            var result = controller.IndexRedirect(1) as RedirectToRouteResult;

            //Assert
            Assert.AreEqual("Create", result.RouteValues["action"]);
            Assert.AreEqual("HomeController", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void MovieStore_IndexRedirect_BadRequest()
        {
            // Arrange
            MoviesController controller = new MoviesController();

            // Act
            var result = controller.IndexRedirect(0) as HttpStatusCodeResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode) result.StatusCode);

        }

        [TestMethod]

        public void MovieStore_ListFromDb()
        {
            // Arrange
            MoviesController controller = new MoviesController();
            //mockDB using Moq

            // Act
            ViewResult result = controller.ListFromDb() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
} 
     
*/
