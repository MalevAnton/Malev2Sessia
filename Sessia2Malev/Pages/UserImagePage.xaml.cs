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
    /// Логика взаимодействия для UserImagePage.xaml
    /// </summary>
    public partial class UserImagePage : Page
    {
        public static int image;

        public UserImagePage()
        {
            InitializeComponent();

            if (image != 0)
            {
                Sotrudnik sotrudnik = BaseClass.ME.Sotrudnik.FirstOrDefault(x => x.SotrudnikID == image);

                if (sotrudnik.Photo != null)
                {
                    userImage.Source = new BitmapImage(new Uri(sotrudnik.Photo, UriKind.Relative));
                }

                else
                {
                    userImage.Source = new BitmapImage(new Uri("../Image/Фото для заглушки при отсутствии фото сотрудника.jpg", UriKind.Relative));
                }

            }

            else
            {
                userImage.Source = new BitmapImage(new Uri("../Image/Фото для заглушки при отсутствии фото сотрудника.jpg", UriKind.Relative));
            }
        }
    }
}
