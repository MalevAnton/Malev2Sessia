using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessia2Malev
{
    public partial class CRM
    {
        public string number
        {
            get
            {
                return "Номер заявки: " + Number;
            }
        }

        public string dateStartAndEnd
        {
            get
            {
                if (ClosingDate == null)
                {
                    return "Дата создания: " + String.Format("{0:dd MMMM yyyy}", DateCreation);
                }

                else
                {
                    return "Дата создания: " + String.Format("{0:dd MMMM yyyy}", DateCreation) + "  Дата закрытия: " + String.Format("{0:dd MMMM yyyy}", ClosingDate);
                }
            }
        }

        public string services
        {
            get
            {
                return "Услуга: " + Service.Service1 + ", Тип услуги: " + TypeService.Service + ", Вид услуги: " + TypeService.Service;
            }
        }

        public string status
        {
            get
            {
                return "Статус: " + TypeService.Service;
            }
        }

        public string problema
        {
            get
            {
                if (Description == null)
                {
                    return "Тип проблемы: " + ProblemType.Type;
                }

                else
                {
                    return "Проблема: " + Description + ", Тип проблемы: " + ProblemType.Type;
                }
            }
        }
    }
}
