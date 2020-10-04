using System;
using System.Collections;
using System.Collections.Generic;

namespace Fibonacci
{
    abstract class FibonacciNumBase : IEnumerable<int>
    {
        // Граница вычисления последовательности
        public int Bound { get; set; }

        public FibonacciNumBase(int bound) =>
            Bound = bound;

        protected int GetNum(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1 || n == -1)
                return 1;
            else if (n > 1)
                return GetNum(n - 1) + GetNum(n - 2);
            else
                return GetNum(n + 2) - GetNum(n + 1);
        }

        public abstract IEnumerator<int> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();
    }

    class FibonacciNum : FibonacciNumBase
    {
        struct Enumerator : IEnumerator<int>
        {
            private FibonacciNum _fibonacci;
            private int _index;
            private int _value;
            private int _direction;

            public int Current => IsDisposed
                ? throw new InvalidOperationException()
                : _value;

            object IEnumerator.Current => this.Current;

            private bool IsDisposed =>
                _fibonacci == null;

            public Enumerator(FibonacciNum fibonacci)
            {
                _fibonacci = fibonacci;
                _index = 0;
                _value = 0;
                _direction = fibonacci.Bound.CompareTo(0);
            }

            public void Dispose() =>
                _fibonacci = null;

            public bool MoveNext()
            {
                if (IsDisposed)
                    throw new InvalidOperationException();
            
                var comparison = _index != _fibonacci.Bound;               

                if (comparison)
                {
                    _value = _fibonacci.GetNum(_index);
                    _index += _direction;
                }

                return comparison;
            }

            public void Reset()
            {
                if (IsDisposed)
                    throw new InvalidOperationException();

                _index = 0;
                _value = 0;
                _direction = _fibonacci.Bound.CompareTo(0);
            }

        }

        public FibonacciNum(int bound) : base(bound) { }

        public override IEnumerator<int> GetEnumerator() =>
            new Enumerator(this);
    }

    class FibonacciNumYield : FibonacciNumBase
    {
        public FibonacciNumYield(int bound) : base(bound) { }

        public override IEnumerator<int> GetEnumerator()
        {
            var i = 0;
            
            var direction = Bound.CompareTo(0);
            
            do
            {
                yield return GetNum(i);
                i += direction;
            } while (i != Bound);
        }
    }  

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("С помощью Enumerator");
            var f1 = new FibonacciNum(11);
            foreach (var num in f1)
                Console.Write(num + " ");

            Console.WriteLine("\n\nС помощью yield");
            var f2 = new FibonacciNumYield(-11);
            foreach (var num in f2)
                Console.Write(num + " ");
        }
    }
}
