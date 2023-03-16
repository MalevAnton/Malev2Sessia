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
    /// Логика взаимодействия для ListAbonentPage.xaml
    /// </summary>
    public partial class ListAbonentPage : Page
    {
        public static int index;

        public ListAbonentPage()
        {
            InitializeComponent();

            Active.IsChecked = true;

            listAbonent.ItemsSource = BaseClass.ME.Subscriber.ToList();

            cmbSearch.SelectedIndex = 0;

            Street.Items.Add("Улица не выбрана");

            List<Street> streets = BaseClass.ME.Street.ToList();

            for (int i = 0; i < streets.Count; i++)
            {
                Street.Items.Add(streets[i].Street1);
            }

            Street.SelectedIndex = 0;
        }

        private void cmbSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSearch.SelectedIndex > 0)
            {
                if (cmbSearch.SelectedIndex == 3)
                {
                    Search.Visibility = Visibility.Collapsed;

                    Street.Visibility = Visibility.Visible;
                }

                else
                {
                    Search.Visibility = Visibility.Visible;

                    Street.Visibility = Visibility.Collapsed;
                }
            }

            else
            {
                Search.Visibility = Visibility.Collapsed;

                Street.Visibility = Visibility.Collapsed;
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void Street_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void abonentaView_Click(object sender, RoutedEventArgs e)
        {
            Subscriber index = (Subscriber)listAbonent.SelectedItem;

            AbonentWindow abonent = new AbonentWindow(index);

            abonent.ShowDialog();
        }

        private void Active_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void Active_Unchecked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void NoActive_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void NoActive_Unchecked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        void Filter()
        {
            List<Subscriber> subscribers = BaseClass.ME.Subscriber.ToList();

            if (Active.IsChecked == true && NoActive.IsChecked == false)
            {
                List<Contract> contracts1 = BaseClass.ME.Contract.ToList();

                List<Contract> contract1 = new List<Contract>();

                List<Subscriber> subscriberList1 = BaseClass.ME.Subscriber.ToList();

                List<Subscriber> subscribe1 = new List<Subscriber>();

                List<Subscriber> subscribe4 = new List<Subscriber>();

                contract1 = contracts1.Where(x => x.ReasonForTerminationID == null).ToList();

                if (contract1.Count > 0)
                {
                    for (int i = 0; i < contract1.Count; i++)
                    {
                        subscribe1 = subscriberList1.Where(x => x.SubscriberID == contract1[i].ContractID).ToList();

                        if (subscribe1.Count > 0)
                        {
                            for (int j = 0; j < subscribe1.Count; j++)
                            {
                                subscribe4.Add(subscribe1[j]);
                            }
                        }
                    }
                    subscribers = subscribe4.ToList();
                }
            }
            else if (Active.IsChecked == false && NoActive.IsChecked == true)
            {
                List<Contract> contracts = BaseClass.ME.Contract.ToList();

                List<Contract> contract = new List<Contract>();

                List<Subscriber> subscriberList = BaseClass.ME.Subscriber.ToList();

                List<Subscriber> subscribe = new List<Subscriber>();

                List<Subscriber> subscribe3 = new List<Subscriber>();

                contract = contracts.Where(x => x.ReasonForTerminationID != null).ToList();

                if (contract.Count > 0)
                {
                    for (int i = 0; i < contract.Count; i++)
                    {
                        subscribe = subscriberList.Where(x => x.SubscriberID == contract[i].ContractID).ToList();

                        if (subscribe.Count > 0)
                        {
                            for (int j = 0; j < subscribe.Count; j++)
                            {
                                subscribe3.Add(subscribe[j]);
                            }
                        }
                    }

                    subscribers = subscribe3.ToList();
                }
            }

            if (cmbSearch.SelectedIndex != 3)
            {

                switch (cmbSearch.SelectedIndex)
                {
                    case 1:
                        {
                            if (!string.IsNullOrWhiteSpace(Search.Text))
                            {
                                subscribers = subscribers.Where(x => x.LastName.ToLower().Contains(Search.Text.ToLower())).ToList();
                            }
                        }
                        break;
                    case 2:
                        {
                            if (!string.IsNullOrWhiteSpace(Search.Text))
                            {
                                List<Subscriber> addSub = new List<Subscriber>();

                                List<Subscriber> subscribers1 = BaseClass.ME.Subscriber.ToList();

                                List<Subscriber> subscribers3 = BaseClass.ME.Subscriber.ToList();

                                List<ResidentalAddress> residentialAddresses = BaseClass.ME.ResidentalAddress.ToList();

                                List<Raion> raions = BaseClass.ME.Raion.Where(x => x.Raion1.ToLower().Contains(Search.Text.ToLower())).ToList();

                                for (int i = 0; i < raions.Count; i++)
                                {
                                    List<ResidentalAddress> residentials = new List<ResidentalAddress>();

                                    residentials = residentialAddresses.Where(x => x.RaionID == raions[i].RaionID).ToList();

                                    if (residentials.Count > 0)
                                    {
                                        for (int j = 0; j < residentials.Count; j++)
                                        {
                                            List<Subscriber> subscribers2 = new List<Subscriber>();

                                            subscribers2 = subscribers1.Where(x => x.ResidentialAddressID == residentialAddresses[j].ResidentalAddressID).ToList();

                                            for (int k = 0; k < subscribers2.Count; k++)
                                            {

                                                addSub.Add(subscribers2[k]);

                                            }
                                        }
                                    }

                                }
                                subscribers = addSub.Distinct().ToList();
                            }

                            else
                            {
                                subscribers = subscribers.ToList();
                            }
                        }

                        break;

                    case 4:
                        {
                            if (!string.IsNullOrWhiteSpace(Search.Text))
                            {
                                List<Subscriber> addSub = new List<Subscriber>();

                                List<Contract> contracts = new List<Contract>();

                                List<Contract> contract = BaseClass.ME.Contract.ToList();

                                List<Subscriber> subscribers1 = BaseClass.ME.Subscriber.ToList();

                                contracts = contract.Where(x => x.personalAccount.ToLower().Contains(Search.Text.ToLower())).ToList();

                                for (int i = 0; i < contracts.Count; i++)
                                {
                                    List<Subscriber> subscribers2 = new List<Subscriber>();

                                    subscribers2 = subscribers1.Where(x => x.SubscriberID == contracts[i].ContractID).ToList();

                                    if (subscribers2.Count > 0)
                                    {
                                        for (int j = 0; j < subscribers2.Count; j++)
                                        {
                                            addSub.Add(subscribers2[j]);
                                        }
                                    }
                                }

                                subscribers = addSub.Distinct().ToList();
                            }

                            else
                            {
                                subscribers = subscribers.ToList();
                            }
                        }

                        break;
                }
            }

            else
            {
                List<ResidentalAddress> addresses = new List<ResidentalAddress>();

                List<ResidentalAddress> residentialAddresses = BaseClass.ME.ResidentalAddress.ToList();

                List<Subscriber> subscriberList = BaseClass.ME.Subscriber.ToList();

                List<Subscriber> subscribe = new List<Subscriber>();

                List<Subscriber> subscribe3 = new List<Subscriber>();

                if (Street.SelectedIndex > 0)
                {
                    addresses = residentialAddresses.Where(x => x.StreetID == Street.SelectedIndex).ToList();

                    if (addresses.Count > 0)
                    {
                        for (int i = 0; i < addresses.Count; i++)
                        {
                            subscribe = subscriberList.Where(x => x.ResidentialAddressID == addresses[i].ResidentalAddressID).ToList();

                            if (subscribe.Count > 0)
                            {
                                for (int j = 0; j < subscribe.Count; j++)
                                {
                                    subscribe3.Add(subscribe[j]);
                                }

                                subscribers = subscribe3.ToList();
                            }
                        }
                    }

                    if (subscribe.Count == 0)
                    {
                        MessageBox.Show("Нет данных об абонентах на данной улице");

                        Street.SelectedIndex = 0;
                    }

                }
            }

            if (subscribers.Count == 0)
            {
                MessageBox.Show("Нет данных об абонентах");

                Search.Text = "";
            }

            else
            {
                listAbonent.ItemsSource = subscribers;
            }
        }
    }
}
