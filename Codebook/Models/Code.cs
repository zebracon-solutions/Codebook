//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Codebook.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Code
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Data1 { get; set; }
        public string Data1Value { get; set; }
        public string Data2 { get; set; }
        public string Data2Value { get; set; }
        public string Data3 { get; set; }
        public string Data3Value { get; set; }
        public int UserId { get; set; }
    
        public virtual User User { get; set; }
    }
}