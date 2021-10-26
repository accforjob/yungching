using interview_yungching.DataAccess;
using interview_yungching.Models;
using interview_yungching.Services;
using Moq;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

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
            //���Returns�i���w�^�ǭ�
            this._mockDA.ExistCustomer("TEST1").Returns(true);
            this._mockDA.ExistCustomer("TEST9").Returns(false);
            this._mockDA.CreateCustomer(Arg.Any<CustomerRequest>()).Returns(true);

            //�w�����쵲�G
            var expected = "TEST1" != customerId;

            //Act
            //��ڵ��G
            var actual = sut.CreateCustomer(request);

            //Assert
            //Reveived�����ѼƬ��w��CreateProject����X���A���i�]�w�w�������쪺�Ѽ�
            this._mockDA.Received(1).ExistCustomer(customerId);
            this._mockDA.Received("TEST1" == customerId ? 0 : 1).CreateCustomer(request);

            //����ڵ��G�H�ιw�����G
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
            //���Returns�i���w�^�ǭ�
            this._mockDA.UpdateCustomer(Arg.Any<CustomerRequest>()).Returns(true);

            //�w�����쵲�G
            var expected = true;

            //Act
            //��ڵ��G
            var actual = sut.UpdateCustomer(request);

            //Assert
            //Reveived�����ѼƬ��w��CreateProject����X���A���i�]�w�w�������쪺�Ѽ�
            this._mockDA.Received(1).UpdateCustomer(request);

            //����ڵ��G�H�ιw�����G
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_DeleteCustomer()
        {
            //Arrange
            var sut = this.GetSystemUnderTest();
            var customerId = "TEST1";

            //���Returns�i���w�^�ǭ�
            this._mockDA.DeleteCustomer(Arg.Any<string>()).Returns(true);

            //�w�����쵲�G
            var expected = true;

            //Act
            //��ڵ��G
            var actual = sut.DeleteCustomer(customerId);

            //Assert
            //Reveived�����ѼƬ��w��CreateProject����X���A���i�]�w�w�������쪺�Ѽ�
            this._mockDA.Received(1).DeleteCustomer(customerId);

            //����ڵ��G�H�ιw�����G
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("TEST1")]
        [InlineData("TEST9")]
        public void Test_GetCustomer(string customerId)
        {
            //Arrange
            var sut = this.GetSystemUnderTest();

            //���Returns�i���w�^�ǭ�
            this._mockDA.GetCustomer("TEST1").Returns(new Customer
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
            });

            this._mockDA.GetCustomer("TEST9").Returns(new Customer());

            //�w�����쵲�G
            var expected = new Customer();
            if ("TEST1" == customerId)
            {
                expected = new Customer
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
            }

            //Act
            //��ڵ��G
            var actual = sut.GetCustomer(customerId);

            //Assert
            //Reveived�����ѼƬ��w��CreateProject����X���A���i�]�w�w�������쪺�Ѽ�
            this._mockDA.Received(1).GetCustomer(customerId);

            //����ڵ��G�H�ιw�����G
            expected.Should().BeEquivalentTo(actual);
        }


    }
}
