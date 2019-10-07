using Akka.Actor;
using Akkatecture.Jobs;

namespace Akkatecture.Sagas.SagaTimeouts
{
    public class SagaTimeoutJobRunner<TTimeout>:  JobRunner<TTimeout, SagaTimeoutId>, IRun<TTimeout>
        where TTimeout: ISagaTimeoutJob, IJob
    {
        public SagaTimeoutJobRunner()
        {
        }

        public bool Run(TTimeout job)
        {
            //TODO ML, Should/can we send the SagaTimeoutJob's inner object to the grandparent of this actor?
            Context.ActorSelection(Context.Parent.Path.Parent.Parent).Tell(job);
            return true;
        }
    }
}