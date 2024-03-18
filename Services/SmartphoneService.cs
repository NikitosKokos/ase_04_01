public interface ISmartphoneService{
   List<Smartphone> ListAllSmartphones();
   List<Smartphone> SearchSmartphones(string value);
   bool AddNewSmartphone(Smartphone newSmartphone);
}

public class SmartphoneService : ISmartphoneService
{
   private ISmartphoneRepository _smartphoneRepository;

   public SmartphoneService(ISmartphoneRepository smartphoneRepository){
      _smartphoneRepository = smartphoneRepository;
   }
   public List<Smartphone> ListAllSmartphones(){
      return _smartphoneRepository.GetSmartphones();
   }

   public List<Smartphone> SearchSmartphones(string value){
      return _smartphoneRepository.SearchSmartphones(value);
   }

   public bool AddNewSmartphone(Smartphone newSmartphone){
      return _smartphoneRepository.AddSmartphone(newSmartphone);
   }
}