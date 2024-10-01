using System;
using System.Text;
using System.Text.RegularExpressions;
class Input
{   
    private static List<string> games;

    static Input()
    {
        string path = @"C:\Users\Daniel\Desktop\Ohjelmia\aineistot\AoC_2.txt";
        List<string> list = new List<string>(File.ReadAllLines(path));
        games = list;
    }
    public static List<string> Games
    { get { return games; } }

    public static int ColourCount(string colour, int gamenum)
    {
        int colourResult = 0; 
        int i;
        List<int> colourCounts = new List<int>();
        string game = Games[gamenum];

        var semicolIndex = new List<int>();
        semicolIndex.Add(game.IndexOf(':'));
        for (i = 0; i < game.Length; i++)
        {
            if (game[i] == ';') { semicolIndex.Add(i); }
        }

        for (i = 0; i < semicolIndex.Count; i++)
        {
            int searchLength = (i == semicolIndex.Count - 1) ? game.Length - semicolIndex[i] : semicolIndex[i+1] - semicolIndex[i];
            string pattern = $@"\d+(?= {colour})";
            
            Regex cherche = new Regex(pattern);
             
            Match found = cherche.Match(game, semicolIndex[i], searchLength);
            if(found.Success)
                {
                    int foundnum = Int32.Parse(found.Value);
                    colourCounts.Add(foundnum);
                }
            else {continue;}
        }
        colourResult = (from num in colourCounts select num).Max();
        return colourResult;
    }   
}