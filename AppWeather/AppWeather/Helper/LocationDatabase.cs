using AppWeather.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AppWeather.Helper
{
    public class LocationDatabase
    {
        private readonly SQLiteConnection db;
        public LocationDatabase()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            db = new SQLiteConnection(System.IO.Path.Combine(folder, "LocationDatabase.db3"));
            db.CreateTable<Location>();
        }
        public bool CreateLocation(Location location)
        {
            try
            {
                db.Insert(location);
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return false;
                throw;
            }
        }

        public List<Location> ReadLocation()
        {
            try
            {
                return db.Table<Location>().ToList();
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return null;
                throw;
            }
        }

        public bool UpdateLocation(Location location)
        {
            try
            {
                db.Update(location);
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return false;
                throw;
            }
        }

        public bool DeleteLocation(Location location)
        {
            try
            {
                db.Delete(location);
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("Exception: " + ex);
                return false;
                throw;
            }
        }
    }
}
