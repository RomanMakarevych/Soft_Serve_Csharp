namespace _15_file_system
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            #region
            var drives=DriveInfo.GetDrives();

            foreach (var d in drives)
            {
                if(d.IsReady)
                Console.WriteLine($"Drive {d.VolumeLabel}: {d.Name} {d.DriveFormat}, size: {d.TotalFreeSpace/1024/1024/1024}");
                else
                    Console.WriteLine($"Drive {d.Name} is not to ready");

            }

            #endregion

            

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

             var dir = Directory.CreateDirectory($@"{desktopPath}");




        }
    }
}