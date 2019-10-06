using Akkatecture.Core;
using Akkatecture.Jobs;

namespace Akkatecture.Sagas.SagaTimeouts
{
    public class SagaTimeoutId : Identity<SagaTimeoutId>, IJobId
    {
        public SagaTimeoutId(string value) : base(value)
        {
        }
    }
}