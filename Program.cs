using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
    class Program
    {
        static void Main(string[] args)
        {

            int size;
            Console.WriteLine("Введите размер матрицы");
            int.TryParse(Console.ReadLine(), out size);

            bool[,] graph = new bool[size, size];

            Random rnd = new Random();

            for (int i = 0; i < size; i++){
                int a = rnd.Next(0, size);

                graph[a, i] = true;
                graph[i, a] = true;
            }

            int razm = 0;

            

            for (int i = 0; i < size; i++){
                for (int j = 0; j < size; j++){
                    graph[i, i] = false;
                    Console.Write(graph[i,j] ? "1" : "0");
                    razm += graph[i, j] ? 1 : 0;
                }
                Console.Write("\n");
            }

            for (int i = 0; i < size; i++){
                int conc = 0;
                bool izol = true;
                bool dominant = true;
                for (int j = 0; j < size; j++){
                    if (graph[i,j]) { izol = false; conc++; }
                    if (!graph[i,j] && i != j) { dominant = false; }
                }
                Console.WriteLine("Вершина " + i.ToString() + " "
                    + (conc == 1 ? "Концевая" : "Не концевая") + " "
                    + (izol ? "Изолированная" : "Не изолированная") + " "
                    + (dominant ? "Доминантная" : "Не доминантная") + " "
                    + "Степень - " + conc.ToString());
            }
            razm = razm / 2;
            Console.WriteLine("Размер - " + razm.ToString());

            Console.ReadLine();
        }
    }
}
