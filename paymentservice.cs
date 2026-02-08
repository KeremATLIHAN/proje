
namespace ECommerce
{
    public class PaymentService
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine("\n--- ODEME EKRANI ---");
            Console.WriteLine($"Toplam Tutar: {amount} TL");
            Console.Write("Kart numarasini giriniz (Sembolik): ");
            string kartNo = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Odeme aliniyor...");
            System.Threading.Thread.Sleep(1000); // 1 saniye bekleme efekti
            Console.WriteLine("Islem Basarili! Siparisiniz hazirlaniyor.");
            Console.ResetColor();
        }
    }
}
