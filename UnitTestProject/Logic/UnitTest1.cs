using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoFixture;
using photoN;
using Moq;

namespace UnitTestProject
{
   [TestClass]
   public class UnitTest1
   {
      [TestMethod]
      public void TestMethod1()
      {
         // Arrange
         int x = 1;
         int y = 1;
         int w = 1;
         int h = 1;
         int depth = 1;
         var view = new ViewportClass();

         // Act
         double[,] result = view.ViewportRes(x, y, w, h, depth);

         //Assert 
         Assert.IsNotNull(result);
      }

      [TestMethod]
      public void TestMethod2ByMock()
      {
         // Arrange
         var mock = new Mock<IViewport>();
         int x = 1;
         int y = 1;
         int w = 1;
         int h = 1;
         int depth = 1;
         var view = new ViewportClass();

         mock.Setup(v => v.Viewport());

         // Act
         double[,] result = view.ViewportRes(x, y, w, h, depth);
         
         //Assert 
         Assert.IsNotNull(result);
      }
   }
}
