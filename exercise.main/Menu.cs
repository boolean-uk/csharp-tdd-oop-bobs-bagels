using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Menu
    {
        public List<string> menuList = new List<string>();

        public Menu() 
        {
            menuList.Add("BGLO, 0.49d, Bagel, Onion");
            menuList.Add("BGLp, 0.39d, Bagel, PLain");
            menuList.Add("BGLE, 0.49d, Bagel, Everything");
            menuList.Add("BGLS, 0.99d, Bagel, Sesame");
            menuList.Add("COFB, 0.99d, Coffee, Black");
            menuList.Add("COFW, 1.19d, Coffee, White");
            menuList.Add("COFC, 1.29d, Coffee, Cappuccino");
            menuList.Add("COFL, 1.29d, Coffee, Latte");
            menuList.Add("FILB, 0.12d, Filling, Bacon");
            menuList.Add("FILE, 0.12d, Filling, Egg");
            menuList.Add("FILC, 0.12d, Filling, Cheese");
            menuList.Add("FILX, 0.12d, Filling, Cream Cheese");
            menuList.Add("FILS, 0.12d, Filling, Smoked Salmon");
            menuList.Add("FILH, 0.12d, Filling, Ham");
        }

        public string showMenu() 
        {
            StringBuilder sb = new StringBuilder();
            foreach (string item in menuList)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }

        

    }
}
