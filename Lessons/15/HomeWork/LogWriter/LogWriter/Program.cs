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

    class LogWriterFactory
    {
        private static LogWriterFactory instance;

        public static LogWriterFactory Instanse =>
            instance ??= new LogWriterFactory();

        private LogWriterFactory() { }

        public ILogWriter GetLogWriter<T>(object parameters)
            where T : ILogWriter
        {
            if (typeof(T) == typeof(FileLogWriter))
                return new FileLogWriter((string)parameters);

            else if (typeof(T) == typeof(ConsoleLogWriter))
                return new ConsoleLogWriter();

            else if (typeof(T) == typeof(MultipleLogWriter))
                return new MultipleLogWriter(parameters as List<ILogWriter>);

            else
                throw new ArgumentOutOfRangeException("<T> Must be FileLogWriter, ConsoleLogWriter or MultipleLogWriter!");
        }
    }

    abstract class AbstractLogWriter : ILogWriter
    {
        public abstract void LogInfo(string message);
        public abstract void LogWarning(string message);
        public abstract void LogError(string message);

        protected string FormatMessage(string message, string messageType) =>
            $"{DateTimeOffset.Now}\t{messageType}\t{message}\n";
    }

    class FileLogWriter : AbstractLogWriter
    {
        public string FileName { get; set; }

        public static string DefaultFileName { get; } = "log.txt";

        public FileLogWriter(string fileName) =>
            FileName = fileName ?? DefaultFileName;

        public override void LogInfo(string message) =>
            File.AppendAllText(FileName, FormatMessage(message, "Info"));

        public override void LogWarning(string message) =>
            File.AppendAllText(FileName, FormatMessage(message, "Warning"));

        public override void LogError(string message) =>
            File.AppendAllText(FileName, FormatMessage(message, "Error"));

        public void ClearLogs() =>
            File.WriteAllText(FileName, "");
    }

    class ConsoleLogWriter : AbstractLogWriter
    {
        public override void LogInfo(string message) =>
            ConsoleWriteColorized(FormatMessage(message, "Info"), ConsoleColor.Cyan);

        public override void LogWarning(string message) =>
            ConsoleWriteColorized(FormatMessage(message, "Warning"), ConsoleColor.Yellow);

        public override void LogError(string message) =>
            ConsoleWriteColorized(FormatMessage(message, "Error"), ConsoleColor.Red);

        private void ConsoleWriteColorized(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }

    class MultipleLogWriter : ILogWriter
    {
        private List<ILogWriter> _logsList;

        public MultipleLogWriter(List<ILogWriter> logsList) =>
            _logsList = logsList;

        public void LogInfo(string message) =>
            _logsList.ForEach(x => x.LogInfo(message));

        public void LogWarning(string message) =>
            _logsList.ForEach(x => x.LogWarning(message));

        public void LogError(string message) =>
            _logsList.ForEach(x => x.LogError(message));
    }

    class Program
    {
        static void Main(string[] args)
        {
            var logWriter = LogWriterFactory.Instanse;

            var fileLogWriter = logWriter.GetLogWriter<FileLogWriter>("log_file.txt");

            var consoleLogWriter = logWriter.GetLogWriter<ConsoleLogWriter>(null);

            var multipleLogWriter = logWriter.GetLogWriter<MultipleLogWriter>(
                new List<ILogWriter>
                {
                    fileLogWriter,
                    consoleLogWriter
                });

            multipleLogWriter.LogInfo("Some info");
        }
    }
}
