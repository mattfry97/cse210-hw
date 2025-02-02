using System;

// Entry Class 
// Function : Storing details about the Journal Entry (Prompt, Response, Date)
class Entry{
        public string Prompt {get; set;}
        public string Response {get; set;}
        public string Date {get; set;}

        public Entry(string prompt, string response){
            Prompt = prompt;
            Response = response;
            DateTime theCurrentTime = DateTime.Now;
            Date = theCurrentTime.ToShortDateString();
        }
    public override string ToString(){
        return $"[{Date}] - Prompt: {Prompt}\nResponse: {Response}\n";
        }
    }