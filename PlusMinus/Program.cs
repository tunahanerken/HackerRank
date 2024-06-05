namespace PlusMinus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ister |
            // Kullanicidan iki parametre alinacak
            // Birinci parametre dizi'nin eleman sayisi, 0 ila 101 arasinda bir deger olmali.
            // Ikinci parametre eleman sayisi kadar deger, dizi degeleri ise -100 ila 100 degerleri arasinda olmalidir.
            // Kullanicidan alinan bu degerler dogrultusunda ilk olarak pozitif, negatif son olarak 0 degerlerin eleman sayisi toplam dizinin eleman sayisina oranini hesaplayarak ondalik degeri alti basamakli bir deger dondurecek sekilde listelemeliyiz.

            // Kullanicidan dogru bir degerin gelmeme ihtimali dogrultusunda nullable bir degisken olusturuyoruz
            int? n;

            Console.Write("Enter the number of elements of the array: ");

            n = Convert.ToInt32(Console.ReadLine()?.Trim());

            // Eleman sayisi kontrolu 0'dan buyuk ve 101'den kucuk olmasi idi. Bunun icin hem sayi araligi hem de null kontrolunu ekliyoruz. Eger bu sartlari saglamiyor ise kullanicidan tekrar girdi yapilmasi istenecektir.
            while (n == null || n <= 0 || n > 100)
            {
                Console.Write("Please enter a number of elements greater than 0 and less than 100. Try again : ");

                n = Convert.ToInt32(Console.ReadLine()?.Trim());
            }

            // Goto parametresi dogrultusunda ilk parametre ile ikinci parametrenin eleman sayisi esitlenmiyor ise buradan devam edecektir.
            TryAgain:

            Console.Write($"Add {n} numbers with a space between them: ");

            var oParameter = Console.ReadLine();

            // Girilen degerin empty check kontrolu
            while (string.IsNullOrWhiteSpace(oParameter) || string.IsNullOrEmpty(oParameter))
            {
                Console.Write($"Please enter the correct data to specify the {n}-element array you entered.");

                oParameter = Console.ReadLine();
            }

            // Dogru degeleri girdigine gore eleman sayisi kadar listemizi doldurmamiz gerekecek olan verileri aliyoruz.
            // Asagidaki kod sunu ifade etmektedir. 
            // TrimEnd fonksiyonu ile girilen degerin sonundaki bosluklar temizlenir.
            // Split metodu ise her bosluk dogrultusunda veriyi boluyoruz.
            // Select metodu ile her bir degeri int veri tipine donusturuyoruz.
            // ToList metodu ile listeye donusturuyoruz.
            List<int> arr = oParameter!.TrimEnd().Split(' ').ToList().Select(arrTempt => Convert.ToInt32(arrTempt)).ToList();

            if (arr.Count == n)
            {
                Result.plusMinus(arr);
            }
            else
            {
                Console.WriteLine($"The data you entered does not match.");

                // Girilen eleman sayisi ile listenin eleman sayisi uyusmuyor. Bir onceki asamaya goto parametresi ile donebiliriz.
                goto TryAgain;
            }
        }
    }

    internal class Result
    {
        public static void plusMinus(List<int> arr)
        {
            // Ondalik sayi tipinde bir deger istendigi icin asagidaki gibi eleman sayisini listenin eleman sayisina bolerek double bir degere cast ediyoruz. Ardindan F6 parametresi ile virgulden sonra 6 basamagin goruntulenmesini istiyoruz.
            Console.WriteLine(((double)arr.Count(x => x > 0) / arr.Count).ToString("F6"));
            Console.WriteLine(((double)arr.Count(x => x < 0) / arr.Count).ToString("F6"));
            Console.WriteLine(((double)arr.Count(x => x == 0) / arr.Count).ToString("F6"));
        }
    }
}
