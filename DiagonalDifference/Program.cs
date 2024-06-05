namespace DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // İster |
            // İlk olarak kullanıcıdan kare matrisi oluşturacak olan uzunluk değerini alıyoruz. Örneğin 3 girildi ise 3 satırlı ve her satırda 3 değer olacak şekilde girdi yapmamız gerekmektedir.
            // Girilen değerler -100 <= n <= 100 aralığında olmak zorundadır.
            // Ardından ilk değerleri topladığımız Row1Column1,Row2Column2,Row3Column3 değerleri ile ikinci hesaplayacağımız değer olan Row1Column3,Row1Column2,Row1Column1 değerleri arasındaki sayısal farkın mutlak değerini döndürmemiz gereken bir metod yazmamız gerekmektedir.

            Environment.SetEnvironmentVariable("OUTPUT_PATH", "D:\\Temp\\Output.txt");
            TextWriter textWriter = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> arr = [];

            for (int i = 0; i < n; i++)
            {
                var oTemp = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

                // Her bir satırda girilecek olan değer n değeri kadar eleman sayısı olmak zorundadır. Ayrıca listeye girilecek olan değerler -100'den küçük ve 100'den bütük olamaz.
                while (oTemp.Count != n || oTemp.Any(x => x < -100 || x > 100))
                {
                    oTemp = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
                }

                arr.Add(oTemp);
            }

            textWriter.WriteLine(Result.diagonalDifference(arr));
            textWriter.Flush();
            textWriter.Close();
        }
    }

    class Result
    {
        /*
         * Complete the 'diagonalDifference' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY arr as parameter.
         */
        public static int diagonalDifference(List<List<int>> arr)
        {
            int oFirstValue = 0, oSecondValue = 0, oFirstCounter = 0, oSecondCounter = (arr.Count - 1); 

            foreach (var row in arr)
            {
                oFirstValue +=  row[oFirstCounter];
                oSecondValue += row[oSecondCounter];

                oFirstCounter++;
                oSecondCounter--;
            }

            var oFark = oFirstValue - oSecondValue;

            return Math.Abs(oFark);
        }
    }
}
