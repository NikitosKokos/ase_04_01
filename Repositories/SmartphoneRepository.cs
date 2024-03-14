public class SmartphoneRepository
{
   public List<Smartphone> GetSmartphones(){
      List<Smartphone> smartphones = new List<Smartphone>();
      string[] lines = File.ReadAllLines("../Files/smartphones.csv");

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

      return smartphones;
   }

   public Smartphone GetSmartphoneById(int sartphoneId){
      Smartphone smartphone = new Smartphone();
      string[] lines = File.ReadAllLines("../Files/smartphones.csv");

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
      using (FileStream fs = new FileStream("./Files/smartphones.csv", FileMode.Append, FileAccess.Write))
      {
         using (StreamWriter sw = new StreamWriter(fs))
         {
            sw.WriteLine("12,Samsung,Galaxy S21,2021,999,Android");
         }
      }
   }
}