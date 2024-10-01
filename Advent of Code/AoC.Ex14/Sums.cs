using System;
using System.Text;

namespace AoC.Ex14;

class Sums
{
    public static double Sum(List<string> readList)
    {
        int i;
        int j;
        int sum = 0;
        List<int> distance = new List<int>();

        for (i = 0; i < RowsClass.RowCount24; i++)
        {
            for (j = 0; j < RowsClass.RowCount13; j++)
            {
                if (readList[j][i] == 'O')
                {
                    distance.Add(RowsClass.RowCount13 - j);
                }
            }
        }
    
        sum = distance.Sum();
        return sum;
    }
}