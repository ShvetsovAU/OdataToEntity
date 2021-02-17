using System;

namespace ASE.MD.MDP2.Product.MDP2Service.Utils
{
    public static class Maybe
    {
        public static TResult Return<TInput, TResult>(this TInput input, Func<TInput, TResult> evaluator, TResult failureValue = default(TResult)) where TInput : class
        {
            return input == null ? failureValue : evaluator(input);
        }

        public static TInput If<TInput>(this TInput input, Func<TInput, bool> evaluator) where TInput : class
        {
            if (input == null) return null;
            return evaluator(input) ? input : null;
        }

        public static TInput Unless<TInput>(this TInput o, Func<TInput, bool> evaluator)
            where TInput : class
        {
            if (o == null) return null;
            return evaluator(o) ? null : o;
        }

        public static TInput Do<TInput>(this TInput input, Action<TInput> action) where TInput : class
        {
            if (input == null) return null;
            action(input);
            return input;
        }

        public static TOutput DoWithReturn<TInput, TOutput>(this TInput intput, Func<TInput, TOutput> func, TOutput failureValue = default(TOutput)) where TInput : class
        {
            if (intput == null) return failureValue;
            return func(intput);
        }
    }
}
