using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABHamburguesa_v2.ABModels;
using SQLite;

namespace ABHamburguesa_v2.ABData
{
    public class ABBurguerDataBase
    {
        string _dbPath;
        private SQLiteConnection conn;

        public ABBurguerDataBase(string DatabasePath)
        {
            _dbPath = DatabasePath;
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<ABBurguer>();
        }

        public int AddNewBurguer(ABBurguer burguer)
        {
            Init();
            int result = conn.Insert(burguer);
            return result;
        }

        

        public List<ABBurguer> GetAllBurguers()
        {
            Init();
            List<ABBurguer> burguers = conn.Table<ABBurguer>().ToList();
            return burguers;
        }

        public ABBurguer GetBurguer(int id)
        {
            ABBurguer ham = new ABBurguer();
            Init();
            List<ABBurguer> burguers = conn.Table<ABBurguer>().ToList();
            foreach (ABBurguer hame in burguers) 
            {
                if (hame.ID == id)
                    ham = hame;
            }
            return ham;
        }
    }
}
