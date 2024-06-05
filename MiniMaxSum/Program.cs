namespace MiniMaxSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ister |
            // Kullanicidan 5 adet sayi almamiz gerekecek
            // 5 adet olusan listenin 4 elemaniyla olusturulabilecek en kucuk ve en buyuk toplami bulmamiz istenmektedir.
            // Bu iki deger int tipinden daha genis bir veri tipinden olabilir. long olarak degerlendiricez.

            TryAgain:

            Console.Write($"Add 5 numbers with a space between them: ");

            var oParameter = Console.ReadLine();

            // Girilen degerin empty check kontrolu
            while (string.IsNullOrWhiteSpace(oParameter) || string.IsNullOrEmpty(oParameter))
            {
                Console.Write($"Please enter the correct data to specify the 5-element array you entered.");

                oParameter = Console.ReadLine();
            }

            List<long> arr = oParameter.TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

            if (arr.Count != 5)
            {
                Console.Write("The list does not have 5 elements!");

                goto TryAgain;
            }

            Result.miniMaxSum(arr);
        }
    }

    internal class Result
    {
        public static void miniMaxSum(List<long> arr) => Console.Write($"{Convert.ToUInt64(arr.OrderBy(x => x).Take(4).Sum())} {Convert.ToUInt64(arr.OrderByDescending(x => x).Take(4).Sum())} ");
    }
}
