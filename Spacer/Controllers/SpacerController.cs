using System;
using System.Collections.Generic;
using System.Text;

namespace Spacer.Controllers
{
    class SpacerController
    {
        public int NumberOfSpaces { get; set; }
        public char SpaceCharacter { get; set; }

        public SpacerController()
        {
            NumberOfSpaces = 3;
            SpaceCharacter = ' ';
        }

        public void Init()
        {
            GetUserInput();
        }

        private void GetUserInput()
        {
            DisplayHelpMessage();
            Console.WriteLine("Press <ENTER> to exit.");

            string[] command;
            string input;
            do
            {
                input = Console.ReadLine();
                command = input.Split(' ');
                switch (command[0])
                {
                    case "/number":
                        int tempInt;
                        bool parseSuccess = int.TryParse(command[1], out tempInt);
                        if (parseSuccess)
                        {
                            NumberOfSpaces = tempInt;
                            Console.WriteLine($"Number of spaces changed to: {NumberOfSpaces}");
                        }
                        else
                        {
                            Console.WriteLine("Exception: Number of spaces must be an integer.");
                        }
                        break;
                    case "/character":
                        SpaceCharacter = command[1][0];
                        Console.WriteLine($"Spacing character changed to: {SpaceCharacter}");
                        break;
                    case "/info":
                        Console.WriteLine($"number of spaces: {NumberOfSpaces}");
                        Console.WriteLine($"spacing character: '{SpaceCharacter}'");
                        break;
                    case "/clear":
                        Console.Clear();
                        break;
                    case "/help":
                        DisplayHelpMessage();
                        break;
                    case "/space":
                        string textToConvert = input.Remove(0, input.IndexOf(' ') + 1);
                        Console.WriteLine(ProcessSpacing(textToConvert));
                        break;
                }
                Console.WriteLine();
            }
            while (!string.IsNullOrWhiteSpace(command[0]));
        }

        private string ProcessSpacing (string textToConvert)
        {
            string spacing = string.Empty;
            for (int i = 0; i < NumberOfSpaces; i++)
            {
                spacing += SpaceCharacter;
            }

            for (int i = 1; i < textToConvert.Length; i += NumberOfSpaces + 1)
            {
                textToConvert = textToConvert.Insert(i, spacing);
            }
            return textToConvert;
        }

        private void DisplayHelpMessage()
        {
            Console.WriteLine("available commands:\n/number <number of s p a c e s inbetween characters>\n/character <character to use for s p a c i n g>\n/space <text to be s p a c e d>\n/info\n/help\n/clear");
        }
    }
}
