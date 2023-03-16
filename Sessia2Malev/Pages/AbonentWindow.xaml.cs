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
using System.Windows.Shapes;

namespace Sessia2Malev.Pages
{
    /// <summary>
    /// Логика взаимодействия для AbonentWindow.xaml
    /// </summary>
    public partial class AbonentWindow : Window
    {
        Subscriber subscriber;

        Contract contract;

        public AbonentWindow(Subscriber subscriber)
        {
            InitializeComponent();

            this.subscriber = subscriber;

            NomerAbonenta.Text = "Номер абонента: " + subscriber.Number;

            FIO.Text = "ФИО абонента: " + subscriber.FIO;

            Passport.Text = "Серия паспорта: " + subscriber.SeriaPassport + "  Номер паспорта: " + subscriber.NumberPassport;

            PassportDann.Text = "Кем выдан: " + subscriber.IssuedBy;

            PassportData.Text = " Дата выдачи: " + String.Format("{0:dd MMMM yyyy}", subscriber.DateOfIssue);

            contract = BaseClass.ME.Contract.FirstOrDefault(x => x.ContractID == subscriber.SubscriberID);

            NomerContract.Text = "Номер договора с абонентом: " + contract.Number;

            ContractType contractType = BaseClass.ME.ContractType.FirstOrDefault(x => x.ContractTypeID == contract.ContractTypeID);

            TypeContract.Text = "Тип договора: " + contractType.Type;

            if (contract.ReasonForTermination == null)
            {
                DataContract.Text = "Дата заключения: " + String.Format("{0:dd MMMM yyyy}", contract.DateOfCinclusion);
            }

            else
            {
                PrichinaContract.Visibility = Visibility.Visible;

                DataContract.Text = "Дата заключения: " + String.Format("{0:dd MMMM yyyy}", contract.DateOfCinclusion) + " Дата расторжения: " + String.Format("{0:dd MMMM yyyy}", contract.TerminationDate);

                ReasonForTermination cause = BaseClass.ME.ReasonForTermination.FirstOrDefault(x => x.ReasonForTetminationID == contract.ReasonForTerminationID);

                PrichinaContract.Text = "Причина расторжения договора: " + cause.Cause;
            }

            PerconalAccount.Text = "Лицевой счет: " + contract.PersonalAccount;

            ResidentalAddress residentialAddress = BaseClass.ME.ResidentalAddress.FirstOrDefault(x => x.ResidentalAddressID == subscriber.ResidentialAddressID);

            Raion raion = BaseClass.ME.Raion.FirstOrDefault(x => x.RaionID == residentialAddress.RaionID);

            Street street = BaseClass.ME.Street.FirstOrDefault(x => x.StreetID == residentialAddress.StreetID);

            Address.Text = "Адрес: " + residentialAddress.City + ", " + raion.Raion1 + " район, " + street.Street1 + ", дом " + residentialAddress.House;

            services.Text = subscriber.service_and_date;

            InstallationEquipment installationEquipment = BaseClass.ME.InstallationEquipment.FirstOrDefault(x => x.SubscriberID == subscriber.SubscriberID);

            Equipment equipment = BaseClass.ME.Equipment.FirstOrDefault(x => x.EquipmentID == installationEquipment.EquipmentID);

            NomerEquipment.Text = "Серийный номер оборудования:" + equipment.SerialNumber;

            NameEquipment.Text = "Название оборудования: " + equipment.Tytle;

            EquipmentType type = BaseClass.ME.EquipmentType.FirstOrDefault(x => x.EquipmentTypeID == equipment.EquipmentTypeID);

            typeEquipment.Text = "Тип оборудования: " + type.Title;

            if (equipment.InvertaryNumber != null && equipment.AdressMAC != null)
            {
                DannaEquipment.Visibility = Visibility.Visible;

                DannaEquipment.Text = "Инвертарный номер: " + equipment.InvertaryNumber + ", Адрес MAC: " + equipment.AdressMAC;
            }

            else if (equipment.InvertaryNumber == null && equipment.AdressMAC != null)
            {
                DannaEquipment.Visibility = Visibility.Visible;

                DannaEquipment.Text = " Адрес MAC: " + equipment.AdressMAC;
            }

            else if (equipment.InvertaryNumber != null && equipment.AdressMAC == null)
            {
                DannaEquipment.Visibility = Visibility.Visible;

                DannaEquipment.Text = "Инвертарный номер: " + equipment.InvertaryNumber;
            }

            NomerDogovora.Text = "Номер договора : " + contract.Number;

            if (installationEquipment.Notes != null)
            {
                SrokDogovora.Visibility = Visibility.Visible;

                SrokDogovora.Text = installationEquipment.Notes;
            }

            List<CRM> crm = BaseClass.ME.CRM.Where(x => x.SubscriberID == subscriber.SubscriberID).ToList();

            if (crm.Count > 0)
            {
                List<CRM> cRMs = new List<CRM>();

                list.Visibility = Visibility.Visible;

                for (int i = 0; i < crm.Count; i++)
                {

                    DateTime date = crm[i].DateCreation;

                    date = date.AddMonths(12);

                    if (DateTime.Today <= date)
                    {
                        cRMs.Add(crm[i]);
                    }
                }

                listCRM.ItemsSource = cRMs;
            }
        }
    }
}
