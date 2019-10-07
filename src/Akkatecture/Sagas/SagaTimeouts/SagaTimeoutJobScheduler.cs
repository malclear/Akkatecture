using Akkatecture.Jobs;

namespace Akkatecture.Sagas.SagaTimeouts
{
    public class SagaTimeoutJobScheduler<TTimeout>: 
        JobScheduler<SagaTimeoutJobScheduler<TTimeout>, TTimeout, SagaTimeoutId>
        where TTimeout : ISagaTimeoutJob
    {
    }
}