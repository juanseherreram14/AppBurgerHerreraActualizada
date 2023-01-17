using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1Burger.Models;

namespace App1Burger.Data
{
    public class BurgerDatabase
    {
        string _dbPath;
        private SQLiteConnection conn;
        public BurgerDatabase(string DatabasePath)
        {
            _dbPath = DatabasePath;
        }
        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Burger>();
        }
        public int AddNewBurger(Burger burger)
        {
            Init();
            int result = conn.Insert(burger);
            return result;
        }
        public List<Burger> GetAllBurgers()
        {
            Init();
            List<Burger> burgers = conn.Table<Burger>().ToList();
            return burgers;
        }

        public void updateBurger(int id, string nuevoNombre, string nuevaDescripcion, bool nuevoExtraQueso)
        {
            Init();
            var burgerNueva = conn.Table<Burger>().Where(r => r.Id == id).FirstOrDefault();
            if (burgerNueva != null)
            {
                burgerNueva.Name = nuevoNombre;
                burgerNueva.Description = nuevaDescripcion;
                burgerNueva.WithExtraCheese = nuevoExtraQueso;
                conn.Update(burgerNueva);
            }
        }
        public Burger GetById(int id)
        {
            Init();
            var burger = from b in conn.Table<Burger>()
                         where b.Id == id
                         select b;

            return burger.FirstOrDefault();
        }
        public void deleteBurger(int id)
        {
            var deletedBurger = conn.Table<Burger>().Where(r => r.Id == id).FirstOrDefault();
            if (deletedBurger != null)
            {
                conn.Delete(deletedBurger);
            }
        }

    }

}