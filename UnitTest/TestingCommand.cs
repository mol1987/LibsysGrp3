using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using LibsysGrp3WPF;
using Xunit;

namespace UnitTest
{
    public class CanExecuteTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new RelayCommand(x => { })
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    /// <summary>
    /// Unit test to see if RealyCommand class works.
    /// Tests whole class.
    /// </summary>
    public class TestingCommand
    {
        [Theory]
        [ClassData(typeof(CanExecuteTestData))]
        void CanExecute_IsValid(ICommand cmd)
        {
            // Arrange 
            var RelayCmd = cmd;

            // Act 
            bool actualValue = RelayCmd.CanExecute(null);

            // Assert
            Assert.True(actualValue);
        }
        [Fact]
        void CanExecuteWitPredicate_IsValid()
        {
            // Arrange 
            var RelayCmdTrue = new RelayCommand(x => { }, x => { return true; });
            var RelayCmdFalse = new RelayCommand(x => { }, x => { return false; });

            // Act 
            bool actualValueTrue = RelayCmdTrue.CanExecute(null);
            bool actualValueFalse = RelayCmdFalse.CanExecute(null);

            // Assert
            Assert.True(actualValueTrue);
            Assert.False(actualValueFalse);
        }
        [Fact]
        void CanExecuteGeneric_IsValid()
        {
            // Arrange 
            var RelayCmdTrue = new RelayCommand<string>(x => { }, x => { return true; });
            var RelayCmdFalse = new RelayCommand<string>(x => { }, x => { return false; });
            var RelayCmd = new RelayCommand<string>(x => { });

            // Act 
            bool actualValueTrue = RelayCmdTrue.CanExecute(null);
            bool actualValueFalse = RelayCmdFalse.CanExecute(null);
            bool actualValue = RelayCmd.CanExecute(null);

            // Assert
            Assert.True(actualValueTrue);
            Assert.False(actualValueFalse);
            Assert.True(actualValue);
        }
        [Fact]
        void Execute_IsValid()
        {
            // Arrange
            bool testFlag = false;
            var RelayCmd = new RelayCommand(x => { testFlag = true; });

            // Act
            RelayCmd.Execute(null);

            // Assert
            Assert.True(testFlag);
        }
        void ExecuteGeneric_IsValid()
        {
            // Arrange
            bool testFlag = false;
            var RelayCmd = new RelayCommand<string>(x => { testFlag = true; });

            // Act
            RelayCmd.Execute(null);

            // Assert
            Assert.True(testFlag);
        }

        [Fact]
        public void some_tests()
        {
            Assert.True(true);
        }
    }
}
