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
    
    public partial class Practical_Booking
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Pra_Id { get; set; }
    
        public virtual User User { get; set; }
        public virtual Practical_Conducted Practical_Conducted { get; set; }
    }
}
