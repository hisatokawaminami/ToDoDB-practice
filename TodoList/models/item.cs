using System.Collections.Generic;
using System;
namespace ToDoList.Models
{
  public class Item
  {
    private string _description;
    private static List<Item> _instances = new List<Item> {};

    public Item (string description)
    {
      _description = description;
    }
    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public static List<Item> GetAll()
    {
      return _instances;
    }
    public void Save()
    {
      _instances.Add(this);
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
  }

  public class Program
  {
    public static void Main()
    {
      Console.WriteLine("Welcome to the TO DO LIST");
      Console.WriteLine("Would you like to add an item to your list or view your list?(Add/View)");

      string addView = Console.ReadLine().ToUpper();
      if(addView == "ADD")
      {
        Console.WriteLine("Enter a to-do...");
        Item userItem = new Item(Console.ReadLine());
        userItem.Save();
        Console.WriteLine (userItem.GetDescription() + " has been added to your list");
        Main();
      }
      else
      {
        List<Item> result = Item.GetAll();
        foreach (Item thisItem in result)
        {
          Console.WriteLine(thisItem.GetDescription());
        }
        // Console.WriteLine("Here is yout to-do's: " + result);
        // Console.WriteLine(userItem.GetAll());
      }
    }
  }
}
