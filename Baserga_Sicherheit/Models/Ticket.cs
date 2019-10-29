namespace Baserga_Sicherheit.Models
{
    using Baserga_Sicherheit.Controllers;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        public int TicketId { get; set; }

        [Required]
        [StringLength(50)]
        [TicketValidation]
        public string Beschreibung { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression("^[A-Za-z0-9]+(?:[ _-][A-Za-z0-9]+)*$")]
        [TicketValidation]
        public string NameAufTicket { get; set; }

        [Required]
        [StringLength(50)]
        [TicketValidation]
        public string Bereich { get; set; }

        [Required]
        [StringLength(50)]
        [TicketValidation]
        public string Zahlungsmittel { get; set; }
    }
}
