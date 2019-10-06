using Akka.Actor;
using Akkatecture.Jobs;

namespace Akkatecture.Sagas.SagaTimeouts
{
    //TODO Maybe make all these classes internal?
    public class SagaTimeoutManager<TTimeout> : JobManager<SagaTimeoutJobScheduler<TTimeout>, 
        SagaTimeoutJobRunner<TTimeout>, SagaTimeoutJob<TTimeout>, SagaTimeoutId>
    {
        public SagaTimeoutManager(IActorRef saga) : base(
            () => new SagaTimeoutJobScheduler<TTimeout>(),
            () => new SagaTimeoutJobRunner<TTimeout>(saga)) {}
    }
}