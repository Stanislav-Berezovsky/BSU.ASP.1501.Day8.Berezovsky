using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class WorkWithMatrix
    {
        public static Matrix<T> Add<T>(this Matrix<T> a, Matrix<T> b, Func<T, T, T> addition)
        {
            if (a == null)
                throw new ArgumentNullException();
            if (b == null)
                throw new ArgumentNullException();
            if (a.Size != b.Size)
                throw new InvalidOperationException("This Matrixes have differents sizes");
            T[,] temp = new T[a.Size,a.Size];
            for (int i = 0; i < b.Size; i++)
                for (int j = 0; j < b.Size; j++)
                    temp[i, j] = addition(a[i, j], b[i, j]);
            if (temp.IsSquare())
            {
                if (temp.IsSymmetry())
                    return new SymmetricMatrix<T>(temp);
                if (temp.IsDiagonal())
                    return new DiagonalMatrix<T>(temp);
                return new SquareMatrix<T>(temp);
            }
            return default(Matrix<T>);
        }


        public static bool IsSquare<T>(this T[,] array)
        {
            if (array.GetLength(0) == array.GetLength(1))
                return true;
            return false;
        }
        public static bool IsSymmetry<T>(this T[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (!array[i, j].Equals(array[j, i]))
                        return false;
                }
            }
            return true;
        }
        public static bool IsDiagonal<T>(this T[,] array)
        {
            for (int i = 1; i < array.GetLength(0); i++)
                for (int j = i + 1; j < array.GetLength(1); j++)
                    if (!array[i, j].Equals(default(T)) || !array[j, i].Equals(default(T)))
                        return false;
            return true;
        }

    }

}
