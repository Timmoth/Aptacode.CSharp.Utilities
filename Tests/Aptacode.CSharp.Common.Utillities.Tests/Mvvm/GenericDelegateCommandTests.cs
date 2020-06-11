﻿using Aptacode.CSharp.Common.Utilities.Mvvm;
using Xunit;

namespace Aptacode.CSharp.Common.Utilities.Tests.Mvvm
{
    public class GenericDelegateCommandTests
    {
        [Fact]
        public void CommandParameterIsPassedToCanExecutePredicate()
        {
            //Arrange
            var commandParameterValue = false;
            var sut = new DelegateCommand<bool>(_ => { }, value =>
            {
                commandParameterValue = value;
                return true;
            });

            //Act
            sut.Execute(true);

            //Assert
            Assert.True(commandParameterValue);
        }


        [Fact]
        public void CommandParameterIsPassedToExecuteAction()
        {
            //Arrange
            var commandParameterValue = false;
            var sut = new DelegateCommand<bool>(value => commandParameterValue = value, _ => true);

            //Act
            sut.Execute(true);

            //Assert
            Assert.True(commandParameterValue);
        }

        [Fact]
        public void DelegateCommandCanExecuteChangedCanFire()
        {
            //Arrange
            var canExecuteChangedFired = false;
            var sut = new DelegateCommand<bool>(_ => { }, _ => true);

            sut.CanExecuteChanged += (s, e) => { canExecuteChangedFired = true; };

            //Act
            sut.RaiseCanExecuteChanged();

            //Assert
            Assert.True(canExecuteChangedFired);
        }

        [Fact]
        public void DelegateCommandCanFireWhenCanExecuteIsNotSet()
        {
            //Arrange
            var commandFired = false;
            var sut = new DelegateCommand<bool>(_ => { commandFired = true; });

            //Act
            sut.Execute(true);

            //Assert
            Assert.True(commandFired);
        }

        [Fact]
        public void DelegateCommandCanFireWhenCanExecuteIsTrue()
        {
            //Arrange
            var commandFired = false;
            var sut = new DelegateCommand<bool>(_ => { commandFired = true; }, _ => true);

            //Act
            sut.Execute(false);

            //Assert
            Assert.True(commandFired);
        }

        [Fact]
        public void DelegateCommandDoesNotFireWhenCanExecuteIsFalse()
        {
            //Arrange
            var commandFired = false;
            var sut = new DelegateCommand<bool>(_ => { commandFired = true; }, _ => false);

            //Act
            sut.Execute(null);

            //Assert
            Assert.False(commandFired);
        }
    }
}