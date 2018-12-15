using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.ISeekYou
{
    public class Program
    {
        private static Random random = new Random();

        public static void FillArray(int[] arr)
        {
            for (int i = 0; i < 500; i++)
            {
                arr[i] = random.Next(-10, 10);
            }
        }

        public static void ShowArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("The program searches for the most common element in the array.");
            int[] array = new int[500];
            FillArray(array);
            Console.WriteLine("Original array:");
            ShowArray(array);

            int maxElement = SeekerMethods.Seeker(array);
            Console.WriteLine($"{Environment.NewLine}The most common element: {maxElement}");

            Console.WriteLine($"{Environment.NewLine}Compare the speed of the calculations:");

            var seeker = TimeMeasurements.TimeMeasure(() => array.Seeker());
            Console.WriteLine($"The method that directly implements the search:{seeker}");

            var seekerDelegateInstance = TimeMeasurements.TimeMeasure(() => array.SeekerDelegateInstance(SeekerMethods.Func));
            Console.WriteLine($"The method to which the search condition is passed through the delegate instance: {seekerDelegateInstance}");

            var seekerDelegateAnon = TimeMeasurements.TimeMeasure(() => array.SeekerDelegateInstance(delegate(int i, int j)
            {
                return i == j;
            }));
            Console.WriteLine($"The method to which the search condition is passed through the delegate as an anonymous method: {seekerDelegateAnon}");

            var seekerDelegateLambda = TimeMeasurements.TimeMeasure(() => array.SeekerDelegateInstance((i, j) => i == j));
            Console.WriteLine($"Method to which the search condition is passed through the delegate in the form of a lambda expression: {seekerDelegateLambda}");

            var seekerLINQ = TimeMeasurements.TimeMeasure(() => array.GroupBy(n => n).OrderByDescending(n => n.Count()).First());
            Console.WriteLine($"LINQ expressions: {seekerLINQ}");
        }
    }
}