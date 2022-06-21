using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MBox.Models
{
    internal class MessageBox
    {
        public Func<State, State> handler;

        public event Func<State, State> StateEvent;

        public State state1;

        public MessageBox()
        {
            handler = StateInfo;
        }

        public enum State
        {
            Ok,
            Cancel
        };
        public State StateInfo(State state)
        {
            Console.WriteLine($"window closed");

            return state;
        }

        public void Close()
        {
            Task.Delay(3000).Wait();
            Console.WriteLine("Window was closed by the user");

        }

        public async Task Open()
        {
            this.state1 = State.Ok;
            Console.WriteLine("Window opened");

            await Task.Run(() => Close());

            StateEvent.Invoke(StateInfo(this.state1));
        }
    }
}
