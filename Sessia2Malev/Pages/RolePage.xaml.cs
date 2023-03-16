using Sessia2Malev.Classes;
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
    /// Логика взаимодействия для RolePage.xaml
    /// </summary>
    public partial class RolePage : Page
    {
        public static int id;

        public RolePage()
        {
            InitializeComponent();

            if (id == 1)
            {
                Abonent.Visibility = Visibility.Visible;

                oborydovanue.Visibility = Visibility.Collapsed;

                activ.Visibility = Visibility.Collapsed;

                billing.Visibility = Visibility.Visible;

                poddergka.Visibility = Visibility.Collapsed;

                crm.Visibility = Visibility.Visible;
            }

            else if (id == 2)
            {
                Abonent.Visibility = Visibility.Visible;

                oborydovanue.Visibility = Visibility.Collapsed;

                activ.Visibility = Visibility.Collapsed;

                billing.Visibility = Visibility.Collapsed;

                poddergka.Visibility = Visibility.Collapsed;

                crm.Visibility = Visibility.Visible;
            }

            else if (id == 3)
            {
                Abonent.Visibility = Visibility.Visible;

                oborydovanue.Visibility = Visibility.Visible;

                activ.Visibility = Visibility.Collapsed;

                billing.Visibility = Visibility.Collapsed;

                poddergka.Visibility = Visibility.Visible;

                crm.Visibility = Visibility.Visible;
            }

            else if (id == 4)
            {
                Abonent.Visibility = Visibility.Visible;

                oborydovanue.Visibility = Visibility.Visible;

                activ.Visibility = Visibility.Collapsed;

                billing.Visibility = Visibility.Collapsed;

                poddergka.Visibility = Visibility.Visible;

                crm.Visibility = Visibility.Visible;
            }

            else if (id == 5)
            {
                Abonent.Visibility = Visibility.Visible;

                oborydovanue.Visibility = Visibility.Collapsed;

                activ.Visibility = Visibility.Visible;

                billing.Visibility = Visibility.Visible;

                poddergka.Visibility = Visibility.Collapsed;

                crm.Visibility = Visibility.Collapsed;
            }

            else if (id == 6)
            {
                Abonent.Visibility = Visibility.Visible;

                oborydovanue.Visibility = Visibility.Visible;

                activ.Visibility = Visibility.Visible;

                billing.Visibility = Visibility.Visible;

                poddergka.Visibility = Visibility.Visible;

                crm.Visibility = Visibility.Visible;
            }

            else if (id == 7)
            {
                Abonent.Visibility = Visibility.Visible;

                oborydovanue.Visibility = Visibility.Visible;

                activ.Visibility = Visibility.Visible;

                billing.Visibility = Visibility.Collapsed;

                poddergka.Visibility = Visibility.Collapsed;

                crm.Visibility = Visibility.Visible;
            }

            else if (id == 0)
            {
                Abonent.Visibility = Visibility.Visible;

                oborydovanue.Visibility = Visibility.Collapsed;

                activ.Visibility = Visibility.Collapsed;

                billing.Visibility = Visibility.Collapsed;

                poddergka.Visibility = Visibility.Collapsed;

                crm.Visibility = Visibility.Collapsed;
            }

        }

        private void Abonent_Click(object sender, RoutedEventArgs e)
        {
            TitlePage.index_button = 1;

            FrameClass.title.Navigate(new TitlePage());

            FrameClass.listView.Navigate(new ListAbonentPage());
        }

        private void oborydovanue_Click(object sender, RoutedEventArgs e)
        {
            TitlePage.index_button = 2;

            FrameClass.title.Navigate(new TitlePage());
        }

        private void activ_Click(object sender, RoutedEventArgs e)
        {
            TitlePage.index_button = 3;

            FrameClass.title.Navigate(new TitlePage());
        }

        private void billing_Click(object sender, RoutedEventArgs e)
        {
            TitlePage.index_button = 4;

            FrameClass.title.Navigate(new TitlePage());
        }

        private void poddergka_Click(object sender, RoutedEventArgs e)
        {
            TitlePage.index_button = 5;

            FrameClass.title.Navigate(new TitlePage());
        }

        private void crm_Click(object sender, RoutedEventArgs e)
        {
            TitlePage.index_button = 6;

            FrameClass.title.Navigate(new TitlePage());
        }
    }
}
