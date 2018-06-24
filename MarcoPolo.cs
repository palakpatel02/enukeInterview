using System;
					
public class Program
{
	public static void Main()
	{
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
	}
}
