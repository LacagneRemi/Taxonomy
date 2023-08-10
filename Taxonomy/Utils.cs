using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxonomy
{
    public static class Utils
    {
        /// <summary>
        /// Add an employee to the specified list
        /// </summary>
        /// <param name="employeesList">The list wich will receive the employee to add</param>
        /// <param name="employee">The employee to add</param>
        public static void AddEmployee(ref List<Employee> employeesList, Employee employee)
        {
            employeesList.Add(employee);
        }

        /// <summary>
        /// Get the list of all subordinates employees of the specified employee
        /// </summary>
        /// <param name="employeesList">The list to retrieve the subordinates of the specified employee</param>
        /// <param name="employee">The employee to get the subordinates list</param>
        /// <returns></returns>
        public static List<Employee> GetAllSubordinatesOf(List<Employee> employeesList, Employee employee)
        {
            return employeesList.Where(emp => emp.Supervisor == employee).ToList();
        }

        /// <summary>
        /// Change the supervisor of the specified employee
        /// </summary>
        /// <param name="employeesList">The list which contains all employees</param>
        /// <param name="employeeToChange">The employee who receive the new supervisor</param>
        /// <param name="newSupervisor">The new supervisor to set</param>
        public static void ChangeEmployeeSupervisorOf(List<Employee> employeesList, ref Employee employeeToChange, ref Employee newSupervisor)
        {
            int hierarchicalRank = employeeToChange.HierarchicalRank;
            if (employeesList.Where(emp => emp.HierarchicalRank == hierarchicalRank).Count() < 2) //if nobody hasn't the same hierarchical range
                newSupervisor.HierarchicalRank = employeeToChange.HierarchicalRank;
            newSupervisor.Supervisor = employeeToChange.Supervisor;
            employeeToChange.Supervisor = newSupervisor;
        }
    }
}
