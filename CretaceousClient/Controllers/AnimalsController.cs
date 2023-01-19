using Microsoft.AspNetCore.Mvc;
using CretaceousClient.Models;

namespace CretaceousClient.Controllers;

public class AnimalsController : Controller
{
  public IActionResult Index()
  {
    AnimalPage animals = Animal.GetAnimals(); //AnimalPage view model was created to hold the list of animals and the paging information
    return View(animals);
  }

  public IActionResult Details(int id)
  {
    Animal animal = Animal.GetDetails(id);
    return View(animal);
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Animal animal)
  {
    Animal.Post(animal);
    return RedirectToAction("Index");
  }

  public ActionResult Edit(int id)
  {
    Animal animal = Animal.GetDetails(id);
    return View(animal);
  }

  [HttpPost]
  public ActionResult Edit(Animal animal)
  {
    Animal.Put(animal);
    return RedirectToAction("Details", new { id = animal.AnimalId});
  }

  public ActionResult Delete(int id)
  {
    Animal animal = Animal.GetDetails(id);
    return View(animal);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Animal.Delete(id);
    return RedirectToAction("Index");
  }

  

  
}