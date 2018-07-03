using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {

    [HttpGet("/items")]
    public ActionResult Index()
    {
      Item newItem = new Item(Request.Query["new-item"]);
      newItem.Save();
      List<Item> allItems = Item.GetAll();
      return View(allItems);
    }

    [HttpGet("/list")]
    public ActionResult ShowList()
    {
      List<Item> allItems = Item.GetAll();
      return View("Index", allItems);
    }

    [HttpGet("/new")]
    public ActionResult CreateForm()
    {
      return View();
    }


  }
}
