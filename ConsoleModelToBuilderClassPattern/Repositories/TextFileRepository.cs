using System;
using System.IO;

namespace ConsoleModelToBuilderClassPattern.Repositories
{
    public class TextFileRepository
    {
        public static void OutputToTxtFile(string txtString)
        {
            using (var file = new StreamWriter("Output.txt"))
            {
                file.WriteLine(txtString);
                file.WriteLine(Environment.NewLine);
                file.Close();
            }
        }
    }
}