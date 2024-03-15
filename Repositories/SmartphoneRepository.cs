public class SmartphoneRepository
{
   private string _path = "./Files/smartphones.csv";
   public List<Smartphone> GetSmartphones(){
      List<Smartphone> smartphones = new List<Smartphone>();
      try
      {
         string[] lines = File.ReadAllLines(_path);

         lines = lines.Skip(1).ToArray();
         foreach(var line in lines){
            var cols = line.Split(',');
            Smartphone smartphone = new Smartphone();
            smartphone.Id = int.Parse(cols[0]);
            smartphone.Brand = cols[1];
            smartphone.Type = cols[2];
            smartphone.ReleaseYear = int.Parse(cols[3]);
            smartphone.StartPrice = int.Parse(cols[4]);
            smartphone.OperatingSystem = cols[5];
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

   public void AddSmartphone(Smartphone smartphone){
      try
      {
      string newLine = $"{smartphone.Id},{smartphone.Brand},{smartphone.Type},{smartphone.ReleaseYear},{smartphone.StartPrice},{smartphone.OperatingSystem}";

      File.AppendAllText(_path, Environment.NewLine + newLine);
      }
      catch (Exception ex)
      {
         Console.WriteLine("Error writing to file: " + ex.Message);
      }
   }
}