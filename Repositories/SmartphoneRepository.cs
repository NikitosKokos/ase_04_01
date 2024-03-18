public interface ISmartphoneRepository{
   List<Smartphone> GetSmartphones();
   Smartphone GetSmartphoneById(int sartphoneId);
   bool AddSmartphone(Smartphone smartphone);
   List<Smartphone> SearchSmartphones(string value);
}

public class SmartphoneRepository : ISmartphoneRepository
{
   private string _path = "./Files/smartphones.csv";

   private Smartphone ParseLine(string line){
      var cols = line.Split(',');
      Smartphone smartphone = new Smartphone();
      smartphone.Id = int.Parse(cols[0]);
      smartphone.Brand = cols[1];
      smartphone.Type = cols[2];
      smartphone.ReleaseYear = int.Parse(cols[3]);
      smartphone.StartPrice = int.Parse(cols[4]);
      smartphone.OperatingSystem = cols[5];

      return smartphone;
   }
   public List<Smartphone> GetSmartphones(){
      List<Smartphone> smartphones = new List<Smartphone>();
      try
      {
         string[] lines = File.ReadAllLines(_path);

         lines = lines.Skip(1).ToArray();
         foreach(var line in lines){
            if(line.Trim().Length == 0){
               continue;
            }
            Smartphone smartphone = ParseLine(line);
            smartphones.Add(smartphone);
         }
      }
      catch (Exception ex)
      {
         Console.WriteLine("Error reading from file: " + ex.Message);
      }
      return smartphones;
   }

   public Smartphone GetSmartphoneById(int sartphoneId){
      Smartphone smartphone = new Smartphone();
      string[] lines = File.ReadAllLines(_path);

      lines = lines.Skip(1).ToArray();
      foreach(var line in lines){
         var cols = line.Split(',');
         // checking the id
         if(int.Parse(cols[0]) == sartphoneId){
            smartphone.Id = int.Parse(cols[0]);
            smartphone.Brand = cols[1];
            smartphone.Type = cols[2];
            smartphone.ReleaseYear = int.Parse(cols[3]);
            smartphone.StartPrice = int.Parse(cols[4]);
            smartphone.OperatingSystem = cols[5];
         }
      }

      return smartphone;
   }

   public bool AddSmartphone(Smartphone smartphone){
      try
      {
         List<Smartphone> existingSmartphones = GetSmartphones();
         int maxId = existingSmartphones.Max(s => s.Id);
         maxId++;
         smartphone.Id = maxId;
         string newLine = $"{smartphone.Id},{smartphone.Brand},{smartphone.Type},{smartphone.ReleaseYear},{smartphone.StartPrice},{smartphone.OperatingSystem}";
         
         // Smartphone smartphoneById = GetSmartphoneById(smartphone.Id);
         
         // if(smartphoneById.Id == smartphone.Id) {
         //    Console.WriteLine("Error: Smartphone with the same ID already exists.");
         //    return false; // Return false indicating error
         // }

         File.AppendAllText(_path, Environment.NewLine + newLine);
         return true;
      }
      catch (Exception ex)
      {
         Console.WriteLine("Error writing to file: " + ex.Message);
         return false;
      }
   }

   public List<Smartphone> SearchSmartphones(string value){
      List<Smartphone> listSmartphones = GetSmartphones();
      List<Smartphone> searchedSmartphones = new List<Smartphone>();

      foreach(Smartphone item in listSmartphones){
         if(item.Brand.ToLower().Contains(value.ToLower()) || item.Type.ToLower().Contains(value.ToLower())){
            searchedSmartphones.Add(item);
         }
      }
      return searchedSmartphones;
   }
}