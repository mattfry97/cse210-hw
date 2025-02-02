
using System;
using System.Collections.Generic;

// PromptGenerator Class
// Function : Random prompt Generator
class PromptGenerator 
    { 
        private List<string> prompts;
        public PromptGenerator(){
            prompts = new List<string>{
                "1. What was the most exciting interaction you had today?",
                "2. Did anything out of the ordinary happen today?",
                "3. What was something you learned today?",
                "4. Who did you talk to today?",
                "5. Was there any new people you were able to meet?",
                "6. Did you try anything new today?",
                "7. Did you witness, receive, or participate in a random act of kindness today?",
                "8. Did you discover any new interests throughout the day?",
                "9. Is there something you have improved, or want to work on in the future?",
                "10. Did you experience any unique small stories that impacted your mood?", 
                "11. What was the best thing that happened to you today?"
            };
        }
        public string GetRandomPrompt(){
            Random rand = new Random();
            int index = rand.Next(prompts.Count);
            return prompts[index];
        }
    }
