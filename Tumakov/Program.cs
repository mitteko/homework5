using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;


namespace Tumakov
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Task1(args);
            Task2(args);

        }


        //6.1
        /// <summary>
        /// Написать программу, которая вычисляет число гласных и согласных букв в файле.Имя файла передавать как аргумент в функцию Main.Содержимое текстового файла 
        /// заносится в массив символов. Количество гласных и согласных букв определяется проходом 
        /// по массиву.Предусмотреть метод, входным параметром которого является массив символов. 
        /// Метод вычисляет количество гласных и согласных букв.
        /// </summary>

        static void Task1(string[] args)
        {

            Console.Write("6.1");
            Console.Write("Вычисление гласных и согласных букв в файле");

            if (args.Length != 1)
            {
                Console.WriteLine("Укажите файл");
                return;
            }

            string fileName = args[0];

            try
            {
                string textFile = File.ReadAllText(fileName);
                char[] letters = textFile.ToCharArray();

                CountVowelsAndConsonants(letters);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        //метод для подсчета гласных, согласных
        static void CountVowelsAndConsonants(char[] chars)
        {
            List<char> vowels = new List<char> {'y', 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            List<char> consonants = new List<char>();
            int vowelsCount = 0;
            int consonantsCount = 0;

            foreach (char c in chars)
            {
                if (vowels.Contains(char.ToLower(c)))
                {
                    vowelsCount++;
                }
                else if (consonants.Contains(char.ToLower(c)))
                {
                    consonantsCount++;
                }
            }

            Console.WriteLine($"Гласные: {vowelsCount}");
            Console.WriteLine($"Согласные: {consonantsCount}");
        }


        //6.2
        /// <summary>
        /// Написать программу, реализующую умножению двух матриц, заданных в 
        /// виде двумерного массива.В программе предусмотреть два метода: метод печати матрицы,
        /// метод умножения матриц(на вход две матрицы, возвращаемое значение – матрица).
        /// </summary>

        static void Task2(string[] args)
        {
            Console.Write("6.2");
            Console.Write("Реализующее умножение двух матриц");

            Console.Write("Введите количество строк для матрицы A: ");
            int rowsA = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов для матрицы A: ");
            int colsA = int.Parse(Console.ReadLine());

            var matrixA = new LinkedList<LinkedList<int>>();
            for (int i = 0; i < rowsA; i++)
            {
                Console.WriteLine($"Введите элементы строки {i + 1} матрицы A (через пробел):");
                string[] elements = Console.ReadLine().Split();
                var rowA = new LinkedList<int>();
                foreach (var element in elements)
                {
                    rowA.AddLast(int.Parse(element));
                }
                matrixA.AddLast(rowA);
            }


            Console.Write("Введите количество строк для матрицы B: ");
            int rowsB = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов для матрицы B: ");
            int colsB = int.Parse(Console.ReadLine());

            var matrixB = new LinkedList<LinkedList<int>>();
            for (int i = 0; i < colsA; i++)
            {
                Console.WriteLine($"Введите элементы строки {i + 1} матрицы B (через пробел):");
                string[] elements = Console.ReadLine().Split();
                var rowB = new LinkedList<int>();
                foreach (var element in elements)
                {
                    rowB.AddLast(int.Parse(element));
                }
                matrixB.AddLast(rowB);
            }



            Console.WriteLine("Матрица A:");
            PrintMatrix(matrixA);

            Console.WriteLine("Матрица B:");
            PrintMatrix(matrixB);

            var resultMatrix = MultiplyMatrices(matrixA, matrixB);

            Console.WriteLine("Результат умножения A * B:");
            PrintMatrix(resultMatrix);
        }

        //чтоб красивенько матрицы вывел^^
        static void PrintMatrix(LinkedList<LinkedList<int>> matrix)
        {
            foreach (var row in matrix)
            {
                foreach (var element in row)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }
        }

        static LinkedList<LinkedList<int>> MultiplyMatrices(LinkedList<LinkedList<int>> matrixA, LinkedList<LinkedList<int>> matrixB)
        {
            int rowsA = 0, colsA = 0, rowsB = 0, colsB = 0;

            //количество строк и столбцов для матрицы A
            foreach (var row in matrixA)
            {
                rowsA++;
                colsA = row.Count;
            }

            //количество строк и столбцов для матрицы B
            foreach (var row in matrixB)
            {
                rowsB++;
                colsB = row.Count;
            }

            //проверка
            if (colsA != rowsB)
            {
                throw new InvalidOperationException("Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
            }

            //результирующая матрица
            var resultMatrix = new LinkedList<LinkedList<int>>();
            for (int i = 0; i < rowsA; i++)
            {
                var rowResult = new LinkedList<int>();
                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;

                    var rowA = GetRow(matrixA, i);
                    var colB = GetColumn(matrixB, j);

                    for (int k = 0; k < colsA; k++)
                    {
                        sum += rowA.ElementAt(k) * colB.ElementAt(k);
                    }

                    rowResult.AddLast(sum);
                }
                resultMatrix.AddLast(rowResult);
            }

            return resultMatrix;
        }

        static LinkedList<int> GetRow(LinkedList<LinkedList<int>> matrix, int rowIndex)
        {
            int currentRow = 0;
            foreach (var row in matrix)
            {
                if (currentRow == rowIndex)
                {
                    return row;
                }
                currentRow++;
            }
            return null;
        }

        static LinkedList<int> GetColumn(LinkedList<LinkedList<int>> matrix, int colIndex)
        {
            var column = new LinkedList<int>();
            foreach (var row in matrix)
            {
                int currentCol = 0;
                foreach (var item in row)
                {
                    if (currentCol == colIndex)
                    {
                        column.AddLast(item);
                    }
                    currentCol++;
                }
            }
            return column;
        }



    }
}
