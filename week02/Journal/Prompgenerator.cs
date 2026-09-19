using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What was the best part of my day?",
        "Who was the most interesting person I interacted with today?",
        "What was something new I learned today?",
        "What was the strongest emotion I felt today?",
        "What is something I am grateful for today?",
        "If I could do one thing differently today, what would it be?",
        "What is one goal I want to accomplish tomorrow?"
    };

    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}