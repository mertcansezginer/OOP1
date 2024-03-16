using System;

namespace ProjeMert
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // creditManager oluşturuldu ve hesaplama işlemi yapıldı.
            CreditManager creditManager = new CreditManager();
            creditManager.Calculate();

            // Müşteri oluşturuldu ve bilgileri belirlendi.
            Customer customer = new Customer();
            customer.Id = 1;
            customer.FirstName = "Mertcan";
            customer.LastName = "Sezginer";
            customer.NationalIdentity = "4140230951";
            customer.City = "Istanbul";

            // customerManager oluşturuldu ve kaybetme silme işlemi yapıldı.
            CustomerManager customerManager = new CustomerManager(customer);
            customerManager.Save();
            customerManager.Delete();

            // CompanyOwner oluşturuldu ve bilgileri belirlendi
            CompanyOwner companyOwner = new CompanyOwner();
            companyOwner.Id = 2;
            companyOwner.FirstName = "Mehmet";
            companyOwner.LastName = "Yılmaz";
            companyOwner.NationalIdentity = "3214124151";
            companyOwner.City = "Ankara";
            companyOwner.CompanyName = "ABC";

            // CompanyOwnerManager oluşturuldu ve kaydetme silme işlemi yapıldı.
            CompanyOwnerManager companyOwnerManager = new CompanyOwnerManager(companyOwner);
            companyOwnerManager.Save();
            companyOwnerManager.Delete();

            Console.ReadLine();
        }
    }

    // CreditManager sınıfı oluşturuldu
    class CreditManager
    {
        // Calculate metodu oluşturuldu
        public void Calculate()
        {
            Console.WriteLine("Hesaplandi");
        }
    }

    // Customer sınıfı oluşturuldu
    class Customer
    {
        // Constructor method yazıldı, customer çalıştırıldığında bu metod çalışacak ilk olarak.
        public Customer()
        {
            Console.WriteLine("Musteri Nesnesi Baslatildi");
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }
        public string City { get; set; }
    }

    // CompanyOwner sınıfı, Customer sınıfından katılım aldı, inheritance yaptık.
    class CompanyOwner : Customer
    {
        // Customer bilgilerine ek olarak CompanyName ekledik.
        public string CompanyName { get; set; } 
    }

    // CustomerManager sınıfı oluşturduk.
    class CustomerManager
    {
        private Customer _customer;       // customerManager sınıfı içerisinde _customer adında bir field oluşturduk.

        
        public CustomerManager(Customer customer)
        {
            _customer = customer;   // customer nesnesini _customer field ına atadık.
        }

        // save metodunu tanımladık.
        public virtual void Save()   //aşağıda override yapabilmek için burada virtual olarak belirtmemiz gerekli.
        {
            Console.WriteLine("Musteri kaydedildi: " + _customer.FirstName);
        }

        // delete metodunu tanımladık.
        public virtual void Delete()
        {
            Console.WriteLine("Musteri silindi: " + _customer.FirstName);
        }
    }

    // CompanyOwnerManager sınıfı CustomerManager sınıfından katılım aldı, inheritance yaptık.
    class CompanyOwnerManager : CustomerManager
    {
        private CompanyOwner _companyOwner;   //_companyOwner adında bir field oluşturduk, class ın içerisinde olusturulacak nesneleri yerlestirmek icin.

        // Satıcı yöneticisi, bir satıcı nesnesi alarak başlatılır
        public CompanyOwnerManager(CompanyOwner companyOwner) : base(companyOwner)
        {
            _companyOwner = companyOwner;      // companyOwner nesnesini _companyOwner field ına atadık.
        }

        // save metodunu yazdık
        public override void Save()   //override kullandık, yukarıda ilk yazdığımız save metodunu override etmek için.
        {
            Console.WriteLine("Şirket sahibi kaydedildi: " + _companyOwner.FirstName + " - " + _companyOwner.CompanyName);
        }

        // delete metodunu yazdık
        public override void Delete()  
        {
            Console.WriteLine("Şirket sahibi silindi: " + _companyOwner.FirstName + " - " + _companyOwner.CompanyName);
        }
    }
}
