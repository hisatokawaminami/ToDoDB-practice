using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;
using ToDoList;

namespace ToDoList.Models
{
  public class Item
  {
    private string _description;
    private int _id;
    // private static List<Item> _instances = new List<Item> {};
    // private static int _lastIdAssigned = 0;

    // public Item (string description)
    // {
    //   // _description = description;
    //   // _instances.Add(this);
    //   // _lastIdAssigned++;
    //   // _id = _lastIdAssigned;
    // }
    public Item(string Description, int Id = 0)
    {
      _id = Id;
      _description = Description;
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

    // public static List<Item> GetAll()
    // {
    //   return _instances;
    // }

    public static List<Item> GetAll()
    {
      List<Item> allItems = new List<Item> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * From items;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string itemDescription = rdr.GetString(1);
        Item newItem = new Item(itemDescription, itemId);
        allItems.Add(newItem);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allItems;
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
