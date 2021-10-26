using interview_yungching.DataAccess;
using interview_yungching.Models;
using interview_yungching.Services;
using Moq;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MyTestProject
{
    public class UnitTest1
    {
        //private readonly ICustomerService _mockService = Substitute.For<ICustomerService>();
        private readonly ICustomerDA _mockDA = Substitute.For<ICustomerDA>();

        public CustomerService GetSystemUnderTest()
        {
            return new CustomerService(_mockDA);
        }

        [Theory]
        [InlineData("TEST1")]
        [InlineData("TEST9")]
        public void Test_CreateCustomer(string customerId)
        {
            //Arrange
            var sut = this.GetSystemUnderTest();
            var request = new CustomerRequest
            {
                CustomerId = customerId,
                CompanyName = "company",
                ContactName = "CN",
                ContactTitle = "CT",
                Address = "here",
                City = "TP",
                Region = "r",
                PostalCode = "pCode",
                Country = "Taiwan",
                Phone = "0955588669",
                Fax = "02-55558888"
            };
            //後方Returns可指定回傳值
            this._mockDA.ExistCustomer("TEST1").Returns(true);
            this._mockDA.ExistCustomer("TEST9").Returns(false);
            this._mockDA.CreateCustomer(Arg.Any<CustomerRequest>()).Returns(true);

            //預期收到結果
            var expected = "TEST1" != customerId;

            //Act
            //實際結果
            var actual = sut.CreateCustomer(request);

            //Assert
            //Reveived內的參數為預期CreateProject收到幾次，後方可設定預期接收到的參數
            this._mockDA.Received(1).ExistCustomer(customerId);
            this._mockDA.Received("TEST1" == customerId ? 0 : 1).CreateCustomer(request);

            //比對實際結果以及預期結果
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_UpdateCustomer()
        {
            //Arrange
            var sut = this.GetSystemUnderTest();
            var request = new CustomerRequest
            {
                CustomerId = "TEST1",
                CompanyName = "company",
                ContactName = "CN",
                ContactTitle = "CT",
                Address = "here",
                City = "TP",
                Region = "r",
                PostalCode = "pCode",
                Country = "Taiwan",
                Phone = "0955588669",
                Fax = "02-55558888"
            };
            //後方Returns可指定回傳值
            this._mockDA.UpdateCustomer(Arg.Any<CustomerRequest>()).Returns(true);

            //預期收到結果
            var expected = true;

            //Act
            //實際結果
            var actual = sut.UpdateCustomer(request);

            //Assert
            //Reveived內的參數為預期CreateProject收到幾次，後方可設定預期接收到的參數
            this._mockDA.Received(1).UpdateCustomer(request);

            //比對實際結果以及預期結果
            Assert.Equal(expected, actual);
        }


    }
}
