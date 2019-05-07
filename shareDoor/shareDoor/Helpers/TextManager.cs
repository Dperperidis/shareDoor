using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using shareDoor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;

namespace shareDoor.Helpers
{
    public class TextManager
    {
        private readonly ApplicationDbContext _ctx;
        public ICollection<IdentityRole> Roles { get; set; }

        public TextManager()
        {
            _ctx = new ApplicationDbContext();
            Roles = _ctx.Roles.ToList();
        }


        public static string GetGender(string gender)
        {
            var gen = "";
            switch (gender.ToLower())
            {
                case "male":
                    gen = "Άνδρας";
                    break;
                case "female":
                    gen = "Γυναίκα";
                    break;
                case "other":
                    gen = "Απροσδιόριστο";
                    break;
            }

            return gen;
        }

        public static int CalculateAge(DateTime theDateTime)
        {
            var age = DateTime.Today.Year - theDateTime.Year;
            if (theDateTime.AddYears(age) > DateTime.Today)
                age--;
  
            
            return age;
        }


        public static string GetSmoker(string smoke)
        {
            var smoker = "";
            switch (smoke.ToLower())
            {
                case "yes":
                    smoker = "Ναι";
                    break;
                case "no":
                    smoker = "Όχι";
                    break;
                case "default":
                    smoker = "Άγνωστο";
                    break;
            }
            return smoker;
        }

        public static string GetPet(string pet)
        {
            var pets = "";
            switch (pet.ToLower())
            {
                case "yes":
                    pets = "Ναι";
                    break;
                case "no":
                    pets = "Όχι";
                    break;
                case "default":
                    pets = "Άγνωστο";
                    break;
            }
            return pets;
        }


        public string FindUserId(string email)
        {
            return _ctx.Users.Single(x => x.Email == email).Id;
        }

        public string GetRole(string userId)
        {
            
            var user = _ctx.Users.Find(userId);
            var roleId = user.Roles.First().RoleId;
            var roleName = Roles.FirstOrDefault(x => x.Id == roleId).Name;

            return roleName;
        }

        public static string MapUrl(string input, string postCode, string area)
        {
            string letters = string.Empty;
            string numbers = string.Empty;
            string numbersInPostCode = string.Empty;

            foreach (char c in input)
            {
                if (Char.IsLetter(c))
                {
                    letters += c;
                }
                if (Char.IsNumber(c))
                {
                    numbers += c;
                }
            }

            foreach(var i in postCode)
            {
                if (char.IsNumber(i))
                {
                    numbersInPostCode += i;
                }
                
            }

            var three = int.Parse(numbersInPostCode) / 100;
            var two = int.Parse(numbersInPostCode) % 100;

            return $"https://www.google.com/maps/place/{letters}+{numbers},+{area}+{three}+{two}";
        }

    }
}