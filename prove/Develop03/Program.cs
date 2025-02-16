using System;
using System.Collections.Generic;
using System.Linq;

public class Program{
    public static void Main(){
        Scripture scripture = new Scripture("John 3:16", 
        "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life");

        while (true){
            scripture.Display();
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
            
            string input = Console.ReadLine();
            if (input.ToLower() == "quit"){
                break;
            }

            if (!scripture.HideRandomWords(3) || scripture.IsCompletelyHidden()){
                scripture.Display();
                Console.WriteLine();
                Console.WriteLine("All words have been hidden!");
                break;
            }
        }
    }
}