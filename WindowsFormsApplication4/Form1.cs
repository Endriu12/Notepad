using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        static extern IntPtr FindWindowEx(IntPtr parentHandle, int childAfter, string className, string windowTitle);
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int uMsg, string wParam, string lParam);
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        const int WM_CHAR = 0x0102;

        public Form1()
        {
            InitializeComponent();
        }

    

        private void Form1_Load(object sender, EventArgs e){
        
            StreamReader streamReader = new StreamReader("qwerty.txt"); //Открываем файл для чтения
            string str = ""; //Объявляем переменную, в которую будем записывать текст из файла
            while (!streamReader.EndOfStream) //Цикл длиться пока не будет достигнут конец файла
            {
                str += streamReader.ReadLine(); //В переменную str по строчно записываем содержимое файла
            }
            IntPtr hWnd = FindWindow(null, "Безымянный — Блокнот");
            IntPtr hWndEdit = FindWindowEx(hWnd, 0, "Edit", null);
          //  SendMessage(hWndEdit, WM_CHAR, str, null);
            SetForegroundWindow(hWnd);
            SendKeys.SendWait("I do it");
            SendKeys.SendWait("Happy");
            SendKeys.SendWait("^s");
            IntPtr hWnd1 = FindWindow(null, "Сохранение");
        //    IntPtr hWndEdit1 = FindWindowEx(hWnd1, 0, "Имя файла", null);
            SendKeys.SendWait("MyProgramm");//Задаємо імя файла!
            SendKeys.SendWait("~");
        }   
    }
}