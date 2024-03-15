// SmartphoneRepository smartphoneRepository = new SmartphoneRepository();

// Smartphone smartphone = new Smartphone();
// smartphone.Id = 13;
// smartphone.Brand = "Samsung";
// smartphone.Type = "Galaxy S21";
// smartphone.ReleaseYear = 2021;
// smartphone.StartPrice = 999;
// smartphone.OperatingSystem = "Android";

// smartphoneRepository.AddSmartphone(smartphone);

SmartphoneService smartphoneService = new SmartphoneService();

// smartphoneService.AddNewSmartphone();

// smartphoneService.ListAllSmartphones();
// smartphoneService.SearchSmartphones();

bool isSelected = false;
while(!isSelected){
   Console.Clear();
   Console.WriteLine("\u001B[1mSmartphones App\u001b[0m");
   Console.WriteLine("1 - List all smartphones in the catalog");
   Console.WriteLine("2 - Search for smartphones by brand or type");
   Console.WriteLine("3 - Add a new smartphone to the catalog");
   Console.WriteLine("4 - Exit");
   int option = int.Parse(Console.ReadLine());
   switch (option)
   {
      case 1:
         smartphoneService.ListAllSmartphones();
         break;
      case 2:
         smartphoneService.SearchSmartphones();
         break;
      case 3:
         smartphoneService.AddNewSmartphone();
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