namespace TextSearch.Classes
{
    internal class Utilities
    {
        public static string GetFileNameOnly(string currentDirectory, string fileName)
        {
            return fileName.Remove(0, currentDirectory.Length + 1);
        }

        public static void RemoveOutputFiles(string currentDirectory)
        {
            string[] filePaths = Directory.GetFiles(currentDirectory, ("FileSearchOutput_" + "*"));

            foreach (string file in filePaths)
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
        }

        public static string InsertNewTextLine(ref string existingString, string newLine)
        {
            existingString = newLine + "\r\n" + existingString;
            return existingString;
        }

        public static int GetFilesCount(string currentDir, string prefix, string suffix)
        {
            int count = 0;
            if (prefix != null)
            {
                count = Directory.GetFiles(currentDir, (prefix + "*")).Length;
            }
            else if (suffix != null)
            {
                count = Directory.GetFiles(currentDir, ("*" + suffix)).Length;
            }
            else
            {
                count = Directory.GetFiles(currentDir).Length;
            }
            return count;
        }

        public static Queue<string> GetFiles(string currentDir, string prefix, string suffix, int count)
        {
            Queue<string> filesDir = new Queue<string>();

            string[] filePaths = new string[count];

            if (prefix != null)
            {
                filePaths = Directory.GetFiles(currentDir, (prefix + "*"));
            }
            else if (suffix != null)
            {
                filePaths = Directory.GetFiles(currentDir, ("*" + suffix));
            }
            else
            {
                filePaths = Directory.GetFiles(currentDir);
            }

            foreach (string filePath in filePaths)
            {
                filesDir.Enqueue(filePath);
            }
            return filesDir;
        }
    }
}
