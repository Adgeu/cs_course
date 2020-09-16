using System;

namespace ClassWork_10
{
    /// <summary>
    /// Типы сообщений для вывода в косноль
    /// </summary>
    public enum MessageType
    {
        Error,
        Warning,
        Info
    }

    /// <summary>
    /// Предоставляет вспомогательные методы для вывода текста в консоль
    /// </summary>
    static class Support
    {
        /// <summary>
        /// Выводит в консоль текст с выбранным цветом с последующим перводом на новую строку
        /// </summary>
        /// <param name="text">Текст, который нужно вывести в консоль</param>
        /// <param name="color">Цвет, с которым нужно вывести текст на консоль</param>
        public static void WriteLineColorized(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Выводит в консоль текст с выбранным цветом
        /// </summary>
        /// <param name="text">Текст, который нужно вывести в консоль</param>
        /// <param name="color">Цвет, с которым нужно вывести текст на консоль</param>
        public static void WriteColorized(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Выводит сообщение в консоль
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <param name="messageType">Тип сообщения</param>
        public static void WriteMessage(string message, MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case MessageType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case MessageType.Info:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
            }
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
