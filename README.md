[1. The Marco Polo Game](#)

[2. A Simple Question about .NET](#)

[3. A Merge alogorithm](#)

[4. Implementing a User Story](#)

# 1) Marco Polo Instructions
```
int start = 1, end = 100;
string result = string.Empty;
for (int i = start; i <= end; i++)
{
	if (i % 4 == 0 && i%7 == 0)
		result += "marcopolo,";
	else if (i % 4 == 0)
		result += "marco,";
	else if (i % 7 == 0)
		result += "polo,";
	else
		result += i + ",";
}
Console.WriteLine(result);
```
Live working code: [https://dotnetfiddle.net/RP0o68](https://dotnetfiddle.net/RP0o68)

# 2) When should you use LINQ in your program? 

To operate on collection of data, we can use Linq. 
To find a particular object in the list, we have to use a `foreach` or a `for` loop to traverse the collection to find a particular object. But using linq, it becomes easy to find one.

### Benefits
* Less coding
* Readable code
* IntelliSense Support
* Type checking in Compile time

Please find below example that uses Linq.

```	
List<Employee> empList = getEmployees();
Console.WriteLine("Sorted alphabetically: ");
Console.WriteLine(string.Join(",", empList.OrderBy(s => s.Name).Select(x=>x.Name)));

Console.WriteLine("\nOnly 2 employees whose designation is Techie: ");
Console.WriteLine(string.Join(",", empList.Where(x=>x.Designation.Equals("Techie")).Take(2)));

Console.WriteLine("\nEmployees whose birth is after 1985: ");
Console.WriteLine(string.Join(",", empList.Where(x=>x.DOB.Year > 1985).Select(x=>x.Name)));
		
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
```
Live working code: [https://dotnetfiddle.net/BqzYZF](https://dotnetfiddle.net/BqzYZF)

# 3) A Merge alogorithm
```
int[] a1 = {2,4};
int[] a2 = {1,3,5,7};
int[] result = new int[a1.Length+a2.Length];

int i = 0, j = 0, k = 0;
while (i<a1.Length && j <a2.Length)
{
	if (a1[i] < a2[j])
	{
		result[k++] = a1[i++];
	}
	else
	{
		result[k++] = a2[j++];
	}
}

while (i < a1.Length)
{
	result[k++] = a1[i++];
}
while (j < a2.Length)
{
	result[k++] = a2[j++];
}
```
Live working code: [https://dotnetfiddle.net/MHbnsJ](https://dotnetfiddle.net/MHbnsJ)

# 4) Implementing a User Story (digitise invoice)
```
private static void digitize(string url)
{
	string fileContent = getFileContent(url);
	string[] lines = fileContent.Split('\n');
	
	if (!validateFile(lines))
		return;
	
	for (int line = 0; line < lines.Length; line = line + 4)
	{
		string line1 = lines[line];
		string line2 = lines[line+1];
		string line3 = lines[line+2];
		int noofdigits = line1.Length / 3;
		string invoiceNumber = string.Empty;
		for (int n=0; n<noofdigits; n++)
		{
			if (n < 9)
			{
				invoiceNumber += getNumber(n, line1, line2, line3);
			}
		}
		
		invoiceNumber = (invoiceNumber.IndexOf('?') > -1) ? invoiceNumber + " ILLEGAL" : invoiceNumber;
		Console.WriteLine(invoiceNumber);
	}
}

private static string getFileContent(string url)
{
	/*
	read file content from local storage or from hosted file and return it
	*/
}

private static string getNumber(int index, string line1, string line2, string line3)
{
	int startIndex = (3 * index);
	string numberString = line1.Substring(startIndex, 3) + line2.Substring(startIndex, 3) + line3.Substring(startIndex, 3);
	numberString = numberString.Replace(" ", ".");
	return identifyNumber(numberString);
}

private static string identifyNumber(string number)
{
	for (int i = 0; i < numbers.Length; i++)
	{
		if (number.Equals(numbers[i]))
			return i.ToString();
	}
	return "?";
}
```
Live working code: [https://dotnetfiddle.net/fKQNNm](https://dotnetfiddle.net/fKQNNm)
