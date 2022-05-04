﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LovesProjectWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class temporaryinfo
        {


            public string StoreID { get; set; }
            public double BasePrice { get; set; }

        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            temporaryinfo TO = new temporaryinfo();

            string StoreID = cbostore.SelectedItem.ToString();
            double BasePrice = Convert.ToDouble(tboprice.Text);

            PriceChecker window = new PriceChecker(temporaryinfo);
            PriceChecker.Show();

            
        }
    }
}
