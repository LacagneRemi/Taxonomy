using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxonomy;

namespace Taxonomy
{
    public class Developer : Employee
    {
        private string _programmingLanguage;
        public string ProgrammingLanguage { get => _programmingLanguage; set => _programmingLanguage = value; }
        public Developer(int id, string name, Employee supervisor, int hierarchicalRank, string programmingLanguage) : base(id, name, supervisor, hierarchicalRank)
        {
            _programmingLanguage = programmingLanguage;
        }

    }
}
