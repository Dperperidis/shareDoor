using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        Cancel,
        All


    }

    public enum Rooms
    {
        [Display(Name = "Στούντιο")]
        studio,
        [Display(Name = "Ένα")]
        one,
        [Display(Name = "Δύο")]
        two,
        [Display(Name = "Τρία")]
        three,
        [Display(Name = "Τέσσερα")]
        four
    }

    public class House
    {
        public int Id { get; set; }
        [Required]
        [Range(10,200 , ErrorMessage ="Η τιμή πρέπει να είναι από 10 εώς 200")]
        [DisplayName("Τετραγωνικά μέτρα")]
        public byte SquareMeters { get; set; }
        [Required]
        [DisplayName("Όροφος *")]
        public Level Level { get; set; }
        [DisplayName("Έτος κατασκευής")]
        public DateTime YearConstruct { get; set; }
        [Required]
        [DisplayName("Δωμάτια")]
        public Rooms TotalRooms { get; set; }
        [Required]
        [DisplayName("Μηνιαίο Κόστος *")]
        public int RentCost { get; set; }
        [DisplayName("Περιγραφή")]
        public string Description { get; set; }
        //[DisplayName("Κάπνισμα")]
        public string Smoker { get; set; }
        //[DisplayName("Κατοικίδιο")]
        public string Pets { get; set; }
        //[Required]
        [DisplayName("Διαθεσιμότητα")]
        public bool Availability { get; set; } = true;
        [Required]
        [DisplayName("Περιοχή *")]
        public int AreaId { get; set; }    
        public Area Area { get; set; }
        [Required]
        [DisplayName("Διεύθυνση *")]
        public string Address { get; set; }
        [Required]
        [DisplayName("Τ.Κ. *")]
        public string PostalCode { get; set; }    
        [DisplayName("Νομός *")]
        public int StateId { get; set; }     
        public State State { get; set; }
        //[DisplayName("Φύλο")]
        public string Gender { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public Confirmation IsConfirmed { get; set; } = Confirmation.Pending;
       
        public string UserId { get; set;  }
        public ApplicationUser User { get; set; }
        public ICollection<HousePhoto> HousePhotos { get; set; }

        public House()
        {
            HousePhotos = new Collection<HousePhoto>();
        }

    }
}