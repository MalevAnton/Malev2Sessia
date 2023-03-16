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
    /// Логика взаимодействия для AbonentPage.xaml
    /// </summary>
    public partial class AbonentPage
    {
        Sotrudnik img;

        public AbonentPage()
        {
            InitializeComponent();

            roleSotrudnik.Navigate(new RolePage());

            FrameClass.roleSotrudnik = roleSotrudnik;

            Event.Navigate(new Event());

            FrameClass.events = Event;

            Title.Navigate(new TitlePage());

            FrameClass.title = Title;

            Image.Navigate(new UserImagePage());

            FrameClass.userImage = Image;

            ListView.Navigate(new ListAbonentPage());

            FrameClass.listView = ListView;

            List<Sotrudnik> sotrudnik = BaseClass.ME.Sotrudnik.ToList();

            UserFIO.Items.Add("Не выбрано");

            for (int i = 0; i < sotrudnik.Count; i++)
            {
                UserFIO.Items.Add(sotrudnik[i].Fio);
            }

            UserFIO.SelectedIndex = 0;
        }

        private void UserFIO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Sotrudnik> imageSotrudnik = BaseClass.ME.Sotrudnik.ToList();

            if (UserFIO.SelectedIndex > 0)
            {
                img = imageSotrudnik.FirstOrDefault(x => x.SotrudnikID == UserFIO.SelectedIndex);

                RolePage.id = img.RoleID;

                FrameClass.roleSotrudnik.Navigate(new RolePage());

                EventPage.id = img.RoleID;

                FrameClass.events.Navigate(new EventPage());

                TitlePage.index_button = 1;

                FrameClass.title.Navigate(new TitlePage());

                UserImagePage.image = UserFIO.SelectedIndex;

                FrameClass.userImage.Navigate(new UserImagePage());

            }

            else
            {
                RolePage.id = 0;

                FrameClass.roleSotrudnik.Navigate(new RolePage());

                EventPage.id = 0;

                FrameClass.events.Navigate(new List());

                TitlePage.index_button = 1;

                FrameClass.title.Navigate(new TitlePage());

                UserImagePage.image = 0;

                FrameClass.userImage.Navigate(new UserImagePage());
            }
        }
    }
}
