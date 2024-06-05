namespace FindTheMedian
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("OUTPUT_PATH", "D:\\Temp\\Output.txt");
            TextWriter textWriter = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            while (n < 1 || n > 1000001 || n % 2 == 0)
            {
                n = Convert.ToInt32(Console.ReadLine().Trim());
            }

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            while (arr.Count != n)
            {
                arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            }

            int result = Result.findMedian(arr);

            textWriter.WriteLine(result);
            textWriter.Flush();
            textWriter.Close();
        }
    }

    internal class Result
    {
        /*
         * Complete the 'findMedian' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static int findMedian(List<int> arr)
        {
            arr.Sort();

            int returnValue = (arr.Count - 1) / 2;

            return arr[returnValue];
        }
    }
}
