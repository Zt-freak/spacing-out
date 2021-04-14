using Spacer.Controllers;
using System;

namespace Spacer
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to the s p a c e r\n");

            SpacerController spacerController = new SpacerController();
            spacerController.Init();
        }
    }
}
