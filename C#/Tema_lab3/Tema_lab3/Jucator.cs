using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_lab3
{

    enum Post { Portar, Fundas, Mijlocas, Atacant }
    class Jucator
    {
        string nume;
        string cnp;
        Post post;
        public Jucator() { }
        public Jucator(string nume, string cnp, Post post)
        {
            this.nume = nume;
            this.cnp = cnp;
            this.post = post;
        }
        public string Cnp { get => cnp; set => cnp = value; }   // public string Cnp { get; set; }
        public string Nume { get => nume; set => nume = value; }
        public Post Post { get => post; set => post = value; }
        public DateTime DataNasterii
        {
            get
            {
                int.TryParse(cnp.Substring(1, 2), out int an);
                int.TryParse(cnp.Substring(3, 2), out int luna);
                int.TryParse(cnp.Substring(5, 2), out int zi);
                DateTime dn = new DateTime(2000 + an, luna, zi);  //poate avem probleme
                return dn;
            }
        }
        public int Varsta
        {
            get
            {
                long ticks = DateTime.Now.Ticks - DataNasterii.Ticks;
                DateTime dt = new DateTime(ticks);
                return dt.Year - 1;   //poate mai avem probleme 
            }
        }





    }
}
