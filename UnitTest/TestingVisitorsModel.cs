using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
//using UtilLibrary.MsSqlRepsoitory;
using LibsysGrp3WPF;

namespace UnitTest
{
    public class TestingVisitorsModel
    {
        [Fact]
        void LoginVisitor_IsValid()
        {
            // Arrange 
            var visitors = new VisitorsModel(new VisitorsProcessor());

            // Act 
            visitors.LoginVisitor("198012121111", "123");

            // Assert
            Assert.NotNull(visitors);
        }
    }
}
