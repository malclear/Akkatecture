using Akka.Actor;
using Akkatecture.Jobs;

namespace Akkatecture.Sagas.SagaTimeouts
{
    //TODO Maybe make all these classes internal?
    public class SagaTimeoutManager<TTimeout> : 
        JobManager<
            SagaTimeoutJobScheduler<TTimeout>, 
            SagaTimeoutJobRunner<TTimeout>, 
            TTimeout, 
            SagaTimeoutId> where TTimeout : ISagaTimeoutJob
    { 
        public SagaTimeoutManager() : base(
            () => new SagaTimeoutJobScheduler<TTimeout>(),
            () => new SagaTimeoutJobRunner<TTimeout>()) {}
    }
}