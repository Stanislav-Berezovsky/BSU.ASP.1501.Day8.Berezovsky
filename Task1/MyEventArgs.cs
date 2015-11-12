using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class MyEventArgs<T> : EventArgs
    {
        public int i { get; private set; }
        public int j { get; private set; }
        public T OldValue { get; private set; }
        public T NewValue { get; private set; }
        public MyEventArgs(int i, int j, T oldValue, T newValue)
        {
            this.i = i+1;
            this.j = j+1;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }
    }
}
