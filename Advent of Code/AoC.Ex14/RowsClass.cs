using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AoC.Ex14;

class OriginalFile
{
    private static string[]? readText = Read.ReadFile();
    public static string[] ReadText
    {
        get => readText != null ?
            readText : throw new NullReferenceException("File not found.");
        set => readText = value;
    }
    public static List<string> OriginalList = new List<string>(ReadText);
}

class RowsClass
{
    public static int RowCount13
    {
        get => OriginalFile.ReadText != null ?
            OriginalFile.ReadText.Length : throw new NullReferenceException("Error sry...");
    }  
    public static int RowCount24
    {
        get => OriginalFile.ReadText != null ?
            OriginalFile.ReadText[0].Length : throw new NullReferenceException("Error sry...");
    }
  
    //getting one column of the string array.
    public static char[] Column(int i, int rowcount, List<string> ReadText)
    {
        char[] column = new char[rowcount];
        for (int k = 0; k < rowcount; k++)
        {
            column[k] = ReadText[k][i];
        }
        return column;
    }
  
    /*changing the original char array to a list where
    columns are represented vertically. */
    public List<string> ReadList(int rowcount, List<string> ReadText)
    {
        List<string> ReadList = new List<string>();
        for (int i = 0; i < rowcount; i++)
        {
            ReadList[i] = new string(Column(i, rowcount, ReadText));
        }
        return ReadList;
    }
}
class Tilts : RowsClass
{
    public static string GetRowsNW(List<string> ReadList, int i, int rowcount)
    {
        int k;
        int j;
        
        char[] column = Column(i, rowcount, ReadList);

        for (k = 0; k < rowcount; k++)
        {
            if (column[k] == '#') {continue;}
            if (column[k] == 'O') {continue;}
            if (k > rowcount - 2) {break;}

            for (j = k + 1; j < rowcount; j++)
            {
                if (column[j] == '#')
                {
                    k = j;
                    break;
                }
                if (column[j] == 'O')
                {
                    column[k] = 'O';
                    column[j] = '.';
                    break;
                }
            }
        }

        string columnstring = new string(column);
        return columnstring;
    }

    public static string GetRowsSE(List<string> ReadList, int i, int rowcount)
    {
        int j;
        int k;
        char[] column = Column(i, rowcount, ReadList);

        for (k = rowcount - 1; k >= 1; k--)
        {
            if (column[k] == '#') {continue;}
            if (column[k] == 'O') {continue;}

            for (j = k - 1; j >= 0; j--)
            {
                if (column[j] == '#')
                {
                    k = j;
                    break;
                }
                if (column[j] == 'O')
                {
                    column[k] = 'O';
                    column[j] = '.';
                    break;
                }
            }
        }

        string columnstring = new string(column);
        return columnstring;   
    }
 
}

class Read
{
     public static string[] ReadFile()
     {
        string path = @"C:\Users\Daniel\Desktop\PELIOHJELMOINTI\C# opiskelua\CsharpProjects\Advent of Code\platform_content\platform_content.txt";
        string[] readText = File.ReadAllLines(path);
        return readText;
     }
}
