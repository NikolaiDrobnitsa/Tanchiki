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
        static ClientObject client; //сервер
        //static Thread listenThread; // потока для прослушивания

        public Form1()
        {
            InitializeComponent();
        }
        public void addPLayer()
        {
            //listBox1.Items.Add(player);
            if (server.clients.Count > 0)
            {
                for (int i = 0; i < server.clients.Count; i++)
                {
                    if (listBox1.Items.Contains(server.clients[i].userName) != true)
                    {
                        listBox1.Items.Add(server.clients[i].userName);
                    }

                }
            }
            
        }
      

        private void button2_Click(object sender, EventArgs e)
        {
            //listBox1.Items.Add("sss");
            //for (int i = 0; i < server.clients.Count; i++)
            //{
            //    if (listBox1.Items.Contains(server.clients[i].userName) != true)
            //    {
            //        listBox1.Items.Add(server.clients[i].userName);
            //    }

            //}
            for (int i = 0; i < server.clients.Count; i++)
            {
                textBox1.Text += server.clients[i].Id;
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                server = new ServerObject();
                
                //listenThread = new Thread(new ThreadStart(server.Listen));
                //listenThread.Start(); //старт потока
                await Task.Factory.StartNew(() =>
                {
                    server.Listen();
                    


                });
            }
            catch (Exception ex)
            {
                server.Disconnect();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
