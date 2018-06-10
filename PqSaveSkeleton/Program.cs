using System.IO;

namespace PqSaveSkeleton
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            byte[] savefile = File.ReadAllBytes("user");
            SaveManager save = new SaveManager(savefile);

            // Work with save object

            byte[] savefileNew = save.Export();
            File.WriteAllBytes("user_new", savefileNew);
        }
    }
}
