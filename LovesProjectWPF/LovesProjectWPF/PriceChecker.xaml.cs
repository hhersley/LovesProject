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
using System.Windows.Shapes;

namespace LovesProjectWPF
{
    /// <summary>
    /// Interaction logic for PriceChecker.xaml
    /// </summary>
    public partial class PriceChecker : Window
    {
       
            public PriceChecker(string StoreID, double? BasePrice)
        {
            InitializeComponent();


        }
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
