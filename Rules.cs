using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace rules
{
    public enum Conditions { 
        win, 
        lose,
        draw
    }


    class Rules
    {
        public static Dictionary<string, Conditions[]> Combs { get; private set; }
        public Rules (string[] entities)
        {
            if (entities.Length % 2 == 0 || entities.Length < 3)
            {
                Console.WriteLine("Кол-во комбинаций должно быть больше 2 и нечетное");
                Console.WriteLine("Пример правильного ввода:");
                Console.WriteLine("rock scissor paper");
                return;
            }


            bool isEqual = false;
            for (int i =0; i <entities.Length - 1 && !isEqual; ++i)
            {
                
                for (int j = i + 1; j < entities.Length && !isEqual; ++j)
                {
                    if (entities[i] == entities[j])
                    {
                        Console.WriteLine("Комбинации не должны повторяться");
                        isEqual = true;
                        Console.WriteLine("Пример правильного ввода:");
                        Console.WriteLine("rock scissor paper");
                    }
                }
            }
            if (isEqual) return;
            Combs = new Dictionary<string, Conditions[]>();

            for (int i = 0; i < entities.Length; ++i)
            {
                Combs.Add(entities[i], new Conditions[entities.Length]);

                int sides = entities.Length / 2;
                for (int j = sides; j > 0; --j)
                {
                    Combs[entities[i]][(i - j + entities.Length) % entities.Length] = Conditions.lose;
                }

                Combs[entities[i]][i] = Conditions.draw;
            }
        }

    }
}
