//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LenaProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Forms
    {
        public int FormId { get; set; }
        public string FormName { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Nullable<int> Age { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
