//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sessia2Malev
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subscriber
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subscriber()
        {
            this.CRM = new HashSet<CRM>();
            this.InstallationEquipment = new HashSet<InstallationEquipment>();
        }
    
        public int SubscriberID { get; set; }
        public string Number { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public int GenderID { get; set; }
        public System.DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PlaceOfResidence { get; set; }
        public string ResidentialAddressID { get; set; }
        public string SeriaPassport { get; set; }
        public string NumberPassport { get; set; }
        public string DivisionCode { get; set; }
        public string IssuedBy { get; set; }
        public System.DateTime DateOfIssue { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRM> CRM { get; set; }
        public virtual Gender Gender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InstallationEquipment> InstallationEquipment { get; set; }
    }
}
