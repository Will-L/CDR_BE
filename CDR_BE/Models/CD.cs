//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CDR_BE.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CD
    {
        public int CDId { get; set; }
        public string CDTitle { get; set; }
        public string CDSection { get; set; }
        public string CDAuthor { get; set; }
        public int CDCoordX { get; set; }
        public int CDCoordY { get; set; }
        public string CDBarcode { get; set; }
        public string CDDescription { get; set; }
        public bool CDStatus { get; set; }
        public string CDPic { get; set; }
    }
}
