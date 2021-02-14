using System;
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

namespace Organization_Employees_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository data;

        public MainWindow()
        {
            InitializeComponent();
            data = Repository.CreateRepository();

            cbDepartment.ItemsSource = data.DepartmentsDb;

        }

        private void btnRef(object sender, RoutedEventArgs e)
        {
            cbDepartment.Items.Refresh();
            lvWorkers.Items.Refresh();
        }


        private void CbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvWorkers.ItemsSource = data.WorkersDb.Where(find);
        }

        private bool find(Worker arg)
        {
            return arg.DepartamentId == (cbDepartment.SelectedItem as Department).DepartmentId;
        }
    }
}
