using System;
using System.Collections.Generic;


namespace cc3
{
    public class cricket
    {
        public void pointscalculation(int no_of_matches)
        {
            List<int> scores = new List<int>();
            for(int i = 0; i < no_of_matches; i++)
            {
                Console.WriteLine("Enter score for match " + i + 1 );
                int score = int.Parse(Console.ReadLine());
                scores.Add(score);
            }
            int total_score = 0;
            foreach(int score in scores)
            {
                total_score += score;
            }
            double average_score = no_of_matches > 0 ? (double)total_score / no_of_matches : 0;
            Console.WriteLine("sum of scores: "+total_score);
            Console.WriteLine("Average score: " + average_score);
            Console.Read();
        }
        public static void Main(string[] args)
        {
            cricket crket = new cricket();
            Console.Write("Enter the number of matches:");
            int num_matches = int.Parse(Console.ReadLine());
            crket.pointscalculation(num_matches);
        }
    }
}
