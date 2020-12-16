using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FrontEndApp.Models
{
  public class Users
  {
    public List<User> userDummies = new List<User>();
    //one line code instance in client 
    //"List<User> DummieList = new UserDummies().GetUserDummies();"
    public List<User> GetUserDummies()
    {
      //----------- > Female Dummies
      User DummieUser01 = new User()
      {
        Name = "Birgitte",
        Password = "1234"
      };
      User DummieUser02 = new User()
      {
        Name = "Charlotte",
        Password = "char1234"
      };
      User DummieUser03 = new User()
      {
        Name = "Freja",
        Password = "password"
      };

      userDummies.Add(DummieUser01);
      userDummies.Add(DummieUser02);
      userDummies.Add(DummieUser03);

      return userDummies;
    }
  }
}