using shareDoor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shareDoor.ViewModels
{

    public class AdFormViewModel
    {
        public int Id { get; set; }
        public ICollection<State> States { get; set; }
        public ICollection<Area> Areas { get; set; }

        [Required]
        [Range(10,200,ErrorMessage = "Η τιμή πρέπει να είναι από 10 έως 200")]
        [DisplayName("Τετραγωνικά μέτρα *")]
        public byte SquareMeters { get; set; }
        [Required]
        [DisplayName("Όροφος")]
        public Level Level { get; set; }
        [DisplayName("Έτος κατασκευής")]
        public DateTime YearConstruct { get; set; }
        [Required]
        [DisplayName("Δωμάτια")]
        public Rooms TotalRooms { get; set; }
        [Required]
        [DisplayName("Μηνιαίο Κόστος")]
        public int RentCost { get; set; }
        [DisplayName("Περιγραφή")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Κάπνισμα")]
        public string Smoker { get; set; }
        [Required]
        [DisplayName("Κατοικίδιο")]
        public string Pets { get; set; }
        //[Required]
        [DisplayName("Διαθεσιμότητα")]
        public bool Availability { get; set; }
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
        [Required]
        [DisplayName("Νομός *")]
        public int StateId { get; set; }
        public State State { get; set; }
        [Required]
        [DisplayName("Φύλο")]
        public string Gender { get; set; }

        public Confirmation IsConfirmed { get; set; } 

        public HttpPostedFileBase[] Files { get; set; }
        public ICollection<HousePhoto> HousePhotos { get; set; }

        public AdFormViewModel()
        {
            States = new Collection<State>();
            Areas = new Collection<Area>();
            HousePhotos = new Collection<HousePhoto>();
        }
    }
}