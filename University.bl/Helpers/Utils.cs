using System;
using System.IO;

namespace University.BL.Helpers
{
    public class Utils
    {
        public static void SaveFile(string path,
            string base64BinaryStr)
        {
            if (File.Exists(path))
                File.Delete(path);

            byte[] tempBytes = Convert.FromBase64String(base64BinaryStr);
            FileStream file = File.Create(path);
            file.Write(tempBytes, 0, tempBytes.Length);
            file.Close();
        }

        public static bool IsExistFile(string path)
        {
            if (File.Exists(path)) return true;
            return false;
        }
    }
}