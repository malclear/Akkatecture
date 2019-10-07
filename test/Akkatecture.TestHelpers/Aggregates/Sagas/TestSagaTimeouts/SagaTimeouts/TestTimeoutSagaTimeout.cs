using Akkatecture.Sagas;
using Akkatecture.Sagas.SagaTimeouts;

namespace Akkatecture.TestHelpers.Aggregates.Sagas.TestSagaTimeouts.SagaTimeouts
{
    public class TestTimeoutSagaTimeout: ISagaTimeoutJob
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
    }
    
    public class TestTimeoutSagaTimeout2: ISagaTimeoutJob
    {
        public string MessageToInclude { get; set; }

        public TestTimeoutSagaTimeout2(string messageToInclude)
        {
            MessageToInclude = messageToInclude;
        }
        
        public TestTimeoutSagaTimeout2()
        {
            MessageToInclude = "Some default message from timeout 2!!.";
        }
    }
}