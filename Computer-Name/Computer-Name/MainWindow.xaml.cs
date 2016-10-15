﻿using System.Windows;
using System.Net;
using System.Linq;

namespace ComputerName
{

    public partial class MainWindow : Window
    {
        IPAddress[] addresses;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void MachineName_Initialized(object sender, System.EventArgs e)
        {
            MachineName.Text = (System.Environment.MachineName);
        }

        private void Domain_Initialized(object sender, System.EventArgs e)
        {
            Domain.Text = (System.Environment.UserDomainName);
        }

        private void IPs_Initialized(object sender, System.EventArgs e)
        {
            addresses = Dns.GetHostAddresses(Dns.GetHostName()).Where(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToArray();

            foreach (object address in addresses)
            {
                IPs.Items.Add(address);
            }

        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            string copiedDetails = MachineName.Text + "\r\n" + Domain.Text + "\r\n";

            foreach (var ipAddress in addresses)
            {
                copiedDetails += ipAddress.ToString() + "\r\n";
            }

            Clipboard.SetText(copiedDetails);
        }

    }

}