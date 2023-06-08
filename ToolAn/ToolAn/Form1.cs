using InfoBox;
using System;

using System.IO;

using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ToolAn
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int uFlags, int dwReason);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.Visible = false;
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                KiemTraThoaDieuKien();
            }).Start();
        }

        private async void KiemTraThoaDieuKien()
        {
            await Task.Run(() =>
            {
                check();
               
            });
        }

        private static void check()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            string folderPath = @"D:\Wm\1";
            watcher.Path = folderPath;
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            // Bắt các sự kiện thay đổi file
            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;

            // Bắt đầu theo dõi
            watcher.EnableRaisingEvents = true;
            Console.ReadLine();
            
        }
        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            InformationBox.Show("File đã thay đổi: " + e.FullPath+"\n"+"Hành động đã được hệ thống ghi lại", "Cảnh báo người dùng");
            Logout();
        }

        // Xử lý sự kiện file được tạo mới
        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            InformationBox.Show("File đã tạo mới: " + e.FullPath + "\n" + "Hành động đã được hệ thống ghi lại", "Cảnh báo người dùng");
            Logout();
        }

        // Xử lý sự kiện file bị xóa
        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            InformationBox.Show("File bị xóa: " + e.FullPath + "\n" + "Hành động đã được hệ thống ghi lại", "Cảnh báo người dùng");
            Logout();
        }

        // Xử lý sự kiện file được đổi tên
        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            InformationBox.Show("File được đổi tên: " + e.OldFullPath + " => " + e.FullPath + "\n" + "Hành động đã được hệ thống ghi lại", "Cảnh báo người dùng");
            Logout();
        }
        private static void Logout()
        {
            const int EWX_FORCE = 4;
            const int EWX_LOGOFF = 0;
            ExitWindowsEx(EWX_LOGOFF | EWX_FORCE, 0);
        }
    }
}
