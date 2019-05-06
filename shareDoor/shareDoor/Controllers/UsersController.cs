using Microsoft.AspNet.Identity;
using shareDoor.Data;
using shareDoor.Models;
using shareDoor.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace shareDoor.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {

        private readonly ApplicationDbContext _ctx;
        CloudinaryService service = new CloudinaryService();

        public UsersController()
        {
            _ctx = new ApplicationDbContext();
        }


        public ActionResult GetProfile()
        {
            var userId = User.Identity.GetUserId();

            var message = TempData["Message"] as string;
            if (message == null)
            {
                TempData["Message"] = "";
            }
            var user = _ctx.Users
                .Include(x => x.UserPhotos)
                .Include("Houses")
                .Include("Houses.Area")
                .Include("Houses.State")
                .Include("Houses.HousePhotos")
                .Single(x => x.Id == userId);

            var age = CalculateAge(user.DateOfBirth.Value);

            var userVM = new UserProfileViewModel
            {
                User = user,
                Age = age

            };


            return View("Profile", userVM);
        }

        public static int CalculateAge(DateTime theDateTime)
        {
            var age = DateTime.Today.Year - theDateTime.Year;
            if (theDateTime.AddYears(age) > DateTime.Today)
                age--;
            return age;
        }

        [HttpPost]
        public ActionResult UpdateUser(UserProfileViewModel userUpdate)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var userToUpdate = _ctx.Users.Find(userId);
                if (userId == null)
                {
                    throw new UnauthorizedAccessException(message: "Δεν έχεις πρόσβαση");
                }

                var user = _ctx.Users
                    .Include(x => x.UserPhotos).
                    Single(x => x.Id == userId).UserPhotos;

                var isMain = user.Any(x => x.IsMain == true);
                if (isMain && (userUpdate.Files[0] != null))
                {
                    foreach (var file in userUpdate.Files)
                    {
                        var result = service.UploadImage(file);
                        var url = result.Uri.ToString();
                        UserPhoto photo = new UserPhoto
                        {
                            Url = url,
                            IsMain = false
                        };
                        userToUpdate.UserPhotos.Add(photo);
                    }

                }
                else
                {
                    if (userUpdate.Files[0] != null)
                    {
                        for (int i = 0; i < userUpdate.Files.Length; i++)
                        {
                            var result = service.UploadImage(userUpdate.Files[i]);
                            var url = result.Uri.ToString();
                            if (i == 0)
                            {
                                UserPhoto photo = new UserPhoto
                                {
                                    Url = url,
                                    IsMain = true
                                };
                                userToUpdate.UserPhotos.Add(photo);
                            }
                            else
                            {
                                UserPhoto photo = new UserPhoto
                                {
                                    Url = url,
                                    IsMain = false
                                };
                                userToUpdate.UserPhotos.Add(photo);
                            }

                        }
                    }
                }
                userToUpdate.FirstName = userUpdate.User.FirstName;
                userToUpdate.LastName = userUpdate.User.LastName;
                userToUpdate.Pets = userUpdate.User.Pets;
                userToUpdate.Smoker = userUpdate.User.Smoker;
                userToUpdate.Gender = userUpdate.User.Gender;
                userToUpdate.UserDescription = userUpdate.User.UserDescription;
                userToUpdate.PhoneNumber = userUpdate.User.PhoneNumber;
                userToUpdate.DateOfBirth = userUpdate.User.DateOfBirth;
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, $"{ex.Message}");
            }

            return RedirectToAction("GetProfile");
        }
    }




}