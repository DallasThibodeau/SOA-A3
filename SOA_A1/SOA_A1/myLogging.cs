using System;
using System.IO;

namespace SOA_A1
{
    public static class myLogging
    {
        public static string Write(string outputFile, string text)
        {
            string returnMessage = "";

            try
            {
                StreamWriter file = new StreamWriter(outputFile, true);
                string currentTime = DateTime.Now.ToString();

                file.WriteLine(currentTime + " " + text);

                file.Close();
            }
            catch(Exception ex)
            {
                returnMessage = "An error occured writting to the file: " + ex.Message;
            }

            return returnMessage;
        }

    }

}