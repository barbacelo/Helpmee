//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApplication3
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class roba
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public roba()
        {
            this.racuni = new ObservableCollection<racuni>();
        }
    
        public int idbroj { get; set; }
        public string naziv { get; set; }
        public string jm { get; set; }
        public decimal kol { get; set; }
        public decimal zaliha { get; set; }
        public decimal cena { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<racuni> racuni { get; set; }
    }
}
