using System.Collections.Generic;
using System;

namespace ToDoList.Models
{
  public class Item
  {
    private string _description;
    private int _id;
    private static List<Item> _instances = new List<Item> {};
    private static int _lastIdAssigned = 0;

    public Item (string description)
    {
      _description = description;
      _instances.Add(this);
      _lastIdAssigned++;
      _id = _lastIdAssigned;
    }
    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Item> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Item Find(int searchId)
    {
      foreach(Item thisItem in _instances)
      {
        if(thisItem.GetId() == searchId)
        {
          return thisItem;
        }
      }
      return null;
    }
  }
}
