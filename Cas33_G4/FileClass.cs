using System;
using System.IO;

namespace Cas33_G4
{
    class FileClass
    {
        static public void Log(string FileName, string LogMessage)
        {
            // Write a log file to the specified location, if file exists, append text to the end
            using (StreamWriter file = new StreamWriter(FileName, true))
            {
                file.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss K"));
                file.WriteLine(LogMessage);
                file.WriteLine("**********");
                file.WriteLine();
            }
        }
    }
}
