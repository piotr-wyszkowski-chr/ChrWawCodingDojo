using System;
using System.Threading;
using System.Threading.Tasks;

namespace CircuitBreaker
{
    public class CIrcuitBreaker
    {
        public CIrcuitBreaker(Action callback)
        {
            openCallback = callback;
        }

        private const int Threshold = 3;
        private const int ThresholdTimeout = 3000;
        private int failureCount = 0;
        private Action openCallback;

        public void Execute(Action action)
        {
            try
            {
                if (State == CircuitBreakerState.Open)
                {
                    openCallback.Invoke();
                }
                else
                {


                    action.Invoke();
                    State = CircuitBreakerState.Closed;
                    failureCount = 0;
                }
            }
            catch (Exception e)
            {
                failureCount++;
                if (failureCount >= Threshold && State != CircuitBreakerState.Open)
                {
                    State = CircuitBreakerState.Open;
                    Task.Run(async () =>
                    {
                        await Task.Delay(ThresholdTimeout);
                        State = CircuitBreakerState.HalfOpen;
                    });
                }
            }
        }

        public CircuitBreakerState State { get; private set; } = CircuitBreakerState.Closed;
    }

    public enum CircuitBreakerState
    {
        Closed = 1,
        Open = 2,
        HalfOpen = 3
    }
}