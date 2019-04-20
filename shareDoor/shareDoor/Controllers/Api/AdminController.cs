using shareDoor.Data;
using shareDoor.Models;
using System;

using System.Web.Http;

namespace shareDoor.Controllers.Api
{
    public class AdminController : ApiController
    {

        private readonly ApplicationDbContext _ctx;

        public AdminController()
        {
            _ctx = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult SetConfirmation(int Id, int confirmation)
        {
            try
            {
                var result = Confirmation.Pending;
                switch (confirmation)
                {
                    case 0:
                        result = Confirmation.Pass;
                        break;
                    case 1:
                        result = Confirmation.Pending;
                        break;
                    case 2:
                        result = Confirmation.Cancel;
                        break;
                }

                var confirm = _ctx.Houses
                            .Find(Id);

                confirm.IsConfirmed = result;
                _ctx.SaveChanges();

                return Ok(result);
            }

            catch (Exception ex)
            {

                throw new ArgumentException();
            }

            
        }
      
    }
}
