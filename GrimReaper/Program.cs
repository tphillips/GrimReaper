using System;
// Test
namespace GrimReaper
{
	static class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			string Directory = "";
			int MaxAge = -1;
			string Pattern = "";
			Console.WriteLine("GrimReaper v0.1 - Tristan Phillips");
			for (int x = 0; x < args.Length; x++)
			{
				if (args[x] == "-p") { Pattern = args[x + 1]; }
				if (args[x] == "-d") { Directory = args[x + 1]; }
				if (args[x] == "-a") { MaxAge = int.Parse(args[x + 1]); }
			}
			if (Directory == "" || MaxAge == -1 || Pattern == "")
			{
				Console.WriteLine("usage: GrimReaper -d directory -p pattern -a max age (hours)");
				return;
			}
			Console.WriteLine("Scanning folder \n\t" + Directory + "\nwith a pattern of " + 
				Pattern + " for files older than " + MaxAge + " hours(s)");
			string[] Marked = System.IO.Directory.GetFiles(Directory, Pattern);
			foreach (string file in Marked)
			{
				if (new System.IO.FileInfo(file).CreationTime < DateTime.Now.AddHours(MaxAge * -1))
				{
					Console.WriteLine(file);
					System.IO.File.Delete(file);
				}
			}
		}
	}
}