using System;

class Program{
    static void Main(string[] args){
        // adding this commment to see if it shows up in git hub
        Random randomGenerator = new Random();
        int randomNum = randomGenerator.Next(1, 101);
        int guess = -1;
        while (guess != randomNum){
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (randomNum > guess){
                Console.WriteLine("Higher");
            }
            else if (randomNum < guess){
                Console.WriteLine("Lower");
            }
            else{
                Console.WriteLine("You guessed it!");
            }
        }
    }
}