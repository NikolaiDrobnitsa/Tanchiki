using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Server_Tanchikov
{
    public partial class Form1 : Form
    {
        static ServerObject server; //сервер
        static Thread listenThread; // потока для прослушивания
        public Form1()
        {
            InitializeComponent();
            startServer();
        }
        void startServer()
        {

                try
                {
                    server = new ServerObject();
                    listenThread = new Thread(new ThreadStart(server.Listen));
                    listenThread.Start(); //старт потока
                }
                catch (Exception ex)
                {
                    server.Disconnect();
                    Console.WriteLine(ex.Message);
                }
            
        }
    }
}
