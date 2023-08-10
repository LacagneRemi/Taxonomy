using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxonomy
{
    public abstract class Employee
    {
        private int _id;
        private string _name;
        private Employee _supervisor;
        private int _hierarchicalRank;
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public Employee Supervisor
        {
            get => _supervisor;
            set
            { _supervisor = value; _hierarchicalRank = _supervisor != null ? _supervisor._hierarchicalRank + 1 : 0; }
        }
        public int HierarchicalRank { get => _hierarchicalRank; set => _hierarchicalRank = value; }

        public Employee(int id, string name, Employee supervisor, int hierarchicalRank)
        {
            Id = id;
            Name = name;
            Supervisor = supervisor;
            HierarchicalRank = hierarchicalRank;
        }


    }
}
