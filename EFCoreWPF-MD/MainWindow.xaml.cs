﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Microsoft.EntityFrameworkCore;

namespace EFCoreWPF_MD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ProductContext _context = new ProductContext();
        private CollectionViewSource categoryViewSource;
        public MainWindow()
        {
            InitializeComponent();
            categoryViewSource = (CollectionViewSource)FindResource(nameof(categoryViewSource));
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();
            _context.Categories.Load();
            categoryViewSource.Source = _context.Categories.Local.ToObservableCollection();
        }

        private void SaveChngsBttn_OnClick(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
            categoryDataGrid.Items.Refresh();
            productsDataGrid.Items.Refresh();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _context.Dispose();
            base.OnClosing(e);
        }
    }
}
