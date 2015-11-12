using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task1;

namespace Task1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[3, 3] { { 1, 4, 5 }, { 52, 34, 3 }, { 6, 734, 8 } };                                                                                    
            SquareMatrix<int> m = new SquareMatrix<int>(array);
            Console.WriteLine(m.ToString());
            m.Change += IsChange;
            m[1, 2] = 100;
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine(m.ToString());

            int[,] arrayM = new int[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };                                        
            Matrix<int> firstM = new SquareMatrix<int>(array);
            Console.WriteLine(firstM.ToString());
            Matrix<int> secondM = new SymmetricMatrix<int>(arrayM);
            Console.WriteLine(secondM.ToString());
            var result = WorkWithMatrix.Add( firstM,secondM, (a, b) => a + b);
            System.Console.WriteLine(result.ToString());

            
            int [,] arD1 = new int[3,3]{{1,0,0},{0,1,0},{0,0,1}};
            int[,] arD2 = new int[3, 3] { { 2, 0, 0 }, { 0, 2, 0 }, { 0, 0, 2 } };
            var fisrtDM = new DiagonalMatrix<int>(arD1);
            Console.WriteLine(fisrtDM.ToString());
            var secondDM = new DiagonalMatrix<int>(arD2);
            Console.WriteLine(secondDM.ToString());
            result = WorkWithMatrix.Add(fisrtDM, secondDM, (a, b) => a + b);
            System.Console.WriteLine(result.ToString());


            Console.ReadKey();
        }

        static void IsChange(object sender, MyEventArgs<int> eventArgs)
        {
            Console.WriteLine("matrix[{0},{1}] \t Old value:{2} \t New value:{3}", eventArgs.i, eventArgs.j, eventArgs.OldValue, eventArgs.NewValue);
        }
    }
}
