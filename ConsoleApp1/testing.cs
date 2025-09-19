using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class testing
    {
        static void Main(string[] args)
        {
            IList<int> scores = new List<int>() { 97, 92, 81, 60 };

            // Define the query expression.
            List<int> scoreQuery =
                  IList(from score in scores //tesy // testing 1 //
                 where score > 96
                 select score);

            // Execute the query.
            foreach (var i in scoreQuery)
            {
                Console.Write(i + " ");
            }
        }


    }
}

