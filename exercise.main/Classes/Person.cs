using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes;

public class Person
{
    private string Uuid { get; set; }
    private string Name {  get; set; }
    private string Role { get; set; }
    private BagelBasket? Basket { get; set; }
    
    public Person(string name, string role = "mop") // I have set the default role to 'mop' aka 'member of the public'.
    {
        Uuid = Guid.NewGuid().ToString();
        this.Name = name;
        this.Role = role.ToLower();
        if (this.Role != "employee" && this.Role != "manager")
        {
            Basket = new BagelBasket();
        }
    }

    public string GetUUID()
    {
        return Uuid;
    }

    public string GetName()
    {
        return Name;
    }

    public string GetRole()
    {
        return Role;
    }

    public BagelBasket? GetBasket()
    {
        return Basket;
    }

    public void ChangeRole(string role)
    {
        this.Role = role;
    }
}
