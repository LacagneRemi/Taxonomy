using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxonomy;

namespace Taxonomy
{
    public class Manager : Employee
    {
        private string _departement;
        public string Departement { get => _departement; set => _departement = value; }
        public Manager(int id, string name, Employee supervisor, int hierarchicalRank, string departement) : base(id, name, supervisor, hierarchicalRank)
        {
            Departement = departement;
        }
    }
}
