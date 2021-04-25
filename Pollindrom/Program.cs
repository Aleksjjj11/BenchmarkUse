using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Pollindrom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<PollindromBench>();
        }
    }

    public class PollindromBench
    {
        private PollindromChecker _pollindromChecker;
        private int _dataTest;

        public PollindromBench()
        {
            _pollindromChecker = new PollindromChecker();
            _dataTest = new Random(DateTime.Now.Millisecond).Next();
        }

        [Benchmark]
        public bool Method1() => _pollindromChecker.IsPollindromMethod1(_dataTest);

        [Benchmark]
        public bool Method2() => _pollindromChecker.IsPollindromMethod2(_dataTest);
    }

    public class PollindromChecker
    {
        public bool IsPollindromMethod1(int number)
        {
            int reversed = 0;
            int orig = number;
            while (number > 0)
            {
                reversed = reversed * 10 + number % 10;
                number /= 10;
            }

            return orig == reversed;
        }

        public bool IsPollindromMethod2(int number)
        {
            string word = number.ToString();
            for (int i = 0; i < word.Length / 2; ++i)
            {
                if (word[i] != word[^(i+1)])
                {
                    return false;
                }
            }

            return true;
        }
    }
}