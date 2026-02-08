using System;
using System.Collections.Generic;

namespace ECommerce
{
    class Program
    {
        static void Main(string[] args)
        {
            

            // Urun Listesi (Database yerine list kullaniyoruz)
            List<Product> products = new List<Product>
            {
                new Product(1, "Laptop", 15000),
                new Product(2, "Mouse", 350),
                new Product(3, "Klavye", 750),
                new Product(4, "Monitor", 3200)
            };

            Console.Title = "MiniTrendyol v1.0";
            
            // 1. GIRIS EKRANI
            Console.WriteLine("--- MiniTrendyol'a Hosgeldiniz ---");
            bool isLoggedIn = false;
            while (!isLoggedIn)
            {
                Console.Write("Kullanici Adi: ");
                string u = Console.ReadLine();
                Console.Write("Sifre: ");
                string p = Console.ReadLine();
                isLoggedIn = userManager.Login(u, p);
            }

            

            // 2. ANA MENU
            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Urunleri Listele");
                Console.WriteLine("2. Sepete Urun Ekle");
                Console.WriteLine("3. Sepeti Goruntule");
                Console.WriteLine("4. Odeme Yap (Cikis)");
                Console.Write("Seciminiz: ");
                
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Console.WriteLine("\n--- URUN LISTESI ---");
                        foreach (var prod in products)
                        {
                            Console.WriteLine($"{prod.Id} - {prod.Name} : {prod.Price} TL");
                        }
                        break;

                    case "2":
                        Console.Write("Almak istediginiz urun ID'sini girin: ");
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            var selectedProduct = products.Find(p => p.Id == id);
                            if (selectedProduct != null)
                            {
                                cartManager.AddToCart(selectedProduct);
                            }
                            else
                            {
                                Console.WriteLine("[Hata] Urun bulunamadi!");
                            }
                        }
                        break;

                    case "3":
                        Console.WriteLine("\n--- SEPETINIZ ---");
                        var items = cartManager.GetCartItems();
                        if (items.Count == 0) Console.WriteLine("Sepetiniz bos.");
                        else
                        {
                            foreach (var item in items)
                            {
                                Console.WriteLine($"- {item.Name} ({item.Price} TL)");
                            }
                            Console.WriteLine($"TOPLAM: {cartManager.CalculateTotal()} TL");
                        }
                        break;

                    case "4":
                        decimal total = cartManager.CalculateTotal();
                        if (total > 0)
                        {
                            paymentManager.ProcessPayment(total);
                            return; // Programi bitir
                        }
                        else
                        {


                            Console.WriteLine("Sepet bos, odeme yapilamaz.");
                        }
                        break;

                    default:
                        Console.WriteLine("Gecersiz islem.");
                        break;
                }
            }
        }
    }
}

