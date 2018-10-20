using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCsharp.ViewModels
{
    public class Persons
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Addres { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }

        public List<Persons> GetListpersons()
        {
           
            return new List<Persons>
            {
                    new Persons{ID=1,Name="Ahmeed",Addres="Idacada",Phone="3432423",Date=DateTime.Now},
                    new Persons{ID=1,Name="Ismacil",Addres="fdf",Phone="453445",Date=DateTime.Now},
                    new Persons{ID=1,Name="Abdi",Addres="f",Phone="35345",Date=DateTime.Now},
                    new Persons{ID=1,Name="Ahmeed",Addres="Idacada",Phone="3432423",Date=DateTime.Now},
                    new Persons{ID=1,Name="Ahmeed",Addres="Idacada",Phone="3432423",Date=DateTime.Now},

            };
        }
    }
}