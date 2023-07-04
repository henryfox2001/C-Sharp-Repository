using System;

public class Dictionary
{
    // Attributes
    private List<string> _dictionary = new List<string> ();
   
    // Constructors
    public List<string> GetList(string fileName)
    {
        LoadWords(fileName);
        return _dictionary;
    }
    public void AddWord(string word)
    {
        _dictionary.Add(word);
    }

    // Methods
    public void LoadWords(string fileName)
    {
        string[] readText = File.ReadAllLines(fileName);

        // loop though text file for words
        foreach (string line in readText)
        {
            string entries = line;
            AddWord(entries);
        }
    }
}