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
using PlutoDesktop.Core.Domain;
using PlutoDesktop.Persistence;
using System.Data.Entity;

namespace PlutoDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PlutoContext _context = new PlutoContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource courseViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("courseViewSource")));

            _context.Courses.Include(c => c.Author).Load();

            courseViewSource.Source = _context.Courses.Local;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            _context.Dispose();
        }

        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            _context.Courses.Add(new Course
            {
                AuthorId = 1,
                Name = "New Course at " + DateTime.Now.ToShortDateString(),
                Description = "Description",
                FullPrice = 49,
                Level = 1

            });

            _context.SaveChanges();
        }
    }
}
