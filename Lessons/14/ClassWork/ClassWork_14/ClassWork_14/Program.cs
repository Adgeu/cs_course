using System;
using System.Collections.Generic;

namespace ClassWork_14
{
    class ErrorList : IDisposable, IEnumerable<string>
    {
        public string Category { get; }

        private List<string> _errors;

        public ErrorList(string category)
        {
            Category = category;
            _errors = new List<string>();
        }

        public void Add(string errorMessage) =>
            _errors.Add(errorMessage);


        public IEnumerator<string> GetEnumerator()
        {
            return _errors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return  _errors.GetEnumerator();
        }

        public void Dispose()
        {
            if (_errors != null)
            {
                _errors.Clear();
                _errors = null;
            }        
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using var errorList = new ErrorList("System");

            errorList.Add("1st error");
            errorList.Add("2nd error");
            errorList.Add("3rd error");

            foreach (var error in errorList)
                Console.WriteLine($"{errorList.Category}: {error}");
        }
    }
}
