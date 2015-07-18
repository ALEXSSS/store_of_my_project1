using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueVotings
{
    static class Secondtour
    {
        public static double[] second_tour(int[][] votes, int max, int max1, Random voit)
        {
            int candidat=0;
            double[] infcandidat = new double[2];
            double[][] newvotes = new double[votes.Length][];
            for (int i = 0; i < votes.Length; i++)
            {
                newvotes[i] = new double[2];
                newvotes[i][0] = ((double)votes[i][max] / (double)(votes[i][max] + votes[i][max1])) * 100;
                newvotes[i][1] = 100-newvotes[i][0];
                if ((voit.NextDouble() * 100) <= newvotes[i][0]) candidat++;
            }
            infcandidat[0] = ((double)candidat / (double)votes.Length) * 100;
            infcandidat[1] = 100 - infcandidat[0];
            return infcandidat;
        }
    }
}
