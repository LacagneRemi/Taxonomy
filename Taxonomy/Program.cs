using System;
using System.Collections.Generic;
using System.Linq;

namespace Taxonomy
{
    public class Program
    {
        private static List<Employee> _employeesList = new List<Employee>();
        static void Main(string[] args)
        {
            Employee theBoss = new Manager(0, "Boss", null, 0, "Commercial");
            Employee manager = new Manager(1, "Odin", theBoss, theBoss.HierarchicalRank + 1, "Developpement");
            Employee developper1 = new Developer(2, "Valentin", manager, manager.HierarchicalRank + 1, "C#");
            Employee developper2 = new Developer(3, "Rémi", manager, manager.HierarchicalRank + 1, "C#");

            Utils.AddEmployee(ref _employeesList, theBoss);
            Utils.AddEmployee(ref _employeesList, manager);
            Utils.AddEmployee(ref _employeesList, developper1);
            Utils.AddEmployee(ref _employeesList, developper2);

            List<Employee> subordinatesList = Utils.GetAllSubordinatesOf(_employeesList, manager);
            Utils.ChangeEmployeeSupervisorOf(_employeesList, ref manager, ref developper1);
            Console.WriteLine("" + manager.HierarchicalRank);
            Console.WriteLine("" + developper1.HierarchicalRank);
            Console.ReadLine();
        }

        
    }
}
