using System;
using System.IO;
using System.Text;

namespace AdapterPatternDemo
{
    public class Logger
    {
        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"ЛОГ: {message}");
            Console.ResetColor();
        }

        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ПОМИЛКА: {message}");
            Console.ResetColor();
        }

        public void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"УВАГА: {message}");
            Console.ResetColor();
        }
    }

    public class FileWriter
    {
        private string _filePath;

        public FileWriter(string filePath)
        {
            _filePath = filePath;
        }

        public void Write(string message)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, true, Encoding.UTF8))
            {
                writer.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, true, Encoding.UTF8))
            {
                writer.WriteLine(message);
            }
        }
    }

    public interface ILogger
    {
        void Log(string message);
        void Error(string message);
        void Warn(string message);
    }

    public class FileLoggerAdapter : ILogger
    {
        private FileWriter _fileWriter;

        public FileLoggerAdapter(FileWriter fileWriter)
        {
            _fileWriter = fileWriter;
        }

        public void Log(string message)
        {
            _fileWriter.WriteLine($"ЛОГ: {message}");
        }

        public void Error(string message)
        {
            _fileWriter.WriteLine($"ПОМИЛКА: {message}");
        }

        public void Warn(string message)
        {
            _fileWriter.WriteLine($"УВАГА: {message}");
        }
    }

    class Task1
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("== Консольний логер ==");
            Logger consoleLogger = new Logger();
            consoleLogger.Log("Це звичайне повідомлення");
            consoleLogger.Warn("Це попередження");
            consoleLogger.Error("Це помилка");

            Console.WriteLine("\n== Файловий логер ==");
            FileWriter writer = new FileWriter("log.txt");
            ILogger fileLogger = new FileLoggerAdapter(writer);
            fileLogger.Log("Це лог у файл");
            fileLogger.Warn("Це попередження у файл");
            fileLogger.Error("Це помилка у файл");

            Console.WriteLine("Логування у файл завершено (див. log.txt)");
        }
    }
}
