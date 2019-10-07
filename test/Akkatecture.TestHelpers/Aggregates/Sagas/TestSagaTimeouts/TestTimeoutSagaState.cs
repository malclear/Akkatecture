﻿// The MIT License (MIT)
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

using Akkatecture.Aggregates;
using Akkatecture.Sagas;
using Akkatecture.TestHelpers.Aggregates.Sagas.TestSagaTimeouts.Events;

namespace Akkatecture.TestHelpers.Aggregates.Sagas.TestSagaTimeouts
{
    public class TestTimeoutSagaState : SagaState<TestTimeoutSaga, TestTimeoutSagaId, IMessageApplier<TestTimeoutSaga, TestTimeoutSagaId>>,
        IApply<TestTimeoutSagaStartedEvent>,
        IApply<TestTimeoutSagaTransactionCompletedEvent>,
        IApply<TestTimeoutSagaCompletedEvent>, 
        IApply<TestTimeoutSagaTimeoutOccurred>
    {
        public TestAggregateId Sender { get; set; }
        public TestAggregateId Receiver { get; set; }
        public Entities.Test Test { get; set; }
        public void Apply(TestTimeoutSagaStartedEvent aggregateEvent)
        {
            Sender = aggregateEvent.Sender;
            Receiver = aggregateEvent.Receiver;
            Test = aggregateEvent.SentTest;
        }

        public void Apply(TestTimeoutSagaTransactionCompletedEvent aggregateEvent)
        {
        }

        public void Apply(TestTimeoutSagaCompletedEvent aggregateEvent)
        {
        }

        public void Apply(TestTimeoutSagaTimeoutOccurred asdf)
        {
        }
    }
}