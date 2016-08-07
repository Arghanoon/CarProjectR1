using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Bussiness.MyException;
using System.IO;
using MyUtility;

namespace MyDatabase
{
    public partial class MyDbContext : DbContext
    {
        static string _connectionString;
        static MyDbContext _db;

        public static string ConnectionString
        {
            get
            {
                if (_connectionString != null) return _connectionString;



                if (File.Exists(Bussiness.Setting.Settings.ConnectionStringFilePath))
                {
                    _connectionString = MyUtility.String.Decript(File.ReadAllText(Bussiness.Setting.Settings.ConnectionStringFilePath));

                    return _connectionString;
                }

                throw new ConfigFileNotFoundException("Config File Not Found!");

            }
        }

        public static MyDbContext db
        {
            get
            {
                if (_db == null) _db = new MyDbContext(ConnectionString);

                return _db;
            }
        }


    }
    public partial class User
    {
      //  public static User CheckLogin(string username, string password)
        //{

           // return MyDbContext.db.User.FirstOrDefault(x => x.LoginName == username && x.LoginPass == password);
          //  return MyDbContext.db.Security_User.FirstOrDefault(x => x.Username == username && x.Password == password);
        //}
    }
    //public partial class Shop_DefineGoods
    //{
    //    public static Shop_DefineGoods GetByBarcode(string input)
    //    {
    //        int barcode = input.ToInt();

    //        return MyDbContext.db.Shop_DefineGoods.FirstOrDefault(x => x.Barcode == barcode);
    //    }
    //}
}
