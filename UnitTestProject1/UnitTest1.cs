using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using interview_yungching.Services;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new Mock<ICustomerService>();
        }
    }
}
