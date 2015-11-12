using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public abstract class Matrix<T>
    {
        public EventHandler<MyEventArgs<T>> Change = delegate { };

        protected T[,] array;
        protected virtual void IsChange(object sender, MyEventArgs<T> eventArg)
        {
            var change = Change;
            if (change != null)
                change(sender, eventArg);
        }
        public abstract T this[int i, int j] { get; set; }

        public override string ToString()
        {
            var temp = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                    temp.Append(this[i, j] + " ");
                temp.AppendLine("\n");
            }
            return temp.ToString();
        }

        public abstract int Size { get; }
        protected bool IsIndex(int i)
        {
            if (i < 0 && i >= Size)
                return false;         
            return true;
        }
    }
}
