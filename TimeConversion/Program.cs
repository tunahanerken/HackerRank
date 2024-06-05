using System.Globalization;

namespace TimeConversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ister |
            // Kullanıcıdan 12 saatlik formatta bir saat değerini alıp bunu 24 saatlik saat dilimine çevirmemiz istenmektedir.

            string s;

            s = Console.ReadLine();

            char[] control = { ':' };

            while (
                    // Kullanıcınının girdiği değerler null ise
                    s == null ||
                    s == string.Empty ||
                    // Kullanıcının girdiği verinin sonunda AM veya PM değerleri yoksa
                    (!s.EndsWith("AM") && !s.EndsWith("PM")) ||
                    // Kullanıcının girdiği değerler arasında 2 tane : değeri yoksa
                    s.IndexOfAny(control, 2, 2) == -1 ||
                    // Girilen değerin 0, 1, 3, 4, 6, 7 indexlerinde sayı olup olmadığı kontrolü
                    !Char.IsDigit(s.ToCharArray()[0]) ||
                    !Char.IsDigit(s.ToCharArray()[1]) ||
                    !Char.IsDigit(s.ToCharArray()[3]) ||
                    !Char.IsDigit(s.ToCharArray()[4]) ||
                    !Char.IsDigit(s.ToCharArray()[6]) ||
                    !Char.IsDigit(s.ToCharArray()[7])
            )
            {
                s = Console.ReadLine();
            }

            string result = Result.timeConversion(s);

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }

    internal class Result
    {
        public static string timeConversion(string s)
        {
            return DateTime.ParseExact(s, "hh:mm:sstt", CultureInfo.InvariantCulture).ToString("HH:mm:ss");
        }
    }
}
