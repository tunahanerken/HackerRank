namespace LonelyInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // İster |
            // İlk olarak 1 ila 1'den büyük ve 100'den küçük eleman sayısını belirteceğimiz bir girdi 
            // İkinci olarak ilk girilen eleman sayısı kadar int değer girmeliyiz bu değer'ler 0 ila maksimum ilk girdi değeri kadar büyüklükte olmalıdır.

            Environment.SetEnvironmentVariable("OUTPUT_PATH", "D:\\Temp\\Output.txt");
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            // 1<=n<100 kuralı
            while (n < 1 && n >= 100)
            {
                n = Convert.ToInt32(Console.ReadLine().Trim());
            }

            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

            // İlk girdi değeri ile ikinci girdinin eleman sayısı uymuyorsa, ya da ilk girdiden daha büyük değerde bir eleman girdi ise
            while (a.Count != n)
            {
                Console.WriteLine($"Lütfen {n} değerinden küçük elemanlı liste giriniz:");

                a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();
            }

            textWriter.WriteLine(Result.lonelyinteger(a));
            textWriter.Flush();
            textWriter.Close();
        }
    }

    class Result
    {
        /*
         * Complete the 'lonelyinteger' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY a as parameter.
         */

        public static int lonelyinteger(List<int> a)
        {
            // Gelen listeyi groupBy ile dizginleyerek dizgilenmiş değerler içerisinde sadece 1 (bir) tane olan değeri döndürüyoruz.
            return a
                .GroupBy(x => x)
                .Where(g => g.Count() == 1)
                .Select(g => g.Key)
                .FirstOrDefault();
        }
    }
}
