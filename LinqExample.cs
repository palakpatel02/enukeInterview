using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public void Main()
	{
		
		List<Employee> empList = getEmployees();
		Console.WriteLine("Sorted alphabetically: ");
		Console.WriteLine(string.Join(",", empList.OrderBy(s => s.Name).Select(x=>x.Name)));
		
		Console.WriteLine("\nOnly 2 employees whose designation is Techie: ");
		Console.WriteLine(string.Join(",", empList.Where(x=>x.Designation.Equals("Techie")).Take(2)));
		
		Console.WriteLine("\nEmployees whose birth is after 1985: ");
		Console.WriteLine(string.Join(",", empList.Where(x=>x.DOB.Year > 1985).Select(x=>x.Name)));
		
	}
	
	private List<Employee> getEmployees()
	{
		List<Employee> empList = new List<Employee>();
		empList.Add(new Employee(){ UserID = "111", Name = "Chirag", DOB = new DateTime(1988,1,1), Designation = "Techie", Gender = 'M'});
		empList.Add(new Employee(){ UserID = "112", Name = "Aman", DOB = new DateTime(1980,3,10), Designation = "Techie", Gender = 'M'});
		empList.Add(new Employee(){ UserID = "113", Name = "Niki", DOB = new DateTime(1990,11,11), Designation = "HR", Gender = 'F'});
		empList.Add(new Employee(){ UserID = "114", Name = "Sapan", DOB = new DateTime(1984,5,8), Designation = "Techie", Gender = 'M'});
		empList.Add(new Employee(){ UserID = "115", Name = "Pratik", DOB = new DateTime(1979,2,9), Designation = "CTO", Gender = 'M'});
		return empList;
	}
}

public class Employee
{
	public string UserID;
	public string Name;
	public DateTime DOB;
	public string Designation;
	public char Gender; 
	
}
