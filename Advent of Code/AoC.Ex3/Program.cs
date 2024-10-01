using System;
using System.Text;
using System.Text.RegularExpressions;

class MainProgram
{
    public static void Main(string[] args)
    {
        int i;
        int sum = 0;
        List<string> inputList = Inputs.Input;
        int length = inputList.Count;

        //Käydään läpi jokainen merkkirivi listassa ja summataan näiden summat yhteen.
        for (i = 0; i < length; i++)
        {
            sum += Inputs.GetNums(i);
           // System.Console.WriteLine(Inputs.GetNums(i));
           // System.Console.WriteLine(sum);
        }
        Console.Write(sum);
    }
}

class Inputs
{
    //Haetaan tiedostosta rivit ja muutetaan ne listaksi.
    static Inputs()
    {
        Input = new List<string>(File.ReadAllLines(@"C:\Users\Daniel\Desktop\Ohjelmia\aineistot\AoC3.txt"));
    }

    public static List<string> Input { get ; private set ; }
        
    //Haetaan merkkijonojen listasta numerot, jotka ovat symbolien vieressä.
    public static int GetNums(int lineNum)
    {
        List<int> Trouves = new List<int>();
        string line = Input[lineNum];

        //Tarkistetaan onko käsittelyssä ensimmäinen tai viimeinen rivi.
        bool isFirst = false;
        bool isLast = false;
        if (lineNum == 0) { isFirst = true; }
        if (lineNum == Input.Count - 1) { isLast = true;}
        string lineAbove;
        string lineBelow;
        int above = (lineNum == 0) ? lineNum : lineNum - 1;
        int below = (lineNum == Input.Count - 1) ? lineNum : lineNum + 1;

        //Määrätty muoto: ensiksi seulotaan numerot ja merkit niiden vieressä. Sitten tarkastetaan ovatko nämä viereiset merkit
        //pisteitä vai symboleita.
        string pattern1 = @".\d+.|^\d+.|.\d+\z";

        foreach (Match num in Regex.Matches(line, pattern1))
        {
            bool symbolACote;
            if (num.Index == 0)
            {
                symbolACote = ConditionA(num.Value[num.Length - 1]);
            }
            if (num.Index + num.Length == line.Length - 1)
            {
                symbolACote = ConditionA(num.Value[0]);
            }  
            else
            {
                symbolACote = ConditionA(num.Value[num.Length - 1]);
                if (!symbolACote)
                {
                    symbolACote = ConditionA(num.Value[0]);
                }
            }

            if (symbolACote)
            {
                int trouveNum = TakeMatchReturnInt(num.Value);
                Trouves.Add(trouveNum);
            }
            //Merkit numeron vierellä ovat siis pisteitä. Tarkistetaan onko numeron ylä- tai alapuolella symboleita.
            else
            {
                //Ensimmäisen rivin tapauksessa tarkistetaan vain alempi rivi.
                if (isFirst)
                {
                    lineBelow = Input[below];
                    if (LookAboveNBelow(lineBelow.Substring(num.Index, num.Length)))
                    {
                        int trouveNum = TakeMatchReturnInt(num.Value);
                        Trouves.Add(trouveNum);
                    }
                }
                //Viimeisen rivin tapauksessa tarkistetaan vain ylempi rivi.
                if (isLast)
                {
                    lineAbove = Input[above];
                    if (LookAboveNBelow(lineAbove.Substring(num.Index, num.Length)))
                    { int trouveNum = TakeMatchReturnInt(num.Value);
                        Trouves.Add(trouveNum); }
                }
                //Muutoin tarkistetaan molemmat rivit.
                if (!isFirst & !isLast)
                {
                    lineAbove = Input[above];
                    lineBelow = Input[below];
                    if (LookAboveNBelow(lineAbove.Substring(num.Index, num.Length))
                        || LookAboveNBelow(lineBelow.Substring(num.Index, num.Length)))
                    { int trouveNum = TakeMatchReturnInt(num.Value);
                        Trouves.Add(trouveNum);}
                }
            }
        }
        //Summataan yhteen tietyltä riviltä löydetyt numerot ja palautetaan se käyttäjälle.s
        int monSum = Trouves.Sum();
        //for (int i = 0; i < Trouves.Count; i++) {System.Console.WriteLine(Trouves[i]);}
        return monSum;
    }

    //Funktio, joka tarkistaa ovatko tietyt merkit merkkijonossa pisteitä tai numeroita.
    public static bool LookAboveNBelow(string s)
    {
        bool isRelevant = false;

        foreach (char c in s)
        {
            if (c != '.' & !Char.IsDigit(c))
            {
                isRelevant = true;
                break;
            }
        }
        return isRelevant;   
    }

    public static int TakeMatchReturnInt(string s)
    {
        string pattern = @"\d+";
        Match numString = Regex.Match(s, pattern);
        int number = Convert.ToInt32(numString.Value);
        return number;
    }

    public static bool ConditionA(char c)
    {
        bool symbolACote = false;

        if (c != '.' & !Char.IsDigit(c))
        {
            symbolACote = true;
        }
        return symbolACote;
    }
}
