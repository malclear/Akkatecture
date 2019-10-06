using Akkatecture.Jobs;

namespace Akkatecture.Sagas.SagaTimeouts
{
    [JobName("SagaTimeoutJob")]
    public class SagaTimeoutJob<TTimeout>:  IJob
    {
        public TTimeout Timeout { get; }
        public SagaTimeoutJob(TTimeout timeout) 
        {
            Timeout = timeout;
        }
    }
}