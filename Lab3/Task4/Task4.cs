using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

//читання тексту
interface ISmartTextReader
{
    char[][] ReadText(string filePath);
}

//основ. реаліз.
class SmartTextReader : ISmartTextReader
{
    public char[][] ReadText(string filePath)
    {
        var lines = File.ReadAllLines(filePath, Encoding.UTF8);
        char[][] result = new char[lines.Length][];
        for (int i = 0; i < lines.Length; i++)
        {
            result[i] = lines[i].ToCharArray();
        }
        return result;
    }
}

//проксі логування
class SmartTextChecker : ISmartTextReader
{
    private ISmartTextReader _reader;

    public SmartTextChecker(ISmartTextReader reader)
    {
        _reader = reader;
    }

    public char[][] ReadText(string filePath)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine($"[ІНФО] Відкриття файлу: {filePath}");

        char[][] content;
        try
        {
            content = _reader.ReadText(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ПОМИЛКА] Не вдалося прочитати файл: {ex.Message}");
            throw;
        }

        int lineCount = content.Length;
        int charCount = 0;
        foreach (var line in content)
        {
            charCount += line.Length;
        }

        Console.WriteLine($"[ІНФО] Успішне зчитування: {lineCount} рядків, {charCount} символів.");
        Console.WriteLine("[ІНФО] Закриття файлу.");
        return content;
    }
}

//проксі обмеж. доступ.
class SmartTextReaderLocker : ISmartTextReader
{
    private ISmartTextReader _reader;
    private Regex _blockedPattern;

    public SmartTextReaderLocker(ISmartTextReader reader, string pattern)
    {
        _reader = reader;
        _blockedPattern = new Regex(pattern, RegexOptions.IgnoreCase);
    }

    public char[][] ReadText(string filePath)
    {
        if (_blockedPattern.IsMatch(filePath))
        {
            Console.WriteLine("Доступ заборонено!");
            return null;
        }

        return _reader.ReadText(filePath);
    }
}

class Task4
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        string allowedFile = "example.txt";
        string deniedFile = "secret.txt";

        File.WriteAllText(allowedFile, "Привіт\nСвіт!", Encoding.UTF8);
        File.WriteAllText(deniedFile, "Це секретний файл", Encoding.UTF8);

        ISmartTextReader baseReader = new SmartTextReader();
        ISmartTextReader checker = new SmartTextChecker(baseReader);
        ISmartTextReader locker = new SmartTextReaderLocker(checker, "secret");

        Console.WriteLine("=== Дозволений файл ===");
        var result1 = locker.ReadText(allowedFile);

        if (result1 != null)
        {
            foreach (var line in result1)
            {
                Console.WriteLine(new string(line));
            }
        }

        Console.WriteLine("\n=== Заборонений файл ===");
        locker.ReadText(deniedFile);
    }
}
