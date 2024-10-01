using System;
using System.Text;
using System.Text.RegularExpressions;
class HomeClass
{
    public static void Main()
    {
        
        int i = 0;
        List<int> GameNums = new List<int>();
        List<int> GamePows = new List<int>();
        
       for (i = 0; i < Input.Games.Count; i++)
        {
            GamePows.Add(Colours.GetGamePower(i));

            if (Colours.GetGameNums(i))
            {
                GameNums.Add(i + 1);
            }
            else { continue; }
        }

        Console.WriteLine(GameNums.Sum());
        Console.WriteLine(GamePows.Sum());
    }
}