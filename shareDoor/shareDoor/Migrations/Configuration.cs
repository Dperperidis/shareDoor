using shareDoor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace shareDoor.Migrations
{
   
    internal sealed class Configuration : DbMigrationsConfiguration<shareDoor.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }



        protected override void Seed(shareDoor.Data.ApplicationDbContext context)
        {

            //context.Roles.AddOrUpdate(x => x.Name,
            //    new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            //    {
            //        Name = "Admin"
            //    },
            //    new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            //    {
            //        Name = "Member"
            //    },
            //    new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            //    {
            //        Name = "Silver Member"
            //    } ,
            //    new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            //    {
            //        Name = "Gold Member"
            //    });

            //    context.States.AddOrUpdate(x => x.Id,

            //new Models.State

            //{
            //    Name = "Αθήνα-Κέντρο",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Γουδή"},
            //        new Area(){Name = "Ιλίσια"},
            //        new Area(){Name = "Κυψέλη"},
            //        new Area(){Name = "Πατησίων-Αχαρνών"},
            //        new Area(){Name = "Νέος Κόσμος"},
            //        new Area(){Name = "Πατήσια"},
            //        new Area(){Name = "Πετράλωνα"},
            //        new Area(){Name = "Κέντρο"},
            //        new Area(){Name = "Αμπελόκηποι"},
            //        new Area(){Name = "’νω Πατήσια"},
            //        new Area(){Name = "Αττική"},
            //        new Area(){Name = "Γκάζι - Μεταξουργείο-Βοτανικός"},
            //        new Area(){Name = "Γκύζη - Πεδίον ’ρεως"},
            //        new Area(){Name = "Εξάρχεια"},
            //        new Area(){Name = "Ιστορικό Κέντρο"},
            //        new Area(){Name = "Κολωνάκι - Λυκαβηττός"},
            //        new Area(){Name = "Κολωνός"},
            //        new Area(){Name = "Κουκάκι"},
            //        new Area(){Name = "Μέτς-Καλλιμαρμάρο"},
            //        new Area(){Name = "Παγκράτι"},
            //        new Area(){Name = "Σεπόλια"}

            //    }

            //},

            //new Models.State

            //{
            //    Name = "Αθήνα-Βόρεια Προάστια",
            //    Areas = new List<Area>()
            //     {
            //        new Area(){Name = "’γιος Στέφανος"},
            //        new Area(){Name = "Αγία Παρασκευή"},
            //        new Area(){Name = "’νοιξη"},
            //        new Area(){Name = "Βριλήσσια"},
            //        new Area(){Name = "Διόνυσος"},
            //        new Area(){Name = "Δροσιά"},
            //        new Area(){Name = "Εκάλη"},
            //        new Area(){Name = "Ηράκλειο"},
            //        new Area(){Name = "Κηφισιά"},
            //        new Area(){Name = "Κρυονέρι"},
            //        new Area(){Name = "Λυκόβρυση"},
            //        new Area(){Name = "Μελίσσια"},
            //        new Area(){Name = "Νέο Ψυχικό"},
            //        new Area(){Name = "Παλαιό Ψυχικό"},
            //        new Area(){Name = "Παπάγου"},
            //        new Area(){Name = "Πεντέλη"},
            //        new Area(){Name = "Πεύκη"},
            //        new Area(){Name = "Ροδόπης"},
            //        new Area(){Name = "Σταμάτα"},
            //        new Area(){Name = "Φιλοθέη"},
            //        new Area(){Name = "Χολαργός"},


            //     }

            //},

            //new Models.State

            //{

            //    Name = "Αθήνα-Νότια Προάστια",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "’γιος Δημήτριος"},
            //        new Area(){Name = "’λιμος"},
            //        new Area(){Name = "Αργυρούπολη"},
            //        new Area(){Name = "Βάρη-Βάρκιζα"},
            //        new Area(){Name = "Βούλα"},
            //        new Area(){Name = "Βουλιαγμένη"},
            //        new Area(){Name = "Βύρωνας"},
            //        new Area(){Name = "Γλυφάδα"},
            //        new Area(){Name = "Δάφνη"},
            //        new Area(){Name = "Ελληνικό"},
            //        new Area(){Name = "Ζωγράφου"},
            //        new Area(){Name = "Ηλιούπολη"},
            //        new Area(){Name = "Καισαρινή"},
            //        new Area(){Name = "Καλλιθέα"},
            //        new Area(){Name = "Νέα Σμύρνη"},
            //        new Area(){Name = "Παλαιό Φάληρο"},
            //        new Area(){Name = "Υμηττός"}


            //    }

            //},

            //new Models.State

            //{

            //    Name = "Αθήνα-Δυτικά Προάστια",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Αγία Βαρβάρα"},
            //        new Area(){Name = "’γιοι Ανάργυροι"},
            //        new Area(){Name = "Αιγάλεω"},
            //        new Area(){Name = "Αχαρναί - Μενίδι"},
            //        new Area(){Name = "Γαλάτσι"},
            //        new Area(){Name = "Θρακομακεδόνες"},
            //        new Area(){Name = "Ίλιον"},
            //        new Area(){Name = "Καματερό"},
            //        new Area(){Name = "Μεταμόρφωση"},
            //        new Area(){Name = "Νέα Ιωνία"},
            //        new Area(){Name = "Νέα Φιλαδέλφεια"},
            //        new Area(){Name = "Νέα Χαλκηδόνα"},
            //        new Area(){Name = "Περιστέρι"},
            //        new Area(){Name = "Πετρούπολη"},
            //        new Area(){Name = "Χαϊδάρι"},
            //        new Area(){Name = "Βαρθμπόμπη"}

            //    }
            //},
            //new Models.State

            //{

            //    Name = "Αθήνα-Ανατολικά Προάστια",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Ανθούσα"},
            //        new Area(){Name = "Αρτέμιδα"},
            //        new Area(){Name = "Γέρακας"},
            //        new Area(){Name = "Γλυκά Νερά"},
            //        new Area(){Name = "Κορωπί"},
            //        new Area(){Name = "Μαραθώνας"},
            //        new Area(){Name = "Νέα Μάκρη"},
            //        new Area(){Name = "Παιανία"},
            //        new Area(){Name = "Παλλήνη"},
            //        new Area(){Name = "Σπάτα"},
            //        new Area(){Name = "Βαρνάβας"},
            //        new Area(){Name = "Γραμματικό"}

            //    }
            //},
            //new Models.State

            //{
            //    Name = "Αναλυτική Αττική-Υπόλοιπο",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "’γιος Κωνσταντίνος"},
            //        new Area(){Name = "Αλεποχώρι"},
            //        new Area(){Name = "Ανάβυσσος"},
            //        new Area(){Name = "Αυλώνα"},
            //        new Area(){Name = "Ζεφύρι"},
            //        new Area(){Name = "Καπανδρίτι"},
            //        new Area(){Name = "Μαλακάσα"},
            //        new Area(){Name = "Κάλαμος"},
            //        new Area(){Name = "Καλύβια"},
            //        new Area(){Name = "Κερατέα"},
            //        new Area(){Name = "Κινέτα"},
            //        new Area(){Name = "Λαύριο"},
            //        new Area(){Name = "Λεγρενά"},
            //        new Area(){Name = "Μαρκόπουλο"},
            //        new Area(){Name = "Νέα Πέραμος"},
            //        new Area(){Name = "Παλαιά Φώκαια"},
            //        new Area(){Name = "Πικέρμι"},
            //        new Area(){Name = "Πολυδένδρι"},
            //        new Area(){Name = "Πόρτο Γερμενό"},
            //        new Area(){Name = "Πόρτο Ράφτη"},
            //        new Area(){Name = "Ραφήνα"},
            //        new Area(){Name = "Σαρωνίδα"},
            //        new Area(){Name = "Σούνιο"},
            //        new Area(){Name = "Ωρωπός"}

            //    }
            //},
            //new Models.State

            //{

            //    Name = "Δυτική Αττική- Υπόλοιπο",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "’νω Λιόσια"},
            //        new Area(){Name = "Απρόπυργος"},
            //        new Area(){Name = "Βίλια"},
            //        new Area(){Name = "Ελευσίνα"},
            //        new Area(){Name = "Μαγούλα"},
            //        new Area(){Name = "Μάνδρα"},
            //        new Area(){Name = "Μέγαρα"},
            //        new Area(){Name = "Οινόη"},
            //        new Area(){Name = "Φύλη"}

            //    }
            //},

            //new Models.State

            //{

            //    Name = "Πειραιάς",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Κέντρο"},
            //        new Area(){Name = "Αγία Σοφία"},
            //        new Area(){Name = "Καμίνια"},
            //        new Area(){Name = "Καστέλα"},
            //        new Area(){Name = "Λιμάνι"},
            //        new Area(){Name = "Παλαιά Κοκκινιά"},
            //        new Area(){Name = "Πασαλιμάνι"},
            //        new Area(){Name = "Τερψιθέα"},
            //        new Area(){Name = "Αγιος Ιωάννης - Ρέντης"},
            //        new Area(){Name = "Δραπετζώνα"},
            //        new Area(){Name = "Κερατσίνι"},
            //        new Area(){Name = "Κορυδαλλός"},
            //        new Area(){Name = "Μοσχάτο"},
            //        new Area(){Name = "Νίκαια"},
            //        new Area(){Name = "Πέραμα"},
            //        new Area(){Name = "Ταύρος"}

            //    }
            //},

            //new Models.State

            //{

            //    Name = "Θεσσαλονίκη -Κέντρο",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "’γιος Δημήτριος"},
            //        new Area(){Name = "Ανάληψη"},
            //        new Area(){Name = "’νω Τούμπα"},
            //        new Area(){Name = "Βαρδάρης"},
            //        new Area(){Name = "Βυζάντιο"},
            //        new Area(){Name = "Δόξα"},
            //        new Area(){Name = "Ευαγγελιστρία"},
            //        new Area(){Name = "Ιπποκράτιο"},
            //        new Area(){Name = "Καμάρα"},
            //        new Area(){Name = "Κάτω Τούμπα"},
            //        new Area(){Name = "Κέντρο"},
            //        new Area(){Name = "Κωνσταντινοπολίτικα"},
            //        new Area(){Name = "Λαδάδικα"},
            //        new Area(){Name = "Λευκός Πύργος"},
            //        new Area(){Name = "Λιμάνι"},
            //        new Area(){Name = "Νέα Παραλία"},
            //        new Area(){Name = "Φάληρο"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Θεσσαλονίκη - Περιφ/κοι Δήμοι",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Αμπελόκηποι"},
            //        new Area(){Name = "Εύοσμος"},
            //        new Area(){Name = "Θερμαϊκός"},
            //        new Area(){Name = "Θέρμη"},
            //        new Area(){Name = "Καλαμαριά"},
            //        new Area(){Name = "Μενεμένη"},
            //        new Area(){Name = "Νεάπολη"},
            //        new Area(){Name = "Πανόραμα"},
            //        new Area(){Name = "Πεύκα"},
            //        new Area(){Name = "Πολίχνη"},
            //        new Area(){Name = "Πυλαία"},
            //        new Area(){Name = "Συκιές"},
            //        new Area(){Name = "Χορτιάτης"},
            //        new Area(){Name = "Ωραιόκαστρο"},
            //        new Area(){Name = "Βασιλικά"},
            //        new Area(){Name = "Καλλιθέα"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Θεσσαλονίκη - Υπολ.Νομου",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "’γιος Αθανάσιος"},
            //        new Area(){Name = "Εγνατία"},
            //        new Area(){Name = "Λαγκαδάς"},
            //        new Area(){Name = "Λαχανάς"},
            //        new Area(){Name = "Χαλκηδόνα"}

            //    }
            //},
            //new Models.State

            //{
            //    Name = "Ν.Αιτωλοακαρνανίας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Αγρίνιο"},
            //        new Area(){Name = "Αντίρριο"},
            //        new Area(){Name = "Μεσολόγγι"},
            //        new Area(){Name = "Ναύπακτος"}
            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Αργολίδας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "’ργος"},
            //        new Area(){Name = "Ναύπλιο"}
            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Αρκαδίας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Βυτίνα"},
            //        new Area(){Name = "Δημητσάνα"},
            //        new Area(){Name = "Τρίπολη"}
            //    }
            //},
            //new Models.State

            //{
            //    Name = "Ν.’ρτας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "’ρτα"}
            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Αχαΐας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Αίγιο"},
            //        new Area(){Name = "Ακράτα"},
            //        new Area(){Name = "Καλάβρυτα"},
            //        new Area(){Name = "Πάτρα"},
            //        new Area(){Name = "Ρίο"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Βοιωτίας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Θήβα"},
            //        new Area(){Name = "Σχηματάρι"}

            //    }
            //},
            //new Models.State

            //{
            //    Name = "Ν.Γρεβενών",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Γρεβενά"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Δράμας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Δράμα"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Έβρου",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Αλεξανδούπολη"},
            //        new Area(){Name = "Σαμοθράκη"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Έβρου",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Κάλυμνος"},
            //        new Area(){Name = "Πάτμος"},
            //        new Area(){Name = "Ρόδος"},
            //        new Area(){Name = "Κώς"},
            //        new Area(){Name = "Ρόδος"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Ευβοίας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Χαλκίδα"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Ευρυτανίας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Καρπενήσι"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Ζακύνθου",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Χώρα"},
            //        new Area(){Name = "Λαγανάς"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Ηλείας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Αμαλιάδα"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Ημαθίας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Βέροια"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Θεσπρωτίας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Ηγουμενίτσα"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Ιωαννίνων",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Ιωάννινα"},
            //        new Area(){Name = "Μέτσοβο"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Καβάλας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Καβάλα"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Καρδίτσας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Καρδίτσα"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Καστοριάς",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Καστοριά"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Κερκύρας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Κέρκυρα"},
            //        new Area(){Name = "Παξοί"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Κεφαλλονίας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Κεφαλλονιά"},
            //        new Area(){Name = "Ιθάκη"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Κιλκίς",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Κικλίς"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Κοζάνης",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Κοζάνη"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Κορινθίας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Κόρινθος"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Κορινθίας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Κέα"},
            //        new Area(){Name = "Κίμωλος"},
            //        new Area(){Name = "Κουφονήσια"},
            //        new Area(){Name = "Κύθνος"},
            //        new Area(){Name = "Μήλος"},
            //        new Area(){Name = "Μύκονος"},
            //        new Area(){Name = "Πάρος"},
            //        new Area(){Name = "Σέριφος"},
            //        new Area(){Name = "Σίφνος"},
            //        new Area(){Name = "Νάξος"},
            //        new Area(){Name = "Σαντορίνη"},
            //        new Area(){Name = "Τήνος"},
            //        new Area(){Name = "’νδρος"},
            //        new Area(){Name = "Σύρος"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Λακωνίας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Σπάρτη"},
            //        new Area(){Name = "Κύθηρα"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Λάρισας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Λάρισα"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Λέσβου",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Λέσβος"},
            //        new Area(){Name = "Λήμνος"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Λευκάδας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Λευκάδα"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Μαγνησίας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Βόλος"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Μεσσηνίας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Καλαμάτα"},
            //        new Area(){Name = "Πύλος"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Ξάνθης",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Ξάνθη"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Πέλλας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Γιαννιτσά"},
            //        new Area(){Name = "Έδεσσα"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Πιερίας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Πιερία"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Πρέβεζας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Πρέβεζα"},
            //        new Area(){Name = "Πάργα"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Ροδόπης",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Κομμοτηνή"}
            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Σάμου",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Σάμος"},
            //        new Area(){Name = "Ικαρία"}
            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Σερρών",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Σέρρες"}
            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Τρικάλων",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Τρίκαλα"}
            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Φθιώτιδας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Λαμία"},
            //        new Area(){Name = "Στυλίδα"}
            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Φλώρινας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Πρέσπες"},
            //        new Area(){Name = "Φλώρινα"}
            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Φωκίδας",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "’μφισσα"}
            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Χαλκιδικής",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Παλλήνη"}
            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Χίου",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Χίος"}
            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Ηρακλείου",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Ηράκλειο"},
            //        new Area(){Name = "Γούβες"},
            //        new Area(){Name = "Ζάρος"},
            //        new Area(){Name = "Ρούβας"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Ρεθύμνου",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Ρέθυμνο"},
            //        new Area(){Name = "Λάππα"},
            //        new Area(){Name = "Φοίνικας"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Λασιθίου",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "’γιος Νικόλαος"},
            //        new Area(){Name = "Ιεράπετρα"},
            //        new Area(){Name = "Σητεία"}

            //    }
            //},

            //new Models.State

            //{
            //    Name = "Ν.Χανίων",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Ακρωτήρι"},
            //        new Area(){Name = "Γαύδος"},
            //        new Area(){Name = "Νέα Κυδωνία"},
            //         new Area(){Name = "Πλατανιάς"},
            //        new Area(){Name = "Χανιά"},
            //        new Area(){Name = "Σούδα"},
            //         new Area(){Name = "Σφακιά"},
            //        new Area(){Name = "Φρέ"}
            //    }
            //},

            //new Models.State

            //{
            //    Name = "Νησιά Αργοσαρωνικού",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Σαλαμίνα"},
            //        new Area(){Name = "Αίγινα"},
            //        new Area(){Name = "Πόρος"},
            //         new Area(){Name = "Σπέτσες"},
            //        new Area(){Name = "Ύδρα"}
            //    }
            //},

            //new Models.State

            //{
            //    Name = "Σποράδες",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Σκύρος"},
            //        new Area(){Name = "Αλόνησος"},
            //        new Area(){Name = "Σκιάθος"},
            //         new Area(){Name = "Σκόπελος"}
            //    }
            //},

            //new Models.State

            //{
            //    Name = "Κύπρος",
            //    Areas = new List<Area>()
            //    {
            //        new Area(){Name = "Λάρνακα"},
            //        new Area(){Name = "Λεμεσός"},
            //        new Area(){Name = "Λευκωσία"},
            //        new Area(){Name = "Πάφος"},
            //        new Area(){Name = "Αμμόχωστος"}
            //    }
            //});
        }
    }
}
