using System;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            
            User kullanici1 = new User("Arda","Arslan", "11111111111");
            User kullanici2 = new User("Selin","Erez",  "22222222222");
            User kullanici3 = new User("Hande","Guzel", "33333333333");
            User kullanici4 = new User("Faruk","Yahya", "44444444444");
            User kullanici5 = new User("Kemal","Atasan","55555555555");

            User.MenuSecim();


        }
    }

    public class User
    {
        string Ad;
        string Soyad;
        string No;
        static List<User> users;

        public User(string ad,string soyad, string no) //kurucu metodum bu benim, argümanları küçük harfle yazıyoruz.
        {
            this.Ad = ad; //bu sınıfın elemanı diyoruz yani
            this.Soyad=soyad;
            this.No=no;
            users.Add(this);
        }

        static User()
        {
            users = new List<User>();
        }


    
        public static void MenuSecim()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayi Silmek");
            Console.WriteLine("(3) Varolan Numarayi Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");

            int tuslama = int.Parse(Console.ReadLine());

            switch(tuslama)
            {
                case 1:
                    YeniNumaraKaydetmek();
                    break;
                case 2:
                    VarolanNumarayiSilmek();
                    break;
                case 3:
                    VarolanNumarayiGuncellemek();
                    break;
                case 4:
                    RehberiListelemek();
                    break;
                case 5:
                    RehberdeAramaYapmak();
                    break;    
                default:
                    Console.WriteLine("Yanliş veri girdiniz");
                    MenuSecim();
                break;
            }


        }

        public static void YeniNumaraKaydetmek()
        {
            try
            {
                Console.WriteLine("Lütfen isim giriniz".PadRight(40)+":");
                string yeniKullaniciIsim = Console.ReadLine();
                Console.WriteLine("Lütfen soyisim giriniz".PadRight(40)+":");
                string yeniKullaniciSoyisim = Console.ReadLine();
                Console.WriteLine("Lütfen telefon numarası giriniz".PadRight(40)+":");
                string telNo = Console.ReadLine();

                User kullanici = new User(yeniKullaniciIsim, yeniKullaniciSoyisim, telNo);
                Console.WriteLine("Kullanici başariyla kaydedildi.");
                MenuSecim();
            }

            catch(Exception yanlisGirdi)
            {
                Console.WriteLine(yanlisGirdi.Message);
            }
        }

        public static void VarolanNumarayiSilmek()
        {
            Console.WriteLine("Lütfen silmek istediğiniz kişinin adini ya da soyadini giriniz:");
            string silinenIsim = Console.ReadLine();
            
            bool status=false;
            foreach(User user in users)
            {
                if(user.Ad == silinenIsim || user.Soyad ==silinenIsim)
                {
                    Console.WriteLine("{0} isimli kişi rehberden silinmek üzere, onayliyor musunuz ?(y/n)",silinenIsim);
                    char y_or_n = Console.ReadKey().KeyChar;
                    if(y_or_n == 'y')
                    {
                        users.Remove(user);
                        Console.WriteLine("Kişi rehberden başarıyla silindi.");
                        MenuSecim();
                        status =true;
                    }
                    else
                    {
                        Console.WriteLine("İsmi ya da soyismi girilen kişi silinemedi.");
                        MenuSecim();
                    }
                }
                
            }
            if(status==false)
                {
                    Console.WriteLine("Aradiğiniz kritilerlere uygun veri rehberde bulunamadi. Lütfen bir seçim yapiniz.");
                    Console.WriteLine("* Silmeyi sonlandirmak için : (1)");
                    Console.WriteLine("* Yeniden denemek için      : (2)");
                    int silmeIslemiSecimNo = int.Parse(Console.ReadLine());
                    if(silmeIslemiSecimNo ==1)
                        MenuSecim();
                    else
                        VarolanNumarayiSilmek();
                }
            
            
        }

        public static void VarolanNumarayiGuncellemek()
        {
            Console.WriteLine("Lütfen numarasini güncellemek istediğiniz kişinin adini ya da soyadini giriniz:");
            string guncellenenIsim = Console.ReadLine();
            
            bool status=false;
            foreach(User user in users)
            {
                if(user.Ad == guncellenenIsim || user.Soyad == guncellenenIsim)
                {
                    

                    Console.WriteLine($"{guncellenenIsim} isimli ya da soyisimli kişinin numarası güncellenecektir. Lütfen yeni numarayı giriniz:");
                    user.No = Console.ReadLine();
                    Console.WriteLine("Kişinin var olan numarası başarıyla güncellenmiştir.");
                    status =true;
                    MenuSecim();
                    
                    
                }
                
            }
            

            if(status == false)
            {
                Console.WriteLine("Aradiğiniz kritilerlere uygun veri rehberde bulunamadi. Lütfen bir seçim yapiniz.");
                Console.WriteLine("* Güncellemeyi sonlandirmak için : (1)");
                Console.WriteLine("* Yeniden denemek için".PadRight(29)+": (2)");
                int guncellemeSecimNo = int.Parse(Console.ReadLine());
                if(guncellemeSecimNo ==1)
                    MenuSecim();
                else
                    VarolanNumarayiGuncellemek();
            }
        }

        public static void RehberiListelemek()
        {
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("*****".PadRight(40));
            foreach(User user in users.OrderByDescending(x => x.Ad).ToList())
            {
                if(users.Count()>0 )
                {
                    Console.WriteLine("isim: {}",user.Ad);
                    Console.WriteLine("Soyisim: {}",user.Soyad);
                    Console.WriteLine("Telefon Numarası: {}",user.No);
                    Console.WriteLine("-");
                }

                else
                {
                    Console.WriteLine("Rehberde hiç kullanici yok.");
                    MenuSecim();
                }
                
            

            }

            MenuSecim();
        }

        public static void RehberdeAramaYapmak()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
            Console.WriteLine("**********************************************");

            Console.WriteLine("Isim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine("Telefon numarasina göre arama yapmak için: (2)");
            int aramaGirisNo = int.Parse(Console.ReadLine());
            
            bool status =false;

            switch(aramaGirisNo)
            {
                case '1':
                {
                    Console.WriteLine("Arama yapmak istediğiniz ismi veya soyismi giriniz");
                    string isimArama = Console.ReadLine();

                    
                    foreach(User user in users)
                    {
                        if(isimArama == user.Ad || isimArama ==user.Soyad)
                        {
                            Console.WriteLine($"isim: {user.Ad}");
                            Console.WriteLine($"Soyisim: {user.Soyad}");
                            Console.WriteLine($"Telefon Numarası: {user.No}");
                            Console.WriteLine("-");
                            status=true;
                            
                        }
                    } 
                    break;   
                }

                case '2':
                {
                    Console.WriteLine("Arama yapmak istediğiniz telefon numarasini giriniz");
                    string telefonNoArama = Console.ReadLine();

                    foreach(User user in users)
                    {   
                        if(telefonNoArama == user.No)
                        {
                            Console.WriteLine($"isim: {user.Ad}");
                            Console.WriteLine($"Soyisim: {user.Soyad}");
                            Console.WriteLine($"Telefon Numarasi: {user.No}");
                            Console.WriteLine("-");
                            status=true;
                        }
                        
                    }
                break;
                }
            }

                    
            if(status==true)
            {
                Console.WriteLine("Uygun kullanici bulunamadi. Tekrar arama yapmak ister misiniz?(y/n");
                char y_or_n = Console.ReadKey().KeyChar;
                if(y_or_n == 'y')
                {
                    RehberdeAramaYapmak();
                }
                else
                    MenuSecim();
            }

        }
    }
}