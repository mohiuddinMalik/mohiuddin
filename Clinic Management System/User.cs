//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clinic_Management_System
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Invoices = new HashSet<Invoice>();
            this.Practical_Booking = new HashSet<Practical_Booking>();
            this.Sales = new HashSet<Sale>();
            this.Seminar_Booking = new HashSet<Seminar_Booking>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Card_Details { get; set; }
        public string CNIC { get; set; }
        public string Contact_No_ { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
    
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Practical_Booking> Practical_Booking { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Seminar_Booking> Seminar_Booking { get; set; }
    }
}
