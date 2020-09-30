using System;
using System.Collections.Generic;

namespace ClassWork_14
{
    class ErrorList : IDisposable
    {
        public string Category { get; }
        public List<string> Errors { get; private set; }

        public ErrorList(string category)
        {
            Category = category;
            Errors = new List<string>();
        }

        public void AddError(string error) =>
            Errors.Add(error);

        public void WriteAllErrors()
        {
            foreach (var error in Errors)
                Console.WriteLine($"{Category}: {error}");
        }

        public void Dispose()
        {
            Errors.Clear();
            Errors = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using var errorList = new ErrorList("System");

            errorList.AddError("1st error");
            errorList.AddError("2nd error");
            errorList.AddError("3rd error");

            errorList.WriteAllErrors();
        }
    }
}
