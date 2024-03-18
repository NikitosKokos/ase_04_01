SmartphoneRepository smartphoneRepository = new SmartphoneRepository();
SmartphoneService smartphoneService = new SmartphoneService(smartphoneRepository);

bool isSelected = false;
while(!isSelected){
   Console.Clear();
   Console.WriteLine("\u001B[1mSmartphones App\u001b[0m");
   Console.WriteLine("1 - List all smartphones in the catalog");
   Console.WriteLine("2 - Search for smartphones by brand or type");
   Console.WriteLine("3 - Add a new smartphone to the catalog");
   Console.WriteLine("4 - Exit");
   int option = int.Parse(Console.ReadLine());
   ConsoleKeyInfo key;
   switch (option)
   {
      case 1:
         Console.Clear();
         List<Smartphone> listSmartphones = smartphoneService.ListAllSmartphones();

         if(listSmartphones.Count == 0){
            Console.WriteLine("No smartphones available");
         }else{
            foreach(Smartphone smartphone in listSmartphones){
               Console.WriteLine(smartphone);
            }
         }

         Console.WriteLine("Press Enter to go to the main menu");
         key = Console.ReadKey(true);

         switch (key.Key)
         {
            case ConsoleKey.Enter:
               break;
         }
         break;
      case 2:
         Console.Clear();
         Console.WriteLine("Search For Smartphones");
         Console.WriteLine("Enter brand or type:");
         string value = Console.ReadLine();

         List<Smartphone> searchedSmartphones = smartphoneService.SearchSmartphones(value);

         if(searchedSmartphones.Count == 0){
            Console.WriteLine("No matching smartphones found :(");
         }else{
            foreach(Smartphone smartphone in searchedSmartphones){
               Console.WriteLine(smartphone);
            }
         }

         Console.WriteLine("Press Enter to go to the main menu");
         key = Console.ReadKey(true);

         switch (key.Key)
         {
            case ConsoleKey.Enter:
               break;
         }
         break;
      case 3:
         Console.Clear();
         Console.WriteLine("Add New Smartphone");
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
         newSmartphone.Brand = brand;
         newSmartphone.Type = type;
         newSmartphone.ReleaseYear = releaseYear;
         newSmartphone.StartPrice = startPrice;
         newSmartphone.OperatingSystem = operatingSystem;

         bool isSuccessful = smartphoneService.AddNewSmartphone(newSmartphone);

         Task.Delay(200).Wait();
         if(isSuccessful){
            Console.WriteLine("Smartphone Added!");
         }else{
            Console.WriteLine("Smartphone NOT Added!");
         }
         Task.Delay(1600).Wait();
         break;
      case 4:
         isSelected = true;
         Console.Clear();
         Environment.Exit(0);
         break;
      default:
         break;
   }
}