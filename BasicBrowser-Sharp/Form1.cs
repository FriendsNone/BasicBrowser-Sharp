using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace BasicBrowser_Sharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ChromiumWebBrowser chrome;

        private void Form1_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            tbAddress.Text = "https://github.com/FriendsNone";
            chrome = new ChromiumWebBrowser(tbAddress.Text);
            this.plContent.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
            chrome.AddressChanged += Chrome_AddressChanged;
        }

        private void Chrome_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                tbAddress.Text = e.Address;
            }));
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            chrome.Load(tbAddress.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            chrome.Refresh();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (chrome.CanGoBack)
                chrome.Back();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (chrome.CanGoForward)
                chrome.Forward();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
