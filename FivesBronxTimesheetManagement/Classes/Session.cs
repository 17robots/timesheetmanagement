using System;
using System.IO;
using System.Windows;

namespace FivesBronxTimesheetManagement.Classes
{
    static class Session
    {
        // deletes the session file if it exists
        public static void Logout()
        {
            string path = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "\\session.txt");
            if (File.Exists(path)) File.Delete(path);
        }

        // writes the values to the session file but if they already exist then it 
        public static void CreateSession(string user, string password)
        {
            string path = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "\\session.txt");

            TextWriter writer = File.CreateText(path);
            writer.WriteLine(user);
            writer.WriteLine(password);
            writer.Close();
        }

        // tries to read the values from the file and returns if it could or not
        public static bool ReadSession(ref string username, ref string password)
        {
            StreamReader reader;
            string path;
            try
            {
                path = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "\\session.txt");
                if (File.Exists(path))
                {
                    reader = new StreamReader(path);
                    try
                    {
                        username = reader.ReadLine();
                        password = reader.ReadLine();
                    }
                    finally
                    {
                        ((IDisposable)reader).Dispose();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
    }
}
