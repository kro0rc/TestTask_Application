using System;
using System.Threading;

namespace TestProject_Consimple.View
{
    class ConsoleInteraction : IUserInteraction
    {
        private readonly ConsoleKey[] _availableKeys = new ConsoleKey[] { ConsoleKey.Enter, ConsoleKey.Escape };

        public ConsoleKey GetUserKey(string message)
        {
            ShowResponse(message);

            var userInput = Console.ReadKey(true);

            for (int i = 0; i < this._availableKeys.Length; i++)
            {
                if (userInput.Key == this._availableKeys[i])
                {
                    return userInput.Key;
                }
            }

            return GetUserKey(message);
        }

        public void ShowResponse(string message)
        {
            Console.WriteLine(message);
        }
    }
}
