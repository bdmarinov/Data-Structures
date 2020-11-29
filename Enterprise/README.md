Enterprise

You need to implement a structure that will be used by enterprise organizations. You are given an Employee class, which has the following properties:
+	Guid Id – unique id for each employee. In Java, it's called UUID
+	DateTime HireDate – date that we will use for our queries later
+	Position Position – enumeration of work positions for the employee
+	string FirstName – first name of the employee
+	string LastName – last name of the employee
+	double Salary – the salary of the employee

You need to support the following operations (and they should be fast):
+	Add() – Add an employee to the organization. You will need to implement the Contains() methods as well.
+	Contains(Employee) – checks if an employee is present in the organization
+	Contains(Guid) – checks if an employee with the given Guid exists in the organization
+	Count – returns the number of employees in the organization
+	Change(Guid, Employee) – find the employee with the given Guid and modify its data. Returns true if the operation is successful
+	Fire(Guid) – remove the employee from the organization. Returns true if the operation is successful
+	RaiseSalary(int, int) – raise the salary of all employees which are working in the organization for at least that many months, with the given percentage. Returns true if the operation modified at least one employee
+	GetByGuid(Guid) – return the employee with the given Guid. If such employee doesn't exist, throw ArgumentException.
+	PositionByGuid(Guid) – return the employee position with the given Guid. If such employee doesn't exist, throw InvalidOperationException.
+	GetByPosition(Position) – returns all employees with the given position
+	GetBySalary(double) – returns all employees with salary higher or equal to the given salary. Throw InvalidOperationException if there are no employees with matching the search.
+	GetBySalaryAndPosition(double, Position) – returns all employees with the given salary and position. Throws InvalidOperationException if there are no employees with the given data. 
+	SearchBySalary(double, double) – search for all employees with a salary in a range. If there are no such employees, return empty collection
+	SearchByPosition(IEnumerable<Position>) – returns all employees with the given positions or empty collection. Returns empty collection if there are no such elements
+	SearchByFirstName(string) – returns all employees with the given first name
+	SearchByNameAndPosition(string, string, Position) – returns all employees with the given first and last names, and with the given position. Returns empty collection if there are no such elements
+	AllWithPositionAndMinSalary(Position, double) – returns all employees with the given position and minimal salary. Returns empty collection if there are no such elements
