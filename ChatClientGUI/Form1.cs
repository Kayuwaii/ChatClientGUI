using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ChatClientGUI
{
    public partial class Form1 : Form
    {
        public string EncryptionKey = GetHashedKey("Alexandros");
        public TcpClient tcpclnt = null;
        public bool cntrl = false;
        public Timer timer1;

        public Form1()
        {
            InitializeComponent();
            try
            {
                tcpclnt = new TcpClient();
                chatDisplayer_txtbox.AppendText("this is the beginning of your chat\n");

                tcpclnt.Connect("172.17.1.241", 8001);
                // use the ipaddress as in the server program



                displayConnection_lbl.Text = "Connected";
                displayConnection_lbl.ForeColor = Color.Green;

                InitTimer();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.ToString());
            }

        }

        public static string GetHashedKey(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            int cntr = 0;
            foreach (byte x in hash)
            {
                if (cntr == 1)
                {
                    cntr = 0;
                }
                else
                {
                    hashString += String.Format("{0:x2}", x);
                    cntr++;
                }
            }
            return hashString;
        }

        //Encrypting a string
        public static string TxtEncrypt(string inText, string key)
        {
            byte[] bytesBuff = Encoding.UTF8.GetBytes(inText);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    inText = Convert.ToBase64String(mStream.ToArray());
                }
            }
            return inText;
        }

        //Decrypting a string
        public static string TxtDecrypt(string cryptTxt, string key)
        {
            cryptTxt = cryptTxt.Replace(" ", "+");
            byte[] bytesBuff = Convert.FromBase64String(cryptTxt);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    cryptTxt = Encoding.UTF8.GetString(mStream.ToArray());
                }
            }
            return cryptTxt;
        }

        private void SendMessage_btn_Click(object sender, EventArgs e)
        {
            chatDisplayer_txtbox.AppendText("Me:\t ");
            chatDisplayer_txtbox.AppendText(inMessage_txtbox.Text + "\n");

            String str = TxtEncrypt(inMessage_txtbox.Text, EncryptionKey);
            Stream stm = tcpclnt.GetStream();

            byte[] ba = Encoding.UTF8.GetBytes(str);

            stm.Write(ba, 0, ba.Length);
            inMessage_txtbox.ResetText();
            GC.Collect();
        }


        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 50; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int cntr = 0;
            if (tcpclnt.Available > 0)
            {
                Stream stm = tcpclnt.GetStream();

                byte[] bb = new byte[tcpclnt.ReceiveBufferSize];

                int k = stm.Read(bb, 0, tcpclnt.ReceiveBufferSize);
                string msg = "";
                chatDisplayer_txtbox.AppendText("Other:\t");
                for (int i = 0; i < k; i++)
                {
                    msg += Convert.ToChar(bb[i]);
                }
                chatDisplayer_txtbox.AppendText(TxtDecrypt(msg, EncryptionKey) + "\n"); ;
                cntr++;
                if (cntr > 2)
                {
                    GC.Collect();
                    cntr = 0;
                }
            }

        }

        private void inMessage_txtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                sendMessage_btn.PerformClick();
            }
        }

    }
}

