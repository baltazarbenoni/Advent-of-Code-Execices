using System;
using System.Text;

namespace AoC.Ex14;

class Rows
{
    public static string[] ReadText()
    {
        string path = @"C:\Users\Daniel\Desktop\PELIOHJELMOINTI\C# opiskelua\CsharpProjects\Advent of Code\platform_content\test.txt";
        string[] readText = File.ReadAllLines(path);
        return readText;
    }

     public static char[] GetRows(List<string> readText, int i, int rowcount)
    {
        int k;
        int j;
        char[] row = new char[rowcount];
        
        for (k = 0; k < rowcount; k++)
            {
            row[k] = readText[k][i];
            }

        for (k = 0; k < rowcount; k++)
        {
            if (row[k] == '#') {continue;}
            if (row[k] == 'O') {continue;}
            if (k > rowcount - 2) {break;}

            for (j = k + 1; j < rowcount; j++)
            {
                if (row[j] == '#')
                {
                    k = j;
                    break;
                }
                if (row[j] == 'O')
                {
                    row[k] = 'O';
                    row[j] = '.';
                    break;
                }
            }
        }
        return row;
    }
    public static char[] GetRowsSE(List<string> readText, int i, int rowcount)
    {
        int k;
        int j;
        char[] row = new char[rowcount];
        
        for (k = rowcount - 1; k >= 0; k--)
            {
            row[k] = readText[k][i];
            }

        for (k = rowcount - 1; k >= 0; k--)
        {
            if (row[k] == '#') {continue;}
            if (row[k] == 'O') {continue;}
            if (k == 0) {break;}

            for (j = k - 1; j >= 0; j--)
            {
                if (row[j] == '#')
                {
                    k = j;
                    break;
                }
                if (row[j] == 'O')
                {
                    row[k] = 'O';
                    row[j] = '.';
                    break;
                }
            }
        }
        return row;
    }
    public static List<string> ConvertCharStr(List<string> readText, int rowcount)
    {
        int i;
        char[] row = new char[rowcount];
        List<string> rows = new List<string>();
       
        for (i = 0; i < readText[0].Length; i++)
        {
            row = GetRows(readText, i, rowcount);
            rows.Add(new string (row));
        }
        return rows;
    }
    public static List<string> Iterations(List<string> readText, int rowcount13, int rowcount24)
    {
        List<string> rows = new List<string>();
        int j;
        int i;
        for (j = 0; j < 2; j++)
        {
            if (j < 1)
            {
                for (i = 0; i < rowcount24; i++)
                {
                    readText[i] = new string(GetRows(readText, i, rowcount13));
                }
                for (i = 0; i < rowcount13; i++)
                {
                    readText[i] = new string(GetRows(readText, i, rowcount24));
                }
            }
            else
            {
                for (i = 0; i < rowcount24; i++)
                {
                    readText[i] = new string(GetRowsSE(readText, i, rowcount13));
                }
                for (i = 0; i < rowcount13; i++)
                {
                    readText[i] = new string(GetRowsSE(readText, i, rowcount24));
                }
            }
        }
        return readText;
    }
}