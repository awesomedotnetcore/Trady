﻿using Trady.Analysis.Indicator;
using Trady.Analysis.Pattern.Helper;
using Trady.Core;

namespace Trady.Analysis.Pattern.Indicator
{
    public class RelativeStrengthIndexOvertrade : IndicatorBase<MultistateResult<SevereOvertrade?>>
    {
        private RelativeStrengthIndex _rsiIndicator;

        public RelativeStrengthIndexOvertrade(Equity equity, int periodCount)
            : base(equity, periodCount)
        {
            _rsiIndicator = new RelativeStrengthIndex(equity, periodCount);
        }

        protected override MultistateResult<SevereOvertrade?> ComputeByIndexImpl(int index)
        {
            var result = _rsiIndicator.ComputeByIndex(index);

            return new MultistateResult<SevereOvertrade?>(Equity[index].DateTime,
                Decision.IsSeverelyOvertrade(result.Rsi));
        }
    }
}