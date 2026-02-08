namespace ECommerce
{
    public class UserService
    {
        public bool Login(string username, string password)
        {
            // Basitlik olsun diye hardcoded kontrol yapiyoruz
            if (username == "admin" && password == "1234")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n[Sistem] Giris basarili! Hosgeldin " + username);
                Console.ResetColor();
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[Hata] Kullanici adi veya sifre hatali!");
                Console.ResetColor();
                return false;
            }
        }
    }
}
