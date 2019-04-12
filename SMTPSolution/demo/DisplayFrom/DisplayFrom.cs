using System;
using SmtPop;

namespace DisplayFrom
{
	/// <summary>
	/// Description r�sum�e de Class1.
	/// </summary>
	class DisplayFrom
	{
		/// <summary>
		/// Point d'entr�e principal de l'application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			if (args.Length != 1)
			{
				string exe = System.Reflection.Assembly.GetExecutingAssembly ().GetName ().Name;
				
				Console.Out.WriteLine ("{0} <file filter>", exe);
				Console.Out.WriteLine ();
				Console.Out.WriteLine ("ex:");
				
				Console.Out.WriteLine ("{0} *.eml", exe);
				
				Console.Out.WriteLine ("{0} test*.eml", exe);
				
				Console.Out.WriteLine ("{0} test.eml", exe);

				return;

			}
			
			string path = ".";
			string search = args[0];
			int p;

			if ((p = args[0].LastIndexOf ("\\") ) != -1)
			{
				path = args[0].Substring (0, p);
				search = args[0].Substring (p + 1, args[0].Length - p -1);
			}
			
			
			string[] fnames = System.IO.Directory.GetFiles (path, search);
			foreach (string f in fnames)
			{
				try
				{
					System.IO.StreamReader r = new System.IO.StreamReader (f);
					POPReader pop = new POPReader (r);
					MimeMessage m = new MimeMessage ();
					m.Read (pop);
					//Console.Out.Write (f + " : ");
					if (m.AddressFrom.Count > 0)
						Console.Out.WriteLine (m.AddressFrom[0].Src);
				}
				catch (Exception e)
				{
					Console.Out.WriteLine ("exception occured reading {0}", f);
					Console.Out.WriteLine (e.Message);
				}
			}

		}
	}
}
