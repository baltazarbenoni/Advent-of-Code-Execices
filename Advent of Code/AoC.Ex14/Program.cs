using System;
using System.Text;

namespace AoC.Ex14;

class Program
{
    static void Main()
    {
        int i;
        int iterations = 103;
        List<string> readList = new List<string>();

        string[] readText = OriginalFile.ReadText;
        readList = OriginalFile.OriginalList;


        for (i = 0; i < iterations; i++)
        {
            readList = OneIteration(readList);
        }

        double sum = Sums.Sum(readList);
        System.Console.WriteLine(sum);;
       
    }

    public static List<string> OneIteration(List<string> readList)
    {
         int i;
        int rowcount13 = RowsClass.RowCount13;
        int rowcount24 = RowsClass.RowCount24;

        for (i = 0; i < rowcount24; i++)
        {
            if (i < rowcount24) { readList[i] = Tilts.GetRowsNW(readList, i, rowcount13); }
            else { readList.RemoveAt(i); }
        }
        for (i = 0; i < rowcount13; i++)
        {
            readList[i] = Tilts.GetRowsNW(readList, i, rowcount24);
        }
        for (i = 0; i < rowcount24; i++)
        {
            if (i < rowcount24) {readList[i] = Tilts.GetRowsSE(readList, i, rowcount13); }
            else { readList.RemoveAt(i);}
        }
        for (i = 0; i < rowcount13; i++)
        {
            readList[i] = Tilts.GetRowsSE(readList, i, rowcount24);
        }

        return readList;
    }
}
      
