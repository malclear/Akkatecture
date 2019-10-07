// The MIT License (MIT)
//
// Copyright (c) 2018 - 2019 Lutando Ngqakaza
// https://github.com/Lutando/Akkatecture 
// 
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using Akka.Actor;
using Akkatecture.Aggregates;
using Akkatecture.Commands;
using Akkatecture.Sagas;
using Akkatecture.Sagas.AggregateSaga;
using Akkatecture.Sagas.SagaTimeouts;
using Akkatecture.TestHelpers.Aggregates.Commands;
using Akkatecture.TestHelpers.Aggregates.Events;
using Akkatecture.TestHelpers.Aggregates.Sagas.TestSagaTimeouts.Events;
using Akkatecture.TestHelpers.Aggregates.Sagas.TestSagaTimeouts.SagaTimeouts;

namespace Akkatecture.TestHelpers.Aggregates.Sagas.TestSagaTimeouts
{
    public class TestTimeoutSaga : AggregateSaga<TestTimeoutSaga,TestTimeoutSagaId,TestTimeoutSagaState>,
        ISagaIsStartedBy<TestAggregate, TestAggregateId, TestSentEvent>,
        ISagaHandles<TestAggregate, TestAggregateId, TestReceivedEvent>, 
        ISagaHandlesTimeout<TestTimeoutSagaTimeout>
    {
        private IActorRef TestAggregateManager { get; }
        public TestTimeoutSaga(IActorRef testAggregateManager)
        {
            TestAggregateManager = testAggregateManager;
            Command<EmitTestTimeoutSagaState>(Handle);
        }

        public bool Handle(IDomainEvent<TestAggregate, TestAggregateId, TestSentEvent> domainEvent)
        {
            if (IsNew)
            {
                var command = new ReceiveTestCommand(
                    domainEvent.AggregateEvent.RecipientAggregateId,
                    CommandId.New,
                    domainEvent.AggregateIdentity,
                    domainEvent.AggregateEvent.Test);
                RequestTimeout(new TestTimeoutSagaTimeout("This is my test timeout message."), 
                    TimeSpan.FromSeconds(5));
                
                Emit(new TestTimeoutSagaStartedEvent(domainEvent.AggregateIdentity, 
                    domainEvent.AggregateEvent.RecipientAggregateId, domainEvent.AggregateEvent.Test));
                
                TestAggregateManager.Tell(command);
            }

            return true;
        }

        public bool Handle(IDomainEvent<TestAggregate, TestAggregateId, TestReceivedEvent> domainEvent)
        {
            if (!IsNew)
            {
                Emit(new TestTimeoutSagaTransactionCompletedEvent());
                Self.Tell(new EmitTestTimeoutSagaState());

            }
            return true;
        }

        private bool Handle(EmitTestTimeoutSagaState testTimeoutCommmand)
        {
            Emit(new TestTimeoutSagaCompletedEvent(State));
            return true;
        }

        private class EmitTestTimeoutSagaState
        {
        }

        public bool HandleTimeout(TestTimeoutSagaTimeout timeout)
        {
            var message = ((TestTimeoutSagaTimeout) timeout).MessageToInclude;
            Emit(new TestTimeoutSagaTimeoutOccurred(message));
            return true;            
        }
    }
}
