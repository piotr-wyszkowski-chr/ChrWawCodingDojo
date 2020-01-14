using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircuitBreaker
{
    [TestClass]
    public class CircuitBreakerTests
    {
        private CIrcuitBreaker _sut;
        private bool callbackExecuted = false;

        [TestInitialize]
        public void Init()
        {
            callbackExecuted = false;
            _sut = new CIrcuitBreaker(Callback);
        }

        [TestMethod]
        public void Execute_Success_StateClosed()
        {
            _sut.State.Should().Be(CircuitBreakerState.Closed);
            _sut.Execute(Success);
            _sut.State.Should().Be(CircuitBreakerState.Closed);
        }

        [TestMethod]
        public void Execute_Failure_Under_Threshold_StateClosed()
        {
            _sut.State.Should().Be(CircuitBreakerState.Closed);
            _sut.Execute(Failure);
            _sut.Execute(Failure);
            _sut.State.Should().Be(CircuitBreakerState.Closed);
        }

        [TestMethod]
        public void Execute_Failure_Equal_Threshold_StateOpen()
        {
            _sut.State.Should().Be(CircuitBreakerState.Closed);
            _sut.Execute(Failure);
            _sut.Execute(Failure);
            _sut.Execute(Failure);
            _sut.State.Should().Be(CircuitBreakerState.Open);
        }

        [TestMethod]
        public void Execute_Failure_Before_Timeout()
        {
            _sut.State.Should().Be(CircuitBreakerState.Closed);
            _sut.Execute(Failure);
            _sut.Execute(Failure);
            _sut.Execute(Failure);
            _sut.State.Should().Be(CircuitBreakerState.Open);
            _sut.Execute(Success);
            callbackExecuted.Should().Be(true);
        }

        [TestMethod]
        public async Task Execute_Failure_After_Timeout()
        {
            _sut.State.Should().Be(CircuitBreakerState.Closed);
            _sut.Execute(Failure);
            _sut.Execute(Failure);
            _sut.Execute(Failure);
            _sut.State.Should().Be(CircuitBreakerState.Open);

            await Task.Delay(4000);


            _sut.State.Should().Be(CircuitBreakerState.HalfOpen);


            callbackExecuted.Should().Be(false);
        }

        [TestMethod]
        public async Task Execute_HalfOpen_ExecuteFailure_Open()
        {
           
            _sut.State.Should().Be(CircuitBreakerState.Closed);
            _sut.Execute(Failure);
            _sut.Execute(Failure);
            _sut.Execute(Failure);
            _sut.State.Should().Be(CircuitBreakerState.Open);

            await Task.Delay(4000);


            _sut.State.Should().Be(CircuitBreakerState.HalfOpen);

            _sut.Execute(Failure);

            _sut.State.Should().Be(CircuitBreakerState.Open);

            callbackExecuted.Should().Be(false);
        }

        [TestMethod]
        public async Task Execute_HalfOpen_ExecuteSuccess_Closed()
        {

            _sut.State.Should().Be(CircuitBreakerState.Closed);
            _sut.Execute(Failure);
            _sut.Execute(Failure);
            _sut.Execute(Failure);
            _sut.State.Should().Be(CircuitBreakerState.Open);

            await Task.Delay(4000);


            _sut.State.Should().Be(CircuitBreakerState.HalfOpen);

            _sut.Execute(Success);

            _sut.State.Should().Be(CircuitBreakerState.Closed);

            callbackExecuted.Should().Be(false);
        }

        private void Success()
        {
        }

        private void Failure()
        {
            throw new NotImplementedException();
        }

        private void Callback()
        {
            callbackExecuted = true;
        }

    }
}