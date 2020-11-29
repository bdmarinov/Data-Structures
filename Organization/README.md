Organization

You need to implement a structure that will be used by organizations to track their employees. You need to support the following operations (and they should be fast):
+	Add() – Add an employee to the organization. You will need to implement the Contains() method as well.
+	Contains(Person) – Checks if an employee is present in the organization
+	ContainsByName(string) – Checks if an employee with the given name exists in the organization
+	Count – Returns the number of employees in the organization
+	GetAtIndex(int) – Return the N-th employee that started working in the organization. The index is based on insertion in the organization structure. If such index is not present, throw IndexOutOfRangeException
+	GetByName(string) – Returns all employees with the given name
+	FirstByInsertOrder(int) – Returns the first N-th employees that started working in the organization. In java, there should be override without parameter that returns the first element only
+	GetWithNameSize(int) – Returns all employees with the given name length. If there are no such employees, throw new ArgumentException
+	SearchWithNameSize(int, int) – Returns all employees that have name lengths between the 2 parameters
+	PeopleByInsertOrder() – Returns all employees by the order of which they started working in the organization

Duplicates of the person class are allowed. That means that the names and salaries of multiple objects might be the same.
