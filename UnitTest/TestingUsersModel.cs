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
        [Fact]
        void AddUser_IsValid()
        {
            // Arrange
            
            var expected = new Users()
            {
                Password = "123",
                IdentityNo = "198012121111",
                Firstname = "Arne",
                Lastname = "Weise",
                UsersCategory = (int)UsersCategory.Librarian
            };
            var user = new UsersModel(new UsersProcessor(new MockLibsysRepo()))
            {
                Password = "123",
                IdentityNo = "198012121111",
                Firstname = "Arne",
                Lastname = "Weise",
                UsersCategory = (int)UsersCategory.Librarian
            };

            // Act
            user.AddUser();

            // Assert
            Assert.NotNull(user);
            Assert.Equal(expected.Password, user.Password);
            Assert.Equal(expected.IdentityNo, user.IdentityNo);
            Assert.Equal(expected.Firstname, user.Firstname);
            Assert.Equal(expected.UsersCategory, user.UsersCategory);
        }

        [Theory]
        [InlineData("", "as", "as", "as", UsersCategory.Librarian)]
        [InlineData("198702021212", "", "as", "as", UsersCategory.Librarian)]
        [InlineData("198702021212", "as", "", "as", UsersCategory.Librarian)]
        [InlineData("198702021212", "as", "as", "", UsersCategory.Librarian)]
        [InlineData("123213123123123123123123123", "123", "as", "", UsersCategory.Librarian)]
        [InlineData("12", "123", "as", "", UsersCategory.Librarian)]
        [InlineData("121111111111", "wdfwefwefwefwefwefwefwefwefwefewfewfwefwefwefwefwefwefwefwefewfwefwefwefwefwefwefwefwefwefewfwefwefewfewfwefwefwefw", "as", "", UsersCategory.Librarian)]
        void AddUser_ThrowsException(string identityNo, string password, string firstname, string lastname, UsersCategory usersCategory)
        {
            // Arrange
            var user = new UsersModel(new UsersProcessor(new MockLibsysRepo()))
            {
                Password = password,
                IdentityNo = identityNo,
                Firstname = firstname,
                Lastname = lastname,
                UsersCategory = (int)usersCategory
            };
            var expected = new Users()
            {
                Password = password,
                IdentityNo = identityNo,
                Firstname = firstname,
                Lastname = lastname,
                UsersCategory = (int)usersCategory
            };

            // Act
            Assert.Throws<Exception>(() => user.AddUser());

            // Assert
            Assert.NotNull(user);

        }
        [Fact]
        void EditUser_IsValid()
        {
            // Arrange

            var expected = new Users()
            {
                Password = "123",
                IdentityNo = "198012121111",
                Firstname = "Arne",
                Lastname = "Weise",
                UsersCategory = (int)UsersCategory.Librarian
            };
            var user = new UsersModel(new UsersProcessor(new MockLibsysRepo()))
            {
                Password = "123",
                IdentityNo = "198012121111",
                Firstname = "Arne",
                Lastname = "Weise",
                UsersCategory = (int)UsersCategory.Librarian
            };

            // Act
            user.EditUser();

            // Assert
            Assert.NotNull(user);
            Assert.Equal(expected.Password, user.Password);
            Assert.Equal(expected.IdentityNo, user.IdentityNo);
            Assert.Equal(expected.Firstname, user.Firstname);
            Assert.Equal(expected.UsersCategory, user.UsersCategory);
        }

        [Theory]
        [InlineData("", "as", "as", "as", UsersCategory.Librarian)]
        [InlineData("198702021212", "", "as", "as", UsersCategory.Librarian)]
        [InlineData("198702021212", "as", "", "as", UsersCategory.Librarian)]
        [InlineData("198702021212", "as", "as", "", UsersCategory.Librarian)]
        [InlineData("123213123123123123123123123", "123", "as", "", UsersCategory.Librarian)]
        [InlineData("12", "123", "as", "", UsersCategory.Librarian)]
        [InlineData("121111111111", "wdfwefwefwefwefwefwefwefwefwefewfewfwefwefwefwefwefwefwefwefewfwefwefwefwefwefwefwefwefwefewfwefwefewfewfwefwefwefw", "as", "", UsersCategory.Librarian)]
        void EditUser_ThrowsException(string identityNo, string password, string firstname, string lastname, UsersCategory usersCategory)
        {
            // Arrange
            var user = new UsersModel(new UsersProcessor(new MockLibsysRepo()))
            {
                Password = password,
                IdentityNo = identityNo,
                Firstname = firstname,
                Lastname = lastname,
                UsersCategory = (int)usersCategory
            };
            var expected = new Users()
            {
                Password = password,
                IdentityNo = identityNo,
                Firstname = firstname,
                Lastname = lastname,
                UsersCategory = (int)usersCategory
            };

            // Act
            Assert.Throws<Exception>(() => user.EditUser());

            // Assert
            Assert.NotNull(user);

        }
        [Fact]
        void RemoveUser_IsValid()
        {
            // Arrange

            var expected = new Users()
            {
                Password = "123",
                IdentityNo = "198012121111",
                Firstname = "Arne",
                Lastname = "Weise",
                UsersCategory = (int)UsersCategory.Librarian
            };
            var user = new UsersModel(new UsersProcessor(new MockLibsysRepo()))
            {
                Password = "123",
                IdentityNo = "198012121111",
                Firstname = "Arne",
                Lastname = "Weise",
                UsersCategory = (int)UsersCategory.Librarian
            };

            // Act
            user.RemoveUser();

            // Assert
            Assert.NotNull(user);
            Assert.Equal(expected.Password, user.Password);
            Assert.Equal(expected.IdentityNo, user.IdentityNo);
            Assert.Equal(expected.Firstname, user.Firstname);
            Assert.Equal(expected.UsersCategory, user.UsersCategory);
        }

        [Theory]
        [InlineData("", "as", "as", "as", UsersCategory.Librarian)]
        [InlineData("198702021212", "", "as", "as", UsersCategory.Librarian)]
        [InlineData("198702021212", "as", "", "as", UsersCategory.Librarian)]
        [InlineData("198702021212", "as", "as", "", UsersCategory.Librarian)]
        [InlineData("123213123123123123123123123", "123", "as", "", UsersCategory.Librarian)]
        [InlineData("12", "123", "as", "", UsersCategory.Librarian)]
        [InlineData("121111111111", "wdfwefwefwefwefwefwefwefwefwefewfewfwefwefwefwefwefwefwefwefewfwefwefwefwefwefwefwefwefwefewfwefwefewfewfwefwefwefw", "as", "", UsersCategory.Librarian)]
        void RemoveUser_ThrowsException(string identityNo, string password, string firstname, string lastname, UsersCategory usersCategory)
        {
            // Arrange
            var user = new UsersModel(new UsersProcessor(new MockLibsysRepo()))
            {
                Password = password,
                IdentityNo = identityNo,
                Firstname = firstname,
                Lastname = lastname,
                UsersCategory = (int)usersCategory
            };
            var expected = new Users()
            {
                Password = password,
                IdentityNo = identityNo,
                Firstname = firstname,
                Lastname = lastname,
                UsersCategory = (int)usersCategory
            };

            // Act
            Assert.Throws<Exception>(() => user.RemoveUser());

            // Assert
            Assert.NotNull(user);

        }
    }
}
