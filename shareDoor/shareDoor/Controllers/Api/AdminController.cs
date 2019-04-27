using shareDoor.Data;
using shareDoor.Dto;
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
        public IHttpActionResult SetConfirmation(PublishDto dto)
        {
            try
            {

                AlertDto alert = new AlertDto();
               

                var result = Confirmation.Pending;
                switch (dto.Confirmation)
                {
                    case 0:
                        result = Confirmation.Pass;
                        alert.AlertClass = "success";
                        alert.AlertText = "Δημοσιευμένη";
                        break;
                    case 1:
                        result = Confirmation.Pending;
                        alert.AlertClass = "warning";
                        alert.AlertText = "Εκκρεμών";
                        break;
                    case 2:
                        result = Confirmation.Cancel;
                        alert.AlertClass = "danger";
                        alert.AlertText = "Απορριφθείσα";
                        break;
                }

                var confirm = _ctx.Houses
                            .Find(dto.Id);

                confirm.IsConfirmed = result;
                _ctx.SaveChanges();

                return Ok(alert);
            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            
        }
      
    }
}
