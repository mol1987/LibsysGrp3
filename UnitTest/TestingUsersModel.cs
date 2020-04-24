using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using UtilLibrary.MsSqlRepsoitory;
using LibsysGrp3WPF;
using Autofac.Extras.Moq;
using Moq;

namespace UnitTest
{
    public class TestingUsersModel
    {
        private readonly ITestOutputHelper output;

        public TestingUsersModel(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        void LoginUser_IsValid()
        {
            // Arrange
            var user = new UsersModel(new UsersProcessor(new MockLibsysRepo()));
            var expected = new Users()
            {
                Password = "123",
                IdentityNo = "198012121111"                
            };

            // Act
            user.LoginUser(expected.IdentityNo, expected.Password);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(expected.Password, user.Password);
            output.WriteLine("This is output from {0}", user.Password);
            Assert.Equal(expected.IdentityNo, user.IdentityNo);
        }

        [Theory]
        [InlineData("", "as")]
        [InlineData("df", "")]
        [InlineData("123213123123123123123123123", "123")]
        [InlineData("12", "123")]
        [InlineData("121111111111", "wdfwefwefwefwefwefwefwefwefwefewfewfwefwefwefwefwefwefwefwefewfwefwefwefwefwefwefwefwefwefewfwefwefewfewfwefwefwefw")]
        void LoginUser_ThrowsException(string identityNo, string password)
        {
            // Arrange
            var user = new UsersModel(new UsersProcessor(new MockLibsysRepo()));
            var expected = new Users()
            {
                Password = identityNo,
                IdentityNo = password
            };

            // Act
            Assert.Throws<Exception>(() => user.LoginUser(expected.IdentityNo, expected.Password));

            // Assert
            Assert.NotNull(user);
            
        }
    }
}
