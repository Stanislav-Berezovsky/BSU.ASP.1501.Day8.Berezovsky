using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public sealed class DiagonalMatrix<T> : Matrix<T>
    {

        public DiagonalMatrix(T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (!array.IsSquare())
                throw new ArgumentException("This matrix isn't Square");
            if (!array.IsDiagonal())
                throw new ArgumentException("This matrix isn't Diagonal");
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
                if (i != j)
                    return default(T);
                return array[i,i];
            }
            set
            {
                if (!IsIndex(i))
                    throw new ArgumentOutOfRangeException();
                if (!IsIndex(j))
                    throw new ArgumentOutOfRangeException();
                if (i == j)
                {
                    var temp = array[i,i];
                    array[i,i] = value;
                    IsChange(this, new MyEventArgs<T>(i, i, temp, array[i,i]));
                }
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
