using System;
using System.Collections;
using System.Collections.Generic;

public class Enterprise : IEnterprise
{
    private Dictionary<Guid, Employee> employeesById;

    public int Count
    {
        get;
        private set;
    }

    public Enterprise()
    {
        employeesById = new Dictionary<Guid, Employee>();
        Count = 0;
    }
    public void Add(Employee employee)
    {
        if(employeesById.ContainsKey(employee.Id))
        {
            throw new ArgumentException();
        }
        employeesById.Add(employee.Id, employee);
        Count++;
    }

    public IEnumerable<Employee> AllWithPositionAndMinSalary(Position position, double minSalary)
    {
        LinkedList<Employee> employees = new LinkedList<Employee>();
        
        foreach(var employee in employeesById)
        {
            if(employee.Value.Position == position && employee.Value.Salary >= minSalary)
            {
                employees.AddLast(employee.Value);
            }
        }
        return employees;
    }

    public bool Change(Guid guid, Employee employee)
    {
        if(employeesById.ContainsKey(guid))
        {
            employeesById[guid] = employee;
            return true;
        }
        return false;
    }

    public bool Contains(Guid guid)
    {
        return (employeesById.ContainsKey(guid));
    }

    public bool Contains(Employee employee)
    {
        return (employeesById.ContainsKey(employee.Id));
    }

    public bool Fire(Guid guid)
    {
        if(employeesById.ContainsKey(guid))
        {
            employeesById.Remove(guid);
            Count--;
            return true;
        }
        return false;
    }

    public Employee GetByGuid(Guid guid)
    {
        if(!employeesById.ContainsKey(guid))
        {
            throw new ArgumentException();
        }
        return employeesById[guid];
    }

    public IEnumerable<Employee> GetByPosition(Position position)
    {
        LinkedList<Employee> employees = new LinkedList<Employee>();

        foreach(var employee in employeesById)
        {
            if(employee.Value.Position == position)
            {
                employees.AddLast(employee.Value);
            }
        }
        return employees;
    }

    public IEnumerable<Employee> GetBySalary(double minSalary)
    {
        LinkedList<Employee> employees = new LinkedList<Employee>();

        foreach(var employee in employeesById)
        {
            if(employee.Value.Salary >= minSalary)
            {
                employees.AddLast(employee.Value);
            }
        }
        if (employees.Count == 0)
        {
            throw new InvalidOperationException();
        }
        return employees;
    }

    public IEnumerable<Employee> GetBySalaryAndPosition(double salary, Position position)
    {
        LinkedList<Employee> employees = new LinkedList<Employee>();

        foreach(var employee in employeesById)
        {
            if(employee.Value.Salary == salary && employee.Value.Position == position)
            {
                employees.AddLast(employee.Value);
            }
        }
        if(employees.Count == 0)
        {
            throw new InvalidOperationException();
        }
        return employees;
    }

    public IEnumerator<Employee> GetEnumerator()
    {
        foreach(var employee in employeesById)
        {
            yield return employee.Value;
        }
    }

    public Position PositionByGuid(Guid guid)
    {
        if(!employeesById.ContainsKey(guid))
        {
            throw new InvalidOperationException();
        }
        return employeesById[guid].Position;
    }

    public bool RaiseSalary(int months, int percent)
    {
        DateTime curDate = DateTime.Now;
        bool flag = false;

        foreach(var employee in employeesById)
        {
            DateTime empDate = employee.Value.HireDate;
            int diffMonths = (curDate.Year - empDate.Year) * 12 + (curDate.Month - empDate.Month);

            if(diffMonths >= months)
            {
                employee.Value.Salary = employee.Value.Salary + ((double)(percent) / 100 )* (employee.Value.Salary);
                flag = true;
            }
        }
        return flag;
    }

    public IEnumerable<Employee> SearchByFirstName(string firstName)
    {
        LinkedList<Employee> employees = new LinkedList<Employee>();

        foreach(var employee in employeesById)
        {
            if(employee.Value.FirstName == firstName)
            {
                employees.AddLast(employee.Value);
            }
        }
        return employees;
    }

    public IEnumerable<Employee> SearchByNameAndPosition(string firstName, string lastName, Position position)
    {
        LinkedList<Employee> employees = new LinkedList<Employee>();

        foreach(var employee in employeesById)
        {
            if(employee.Value.FirstName == firstName && employee.Value.LastName == lastName && employee.Value.Position == position)
            {
                employees.AddLast(employee.Value);
            }
        }
        return employees;
    }

    public IEnumerable<Employee> SearchByPosition(IEnumerable<Position> positions)
    {
        HashSet<Position> Positions = new HashSet<Position>(positions);

        LinkedList<Employee> employees = new LinkedList<Employee>();

        foreach(var employee in employeesById)
        {
            if(Positions.Contains(employee.Value.Position))
            {
                employees.AddLast(employee.Value);
            }
        }
        return employees;
    }

    public IEnumerable<Employee> SearchBySalary(double minSalary, double maxSalary)
    {
        LinkedList<Employee> employees = new LinkedList<Employee>();
        
        foreach(var employee in employeesById)
        {
            if(employee.Value.Salary >= minSalary && employee.Value.Salary <= maxSalary)
            {
                employees.AddLast(employee.Value);
            }
        }
        return employees;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

