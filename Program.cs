using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace Практика2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set",FileMode.Create, userStore);
            StreamWriter userWriter = new StreamWriter(userStream); userWriter.WriteLine("User Prefs"); 
            userWriter.Close();
            string[] files = userStore.GetFileNames("UserSettings.set");
            if (files.Length == 0)
            {
                Console.WriteLine("File doesn't not found");
            }
            userStream = new IsolatedStorageFileStream("UserSettings.set",FileMode.Open, userStore); 
            StreamReader userReader = new StreamReader(userStream); 
            string contents = userReader.ReadToEnd();
        }
    }
}
