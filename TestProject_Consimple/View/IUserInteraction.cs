using System;

namespace TestProject_Consimple.View
{
    interface IUserInteraction
    {
        ConsoleKey GetUserKey(string message);
        void ShowResponse(string message);
    }
}
