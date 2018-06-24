using System;
using System.Net;
using System.Text;
using System.IO;

public class Program
{
	private static string[] numbers = {"._.|.||_|", ".....|..|", "._.._||_.", "._.._|._|", "...|_|..|", "._.|_.._|", "._.|_.|_|", "._...|..|", "._.|_||_|", "._.|_|._|"};
	
	public static void Main()
	{
		/*
			A text file containing several hundreds of invoice numbers in the following form:
	
				  _  _     _  _  _  _  _  (line 1)
				| _| _||_||_ |_   ||_||_| (line 2)
				||_  _|  | _||_|  ||_| _| (line 3)
										  (line 4)
				  _  _  _  _  _  _     _  (line 5)
			  |_||_|| ||_||_   |  |  ||_  (line 6)
				| _||_||_||_|  |  |  | _| (line 7)
										  (line 8)
			Invoice number format:
			
			Each invoice number is constructed of 9 digits [0..9]
			Invoice number is written using _ and | characters.
			Invoice number input takes 4 lines.
			The first 3 lines contain 27 characters.
			The fourth line is blank.
		*/

		string invoiceNumbers = "https://gist.githubusercontent.com/palakpatel02/c7fea57faa93743b715c15a6de1573e0/raw/0822d755b00699a32b5459d8a330c283d10fd1ee/digital-invoice-numbers";
		digitize(invoiceNumbers);
		
		Console.WriteLine("\n---------\n");
		
		string invoiceNumbersWithError = "https://gist.githubusercontent.com/palakpatel02/17df0a65428d7fa4ea8fbca51572aaa1/raw/f78abfe8c7407ed36dc8f1994712b9ba5a1a6cdb/digital-invoice-numbers-invalid";
		digitize(invoiceNumbersWithError);
	}
	
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
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		HttpWebResponse response = (HttpWebResponse)request.GetResponse();
		Stream receiveStream = response.GetResponseStream ();
		StreamReader readStream = new StreamReader (receiveStream, Encoding.UTF8);
		string fileContent = readStream.ReadToEnd();
		response.Close();
		return fileContent;
	}
	
	private static bool validateFile(string[] lines)
	{
		if (lines.Length % 4 != 0) {
			Console.WriteLine("invalid file, file should contain lines in multiple of 4");
			return false;
		}
		return true;
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
}
