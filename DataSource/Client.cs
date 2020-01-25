//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataSource
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Client
    {
        [Required(ErrorMessage ="le champs titre est obligatoire")]
        public string Title { get; set; }
        [RegularExpression("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage ="email invalide")]
        [Required(ErrorMessage = "le champs email est obligatoire")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "le num�ro est obligatoire")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Le num�ro est invalide")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "le champs adresse est obligatoire")]
        public string Adress { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string fax { get; set; }
        public int Id { get; set; }
        public Nullable<int> state { get; set; }
        public string Color { get; set; }
    }
}
