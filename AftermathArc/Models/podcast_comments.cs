//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AftermathArc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class podcast_comments
    {
        public int id { get; set; }
        public string comment { get; set; }
        public Nullable<System.DateTime> commentDate { get; set; }
        public string username { get; set; }
        public Nullable<int> podcast_id { get; set; }
    }
}
