using System;
					
public class Program
{
	public static void Main()
	{
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
        

		foreach(var item in result)
		{
			Console.WriteLine(item.ToString());
		}
	}
}
