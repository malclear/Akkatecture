using Akka.Actor;
using Akkatecture.Jobs;

namespace Akkatecture.Sagas.SagaTimeouts
{
    public class SagaTimeoutJobRunner<TTimeout>:  JobRunner<SagaTimeoutJob<TTimeout>, 
        SagaTimeoutId>, IRun<SagaTimeoutJob<TTimeout>>
    {
        private IActorRef _saga;

        public SagaTimeoutJobRunner(IActorRef saga)
        {
            _saga = saga;
        }

        public bool Run(SagaTimeoutJob<TTimeout> job)
        {
            //TODO ML, Should/can we send the SagaTimeoutJob's inner object to the grandparent of this actor? 
            _saga.Tell(job.Timeout); 
            return true;
        }
    }
}