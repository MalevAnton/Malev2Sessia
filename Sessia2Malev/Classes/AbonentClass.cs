using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessia2Malev
{
    public partial class Subscriber
    {

        Contract contract;

        public string FIO
        {
            get
            {
                return LastName + " " + FirstName + " " + Patronymic;
            }
        }

        public string service
        {
            get
            {
                contract = Classes.BaseClass.ME.Contract.FirstOrDefault(x => x.ContractID == SubscriberID);

                List<ConnectedService> connectedServices = Classes.BaseClass.ME.ConnectedService.Where(x => x.ContractID == contract.ContractID).ToList();

                int i = connectedServices.Count;

                string serv = "";

                if (i == 0)
                {
                    serv = "Никаких услуг не подключено";
                }

                else
                {
                    foreach (ConnectedService connectedService in connectedServices)
                    {
                        serv += " " + connectedService.Service.Service1 + ", ";
                    }
                    serv = serv.Substring(0, serv.Length - 2);
                }

                return serv;
            }
        }

        public string service_and_date
        {
            get
            {
                contract = Classes.BaseClass.ME.Contract.FirstOrDefault(x => x.ContractID == SubscriberID);

                List<ConnectedService> connectedServices = Classes.BaseClass.ME.ConnectedService.Where(x => x.ContractID == contract.ContractID).ToList();

                int i = connectedServices.Count;

                string serv = "";

                if (i == 0)
                {
                    serv = "Никаких услуг не подключено";
                }

                else
                {
                    foreach (ConnectedService connectedService in connectedServices)
                    {
                        if (connectedService.Date == null)
                        {
                            serv += "Услуга: " + connectedService.Service.Service1 + " \n";
                        }

                        else
                        {
                            serv += "Услуга: " + connectedService.Service.Service1 + ", Дата подключения: " + String.Format("{0:dd MMMM yyyy}", connectedService.Date) + " \n";
                        }
                    }

                    serv = serv.Substring(0, serv.Length - 2);
                }

                return serv;
            }
        }
    }
}
