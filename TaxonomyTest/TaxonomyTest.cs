using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Taxonomy;

namespace TaxonomyTest
{
    [TestClass]
    public class TaxonomyTest
    {
        [TestMethod]
        public void TestAddEmployee()
        {
            List<Employee> employeesList = new List<Employee>();
            Employee theBoss = new Manager(0, "Boss", null, 0, "Commercial");
            Utils.AddEmployee(ref employeesList, theBoss);
            Assert.AreEqual(employeesList.Contains(theBoss), true);
        }

        [TestMethod]
        public void TestGetAllSubordinatesOf()
        {
            List<Employee> employeesList = new List<Employee>();
            Employee manager = new Manager(1, "Odin", null, 0, "Developpement");
            Employee developper1 = new Developer(2, "Valentin", manager, manager.HierarchicalRank + 1, "C#");
            Employee developper2 = new Developer(3, "Rémi", manager, manager.HierarchicalRank + 1, "C#");

            List<Employee> subordinatesEmployeesList = new List<Employee>{ developper1, developper2};

            Utils.AddEmployee(ref employeesList, manager);
            Utils.AddEmployee(ref employeesList, developper1);
            Utils.AddEmployee(ref employeesList, developper2);

            List<Employee> subordinatesList = Utils.GetAllSubordinatesOf(employeesList, manager);
            Assert.AreEqual(subordinatesEmployeesList.SequenceEqual(subordinatesList), true);
        }

        [TestMethod]
        public void TestChangeEmployeeSupervisorOf()
        {
            List<Employee> employeesList = new List<Employee>();
            Employee theBoss = new Manager(0, "Boss", null, 0, "Commercial");
            Employee manager = new Manager(1, "Odin", theBoss, theBoss.HierarchicalRank + 1, "Developpement");
            Employee developper1 = new Developer(2, "Valentin", manager, manager.HierarchicalRank + 1, "C#");
            Employee developper2 = new Developer(3, "Rémi", manager, manager.HierarchicalRank + 1, "C#");

            Utils.AddEmployee(ref employeesList, theBoss);
            Utils.AddEmployee(ref employeesList, manager);
            Utils.AddEmployee(ref employeesList, developper1);
            Utils.AddEmployee(ref employeesList, developper2);

            Employee newSupervisor = new Developer(developper1.Id, developper1.Name, manager.Supervisor, manager.Supervisor.HierarchicalRank + 1, "C#");
            Employee newSubordinate = new Manager(manager.Id, manager.Name, developper1, newSupervisor.HierarchicalRank + 1, "Developpement");

            Utils.ChangeEmployeeSupervisorOf(employeesList, ref manager, ref developper1);
            Assert.AreEqual((developper1.Id.Equals(newSupervisor.Id) && manager.Id.Equals(newSubordinate.Id) &&
                developper1.Supervisor.Id.Equals(newSupervisor.Supervisor.Id) && (manager.Supervisor.Id.Equals(newSubordinate.Supervisor.Id)
                )), true);

        }
    }
}
