using System;

namespace FileWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            var writer = new FileWriterWithProgress();
            writer.WritingPerformed +=
                (sender, e) => Console.WriteLine("<Perfomed>\t" + GetFormatString(e)) ;
            writer.WritingCompleted +=
                (sender, e) => Console.WriteLine("<Completed>\t" + GetFormatString(e));

            writer.WriteBytes("log.txt", GetRandomData(15), 0.1f);
            writer.WriteBytes("log.txt", GetRandomData(20), 0.15f);
        }

        static byte[] GetRandomData(int size = 10)
        {
            var data = new byte[size];
            new Random().NextBytes(data);
            return data;
        }

        static string GetFormatString(FileWriterEventArgs e) =>
            $"{e.FileName}\t{e.Percentage}\t{e.CurrentPercent}\t{e.CurrentDataIndex}";
        
    }
}
