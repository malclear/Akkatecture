using Akkatecture.Aggregates;

namespace Akkatecture.TestHelpers.Aggregates.Sagas.TestSagaTimeouts.Events
{
    public class TestTimeoutSagaTimeoutOccurred : AggregateEvent<TestTimeoutSaga, TestTimeoutSagaId>
    {
        public string TimeoutMessage { get; }

        public TestTimeoutSagaTimeoutOccurred(string timeoutMessage)
        {
            TimeoutMessage = timeoutMessage;
        }
    }
}