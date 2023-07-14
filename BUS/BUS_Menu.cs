using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class BUS_Menu
    {
        DAL_Menu dal_menu = new DAL_Menu();
        public DataTable getData()
        {
            return dal_menu.getData();
        }
        public DataTable loadCbb()
        {
            return dal_menu.loadCbb();
        }
       

        public bool add(MonAn me)
        {
            return dal_menu.add(me);
        }
        public bool upd(MonAn me)
        {
            return dal_menu.update(me);
        }
        public bool del(string ma)
        {
            return dal_menu.delete(ma);
        }
        public DataTable find(string fi, int c)
        {
            return dal_menu.find(fi, c);
        }
        public DataTable findwPrice(int a, int b)
        {
            return dal_menu.findwPrice(a, b);
        }
        public DataTable foodStatistic(int c, string a, string b)
        {
            return dal_menu.FoodStatistic1(c, a, b);
        }
        public DataTable foodStatistic2(int c)
        {
            return dal_menu.FoodStatistic2(c);
        }
    }
}
