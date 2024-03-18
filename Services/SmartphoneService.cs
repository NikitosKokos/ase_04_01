public class SmartphoneService
{
   private SmartphoneRepository _r = new SmartphoneRepository();
   public List<Smartphone> ListAllSmartphones(){
      List<Smartphone> listSmartphones = _r.GetSmartphones();

      return listSmartphones;
      // Console.Clear();
      // SmartphoneRepository r = new SmartphoneRepository();
      // List<Smartphone> listSmartphones = r.GetSmartphones();

      // if(listSmartphones.Count == 0){
      //    Console.WriteLine("No smartphones available");
      // }else{
      //    foreach(Smartphone smartphone in listSmartphones){
      //       Console.WriteLine(smartphone);
      //    }
      // }

      // Console.WriteLine("Press Enter to go to the main menu");
      // ConsoleKeyInfo key = Console.ReadKey(true);

      // switch (key.Key)
      // {
      //    case ConsoleKey.Enter:
      //       break;
      // }
   }

   public List<Smartphone> SearchSmartphones(string value){
      List<Smartphone> listSmartphones = _r.GetSmartphones();
      List<Smartphone> searchedSmartphones = new List<Smartphone>();

      foreach(Smartphone item in listSmartphones){
         if(item.Brand.ToLower().Contains(value.ToLower()) || item.Type.ToLower().Contains(value.ToLower())){
            searchedSmartphones.Add(item);
         }
      }
      return searchedSmartphones;
      // Console.Clear();
      // Console.WriteLine("Search For Smartphones");
      // Console.WriteLine("Enter brand or type:");
      // string value = Console.ReadLine();

      // SmartphoneRepository r = new SmartphoneRepository();
      // List<Smartphone> listSmartphones = _r.GetSmartphones();
      // List<Smartphone> searchedSmartphones = new List<Smartphone>();

      // foreach(Smartphone item in listSmartphones){
      //    if(item.Brand.ToLower().Contains(value.ToLower()) || item.Type.ToLower().Contains(value.ToLower())){
      //       searchedSmartphones.Add(item);
      //    }
      // }
      // if(searchedSmartphones.Count == 0){
      //    Console.WriteLine("No matching smartphones found :(");
      // }else{
      //    foreach(Smartphone smartphone in searchedSmartphones){
      //       Console.WriteLine(smartphone);
      //    }
      // }

      // Console.WriteLine("Press Enter to go to the main menu");
      // ConsoleKeyInfo key = Console.ReadKey(true);

      // switch (key.Key)
      // {
      //    case ConsoleKey.Enter:
      //       break;
      // }
   }

   public bool AddNewSmartphone(Smartphone newSmartphone){
      bool isSuccessful = _r.AddSmartphone(newSmartphone);

      return isSuccessful;
   }
}