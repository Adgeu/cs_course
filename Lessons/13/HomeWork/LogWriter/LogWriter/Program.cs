using System;
using System.Collections.Generic;
using System.IO;

namespace LogWriter
{
    interface ILogWriter
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
    }

    abstract class AbstractLogWriter : ILogWriter
    {
        public abstract void LogInfo(string message);
        public abstract void LogWarning(string message);
        public abstract void LogError(string message);

        protected string FormatMessage(string message, string messageType) =>
            $"{DateTimeOffset.UtcNow}    {messageType}    {message}\n";
    }

    class FileLogWriter : AbstractLogWriter
    {
        public string FileName { get; }
        public FileLogWriter(string fileName = "log.txt") =>
            FileName = fileName;

        public override void LogInfo(string message) =>
            File.AppendAllText(FileName, FormatMessage(message, "Info   "));

        public override void LogWarning(string message) =>
            File.AppendAllText(FileName, FormatMessage(message, "Warning"));

        public override void LogError(string message) =>
            File.AppendAllText(FileName, FormatMessage(message, "Error  "));

        public void ClearLogs() =>
            File.WriteAllText(FileName, "");
    }

    class ConsoleLogWriter : AbstractLogWriter
    {
        public override void LogInfo(string message) =>
            ConsoleWriteColorized(FormatMessage(message, "Info   "), ConsoleColor.Cyan);

        public override void LogWarning(string message) =>
            ConsoleWriteColorized(FormatMessage(message, "Warning"), ConsoleColor.Yellow);

        public override void LogError(string message) =>
            ConsoleWriteColorized(FormatMessage(message, "Error  "), ConsoleColor.Red);

        private void ConsoleWriteColorized(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }

    class MultipleLogWriter : AbstractLogWriter
    {
        private List<AbstractLogWriter> _logsList;

        public MultipleLogWriter(List<AbstractLogWriter> logsList) =>
            _logsList = logsList;

        public override void LogInfo(string message)
        {
            foreach (var log in _logsList)
                log.LogInfo(message);
        }

        public override void LogWarning(string message)
        {
            foreach (var log in _logsList)
                log.LogWarning(message);
        }

        public override void LogError(string message)
        {
            foreach (var log in _logsList)
                log.LogError(message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var fileLogWriter = new FileLogWriter();
            fileLogWriter.LogError("FileLogWriter says there is an error!");

            var consoleLogWriter = new ConsoleLogWriter();
            consoleLogWriter.LogWarning("ConsoleLogWriter says there is a warning!");

            var multipleLogWriter = new MultipleLogWriter(new List<AbstractLogWriter>
            {
                new FileLogWriter(),
                new ConsoleLogWriter(),
                new MultipleLogWriter(new List<AbstractLogWriter>
                {
                    new ConsoleLogWriter(),
                    new ConsoleLogWriter()
                })
            });
            multipleLogWriter.LogInfo("MultipleLogWriter created");
        }
    }
}
