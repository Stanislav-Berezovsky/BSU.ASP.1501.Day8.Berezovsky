using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public sealed class SquareMatrix<T> : Matrix<T>
    {


        public SquareMatrix(T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (!array.IsSquare())
                throw new ArgumentException("This matrix isn't Square");
            this.array = (T[,])array.Clone();          
        }

        public override T this[int i, int j]
        {
            get
            {
                if (!IsIndex(i))
                    throw new ArgumentOutOfRangeException();
                if (!IsIndex(j))
                    throw new ArgumentOutOfRangeException();
                return array[i,j];
            }
            set
            {
                if (!IsIndex(i))
                    throw new ArgumentOutOfRangeException();
                if (!IsIndex(j))
                    throw new ArgumentOutOfRangeException();
                var temp = array[i,j];
                array[i,j] = value;
                IsChange(this, new MyEventArgs<T>(i, j, temp, array[i,j]));
            }
        }

        public override int Size
        {
            get 
            {
                return array.GetLength(0); 
            }
        }
    }
}
