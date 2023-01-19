namespace CretaceousClient.Models;

//New class to hold the paging information and a list of animals
public class AnimalPage
{
  public List<Animal> Animals { get; set; }
  public Paging Pagings { get; set; }
}
    
