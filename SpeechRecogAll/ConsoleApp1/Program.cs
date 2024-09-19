using System;
using System.Speech.Recognition;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of SpeechRecognitionEngine
        using (SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine())
        {
            // Set the input language to the user's default language
            recognizer.SetInputToDefaultAudioDevice();

            // Add a grammar to the recognizer to recognize spoken words
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.AppendDictation();
            Grammar grammar = new Grammar(grammarBuilder);

            // Load the grammar and start recognition
            recognizer.LoadGrammar(grammar);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);

            // Handle recognition events
            recognizer.SpeechRecognized += (s, e) =>
            {
                Console.WriteLine("You said: " + e.Result.Text);
            };

            recognizer.SpeechRecognitionRejected += (s, e) =>
            {
                Console.WriteLine("Speech recognition rejected: " + e.Result.Text);
            };

            // Wait for recognition to finish
            Console.WriteLine("Speak now...");
            Console.ReadLine();
        }
    }
}