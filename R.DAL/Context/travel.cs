//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace R.DAL.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class travel
    {
        public int id { get; set; }
        public Nullable<int> id_agency { get; set; }
        public Nullable<int> beginning { get; set; }
        public Nullable<int> destination { get; set; }
        public Nullable<System.TimeSpan> date_start { get; set; }
        public Nullable<System.TimeSpan> date_arrive { get; set; }
    
        public virtual agency agency { get; set; }
        public virtual ville ville { get; set; }
        public virtual ville ville1 { get; set; }
    }
}