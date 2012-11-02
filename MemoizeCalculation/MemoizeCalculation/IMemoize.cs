using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoizeCalculation
{
    interface IMemoize<TInput, TOutput> where TInput:struct where TOutput:struct
    {
        IDictionary<TInput, TOutput> Memos { get; }
        bool IsMemoized(TInput input);
    }
}
