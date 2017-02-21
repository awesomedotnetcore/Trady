﻿using Trady.Analysis.Indicator;
using Trady.Analysis.Pattern.Helper;
using Trady.Core;

namespace Trady.Analysis.Pattern.Indicator
{
    public class IsAboveSimpleMovingAverage : IndicatorBase<IsMatchedResult>
    {
        private SimpleMovingAverage _smaIndicator;

        public IsAboveSimpleMovingAverage(Equity equity, int periodCount)
            : base(equity, periodCount)
        {
            _smaIndicator = new SimpleMovingAverage(equity, periodCount);
        }

        protected override IsMatchedResult ComputeByIndexImpl(int index)
        {
            var result = _smaIndicator.ComputeByIndex(index);
            return new IsMatchedResult(Equity[index].DateTime, Equity[index].Close.IsLargerThan(result.Sma));
        }
    }
}