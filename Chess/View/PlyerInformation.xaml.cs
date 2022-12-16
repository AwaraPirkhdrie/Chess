using Chess.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Chess.View
{
    /// <summary>
    /// interaktionslogik för Player Information.xaml
    /// </summary>
    public partial class PlyerInformation : Window
    {
        public PlyerInformation()
        {
            InitializeComponent();
        }
        private readonly DateTime startTime;
        private readonly FrameworkElement frameworkElement;
        private readonly DispatcherTimer timer;
        public string nameBlack = "";
        public string countryBlack = "";
        public string nameWhite = "";
        public string countryWhite = "";
        public object lbNameWhite { get; private set; }

        /// <summary>
        /// Player PlyerInformation startTime
        /// </summary>
        public PlyerInformation(FrameworkElement frameworkElement)
        {
            this.frameworkElement = frameworkElement;
            startTime = DateTime.Now;
            timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Render,
                     SecondEvent, frameworkElement.Dispatcher);
            timer.Start();
            SecondEvent(timer, new EventArgs());
        }
        /// <summary>
        /// Player time 
        /// </summary>
        private void SecondEvent(object sender, EventArgs e)
        {
            var timerString = DateTime.Now.Subtract(startTime).ToString("mm\\:ss");
            if (frameworkElement is TextBlock)
                ((TextBlock)frameworkElement).Text = timerString;
        }
        /// <summary>
        /// Player information to next page 
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtNameBlack.Text) || String.IsNullOrEmpty(txtBlackCountry.Text ) 
                || String.IsNullOrEmpty(txtNameWhite.Text) || String.IsNullOrEmpty(txtWhiteCountry.Text))
            {
                System.Windows.MessageBox.Show("Text box can't be empty");
                return;
            }
            nameBlack = txtNameBlack.Text;
            countryBlack = txtBlackCountry.Text;            
            nameWhite = txtNameWhite.Text;
            countryWhite = txtWhiteCountry.Text;
            MainWindow win1 = new MainWindow();      
            win1.txtBlack.Content = $"{nameBlack}";
            win1.txtBlackCountry.Content = $"{countryBlack}";
            win1.lbNameWhite.Content = $"{nameWhite}";
            win1.lblCountryWhite.Content = $"{countryWhite}";
            win1.Show();
            this.Close();   
        }
        /// <summary>
        /// Player information text file
        /// </summary>
        private void cboCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DirectoryInfo dinfo = new DirectoryInfo(@"C# Farid\inlämning A7\Chess\Chess\Model\Country.txt");
            FileInfo[] Files = dinfo.GetFiles("*.txt");
            foreach (FileInfo file in Files)
            {
               // cBoxCountry.Items.Add(file);
            }
            //cboCountry.ItemsSource = File.ReadAllLines(@"Model\Country.txt");
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
