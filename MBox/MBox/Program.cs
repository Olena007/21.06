using System;
using System.Threading.Tasks;

namespace MBox
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            var box = new Models.MessageBox();

            box.StateEvent += box.handler;

            await box.Open();

            if(box.state1 == Models.MessageBox.State.Ok)
            {
                Console.WriteLine("Operation confirmed");
            }
            else
            {
                Console.WriteLine("Operation was rejected");
            }

        }
    }
}
