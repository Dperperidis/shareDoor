using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shareDoor.Models
{
    public enum Level
    {
        Υπόγειο =-2,
        Ήμιυπόγειο,
        Ισόγειο,
        Πρώτος,
        Δεύτερος,
        Τρίτος,
        Τέταρτος,
        Πέμπτος,
        Έκτος,
        Έβδομος,
        Όγδοος
    }

    public enum Confirmation
    {
        Pass,
        Pending,
        Cancel
    }


    public class House
    {

        public int Id { get; set; }
        //[Required]
        [DisplayName("Τετραγωνικά μέτρα")]
        public byte SquareMeters { get; set; }
        [Required]
        [DisplayName("Όροφος")]
        public Level Level { get; set; }
        [Required]
        [DisplayName("Έτος κατασκευής")]
        public DateTime YearConstruct { get; set; }
        //[Required]
        [DisplayName("Δωμάτια")]
        public int TotalRooms { get; set; }
        [Required]
        [DisplayName("Μηνιαίο Κόστος")]
        public decimal RentCost { get; set; }
        //[Required]
        [DisplayName("Περιγραφή")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Κάπνισμα")]
        public bool Smoke { get; set; }
        //[Required]
        [DisplayName("Κατοικίδιο")]
        public bool Animals { get; set; }
        //[Required]
        [DisplayName("Διαθεσιμότητα")]
        public bool Availability { get; set; }
        [Required]
        public int AreaId { get; set; }
        [DisplayName("Περιοχή")]
        public Area Area { get; set; }
        [Required]
        [DisplayName("Διεύθυνση")]
        public string Address { get; set; }
        [Required]
        [DisplayName("Τ.Κ.")]
        public string PostalCode { get; set; }
        [Required]
        public int StateId { get; set; }
        [DisplayName("Νομός")]
        public State State { get; set; }

        public Confirmation IsConfirmed { get; set; } = Confirmation.Pending;
       
        [Required]
        public string UserId { get; set;  }
        public ApplicationUser User { get; set; }
        
    }
}