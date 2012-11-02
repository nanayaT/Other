using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoizeCalculation
{
    /// <summary>
    /// メモ化した計算
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public abstract class MemoizeCalculation<TInput, TOutput> : IMemoize<TInput, TOutput> where TInput:struct where TOutput:struct
    {
        private readonly Dictionary<TInput, TOutput> _Memos;
        public IDictionary<TInput, TOutput> Memos
        {
            get { return _Memos; }
        }

        public MemoizeCalculation()
        {
            _Memos = new Dictionary<TInput, TOutput>();
        }

        /// <summary>
        /// メモ済みか判定する
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsMemoized(TInput input)
        {
            return Memos.ContainsKey(input);
        }

        protected TOutput Calculation(TInput input, Func<TInput, IDictionary<TInput, TOutput>, TOutput> memoizedCalc)
        {
            return memoizedCalc(input, _Memos);
        }

        /// <summary>
        /// 計算する
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public abstract TOutput Calculation(TInput input);
    }
}
