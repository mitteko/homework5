using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            
        }

        //1
        //создать List на 64 элемента, скачать из интернета 32 пары картинок, перемешать List с картинками.
        //Вывести в консоль перемешанные номера(изначальный List и полученный List).

        static void Task1()
        {
            List<string> images = new List<string>();
            string imagesWay = @"C:\Desktop\фото\";

            if (!Directory.Exists(imagesWay))
            {
                Console.WriteLine("Указанной папки не существует");
                return;
            }

            for (int i = 0; i < 32; i++)
            {
                string imagePath = Path.Combine(imagesWay, $"image{i}.jpeg");

                if (File.Exists(imagePath))
                {
                    images.Add(imagePath);
                    images.Add(imagePath);
                }
                else
                {
                    Console.WriteLine($"Файл {imagePath} не найден, он будет пропущен.");
                }
            }

            Console.WriteLine("Обычный список:");
            for (int i = 0; i < images.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {images[i]}");
            }

            Random random = new Random();
            images = images.OrderBy(a => random.Next()).ToList();

            Console.WriteLine("Перемешанный список:");
            for (int i = 0; i < images.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {images[i]}");
            }
        }

    }
}
