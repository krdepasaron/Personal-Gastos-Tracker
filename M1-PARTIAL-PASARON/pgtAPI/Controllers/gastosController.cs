using PGTLibrary.Data;
using PGTLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace pgtAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class gastosController :ControllerBase
    {
        private ISqlData _db;

        public gastosController(ISqlData db)
        {
            _db = db;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult listgastos()
        {
            List<listgastos> gastos = _db.listgastos();
            return Ok(gastos);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/[controller]/{dateAdded}")]

        public ActionResult showgastosdetails(DateOnly dateAdded)
        {
            listgastos gastos = _db.showgastosdetails(dateAdded);

            return Ok(gastos);
        }

        private int GetCurrentUserId()
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;
                string id = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                if (id != null)
                {
                    return Convert.ToInt32(id);
                }
            }
            return 0;
        }
        [Authorize]
        [HttpPost]
        [Route("/api/[controller]/insertgastos")]
        public ActionResult addgastos([FromBody] gastosform form)
        {
            lagaymodel gastos = new lagaymodel();
            gastos.GastosName = form.GastosName;
            gastos.Code = form.Code;
            gastos.Brand = form.Brand;
            gastos.Remarks = form.Remarks;
            gastos.GastosType = form.GastosType;
            gastos.dateAdded = DateTime.Now;
            gastos.Price = form.Price;
            gastos.userId = GetCurrentUserId();
            _db.addgastos(gastos);

            return Ok("Post created.");
        }


    }
}
