using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Coding.Exercise
{
    public class PairOfArrays<TLeft, TRight>
    {
        private readonly TLeft[] _left;
        private readonly TRight[] _right;

        public PairOfArrays(
            TLeft[] left, TRight[] right)
        {
            _left = left;
            _right = right;
        }

        public (TLeft,TRight) this[int indexLeft, int indexRight]
        {
            get => (_left[indexLeft], _right[indexRight]);
            set
            {
                _left[indexLeft] = value.Item1;
                _right[indexRight] = value.Item2;
            }
        }
    }
}

namespace Coding.Exercise
{
    public static class HashSetsUnionExercise
    {
        public static HashSet<T> CreateUnion<T>(
            HashSet<T> set1, HashSet<T> set2)
        {
            foreach (var item in set2)
            {
                set1.Add(item);
            }
            return set1;
        }
    }
}

namespace Coding.Exercise
{
    public static class StackExtensions
    {
        public static bool DoesContainAny(this Stack<string> stack, params string[] words)
        {
            return words.Any(word => stack.Contains(word));
        }
    }
}

namespace Coding.Exercise
{
    public class YieldExercise
    {
        public static IEnumerable<T> GetAllAfterLastNullReversed<T>(IList<T> input)
        {
            var reversed = input.Reverse();
            foreach (var item in reversed)
            {
                if (item != null) yield return item;
                else yield break;
            }
        }
    }
}