using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

namespace Sessia2Malev.Pages
{
    /// <summary>
    /// Логика взаимодействия для EventPage.xaml
    /// </summary>
    public partial class EventPage
    {
        public static int id;

        public EventPage()
        {
            InitializeComponent();

            string dateInput = "27/08/2023";

            var parsedDate = DateTime.Parse(dateInput);

            if (id != 0)
            {
                ListEvent.ItemsSource = Classes.BaseClass.ME.EventNew.Where(x => x.EventID == id && x.DateEvent == parsedDate).ToList();
            }
        }
    }
}
