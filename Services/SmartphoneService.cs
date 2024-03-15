public class SmartphoneService
{
   public void ListAllSmartphones(){
      Console.Clear();
      SmartphoneRepository r = new SmartphoneRepository();
      List<Smartphone> listSmartphones = r.GetSmartphones();
      foreach(Smartphone smartphone in listSmartphones){
         Console.WriteLine(smartphone);
      }

      Console.WriteLine("Press Enter to go to the main menu");
      ConsoleKeyInfo key = Console.ReadKey(true);

      switch (key.Key)
      {
         case ConsoleKey.Enter:
            break;
      }
   }

   public void SearchSmartphones(){
      Console.Clear();
      Console.WriteLine("Search For Smartphones");
      Console.WriteLine("Enter brand or type:");
      string value = Console.ReadLine();

      SmartphoneRepository r = new SmartphoneRepository();
      List<Smartphone> listSmartphones = r.GetSmartphones();
      List<Smartphone> searchedSmartphones = new List<Smartphone>();

      foreach(Smartphone item in listSmartphones){
         if(item.Brand.ToLower().Contains(value.ToLower()) || item.Type.ToLower().Contains(value.ToLower())){
            searchedSmartphones.Add(item);
         }
      }

      foreach(Smartphone smartphone in searchedSmartphones){
         Console.WriteLine(smartphone);
      }

      Console.WriteLine("Press Enter to go to the main menu");
      ConsoleKeyInfo key = Console.ReadKey(true);

      switch (key.Key)
      {
         case ConsoleKey.Enter:
            break;
      }
   }

   public void AddNewSmartphone(){
      Console.Clear();
      Console.WriteLine("Add New Smartphone");
      Console.WriteLine("Enter id:");
      int id = int.Parse(Console.ReadLine());
      Console.WriteLine("Enter brand:");
      string brand = Console.ReadLine();
      Console.WriteLine("Enter type:");
      string type = Console.ReadLine();
      Console.WriteLine("Enter release year:");
      int releaseYear = int.Parse(Console.ReadLine());
      Console.WriteLine("Enter start price:");
      int startPrice = int.Parse(Console.ReadLine());
      Console.WriteLine("Enter operating system:");
      string operatingSystem = Console.ReadLine();

      Smartphone newSmartphone = new Smartphone();
      newSmartphone.Id = id;
      newSmartphone.Brand = brand;
      newSmartphone.Type = type;
      newSmartphone.ReleaseYear = releaseYear;
      newSmartphone.StartPrice = startPrice;
      newSmartphone.OperatingSystem = operatingSystem;

      SmartphoneRepository r = new SmartphoneRepository();

      r.AddSmartphone(newSmartphone);

      Task.Delay(200).Wait();
      Console.WriteLine("Student Added!");
      Task.Delay(600).Wait();
   }
}