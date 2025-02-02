
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

// Journal Class
//Function : Handles saving/loading from a file and stores entries
class Journal {
    private List<Entry> entries;
    public Journal(){
        entries = new List<Entry>();
    }
    public void AddEntry(string prompt, string response){
        entries.Add(new Entry(prompt, response));
    }
    public void DisplayEntries(){
        if (entries.Count == 0){
            Console.WriteLine("No entries to display.");
            return;
        }
        foreach (var entry in entries){
            Console.WriteLine(entry.ToString());
        }
    }
    
    public void SaveToFile(string filename){
        using (StreamWriter writer = new StreamWriter(filename)){
            foreach (var entry in entries){
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine($"Journal saved to {filename}");
    }
    public void LoadFromFile(string filename){
        if(!File.Exists(filename)){
            Console.WriteLine("File does not exist.");
            return;
        }
        entries.Clear();
        var lines =File.ReadAllLines(filename);

        foreach (var line in lines){
            var parts = line.Split('|');
            if (parts.Length == 3){
                entries.Add(new Entry(parts[1], parts[2]) { Date = parts[0]} );
            }
        }
        Console.WriteLine("Journal loaded successfully.");
    }
}
