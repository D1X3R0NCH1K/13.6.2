using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Читаем текст из файла
        string text = File.ReadAllText("input.txt");

        // Удаляем знаки пунктуации
        var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

        // Разделяем текст на слова
        string[] words = noPunctuationText
            .ToLower()
            .Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        // Подсчитываем частоту слов
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (wordCount.ContainsKey(word))
                wordCount[word]++;
            else
                wordCount[word] = 1;
        }

        // Выводим 10 самых частых слов
        var topWords = wordCount
            .OrderByDescending(pair => pair.Value)
            .Take(10);

        Console.WriteLine("10 самых часто встречающихся слов:");
        foreach (var pair in topWords)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}
