using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoizeCalculation
{
    public class MemoizedPrimeCalculation : MemoizeCalculation<int, bool>
    {
        /// <summary>
        /// 引数<paramref name="input"/>が素数か判定する
        /// </summary>
        /// <param name="input">２以上の整数</param>
        /// <returns>1以下ならfalse、2以上なら素数のみtrue</returns>
        protected bool IsPrime(int input)
        {
            if (input < 2) return false;

            double floatInput = input;
            var sqrtInput = (int)Math.Sqrt(floatInput);
            for (var x = 2; x <= sqrtInput; x++)
            {
                //割り切れる(=商が小数点以下すべて0)ならfalse
                double y = floatInput / x;
                if (y == (double)((int)y))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 引数<paramref name="input"/>が素数か判定する
        /// </summary>
        /// <param name="input">２以上の整数</param>
        /// <returns>1以下ならfalse、2以上なら素数のみtrue</returns>
        public override bool Calculation(int input)
        {
            return base.Calculation(input, (i, d) =>
            {
                if (d.ContainsKey(i)) return d[i];
                var ret = IsPrime(i);
                d[i] = ret;
                return ret;
            }
                );
        }
    }
}
