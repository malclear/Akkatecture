using Akkatecture.Sagas;
using Akkatecture.Sagas.SagaTimeouts;

namespace Akkatecture.TestHelpers.Aggregates.Sagas.TestSagaTimeouts.SagaTimeouts
{
    public class TestTimeoutSagaTimeout: ISagaTimeout<TestTimeoutSagaTimeout>
    {
        public string MessageToInclude { get; set; }

        public TestTimeoutSagaTimeout(string messageToInclude)
        {
            MessageToInclude = messageToInclude;
        }
        
        public TestTimeoutSagaTimeout()
        {
            MessageToInclude = "Some default message.";
        }

        public TestTimeoutSagaTimeout Value => this;
    }
}