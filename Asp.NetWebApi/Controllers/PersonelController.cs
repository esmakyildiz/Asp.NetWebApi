using Asp.NetWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Asp.NetWebApi.Controllers
{
    public class PersonelController : ApiController
    {
        private List<Personel> listPersoneller =new List<Personel>
        
        {
            new Personel{Id=1, Ad="Ali", Soyad="Hazır"},
            new Personel{Id=2, Ad="Osman", Soyad="Hazır"},
            new Personel{Id=3, Ad="Toprak", Soyad="Erzurumluoğlu"}
        };

        public IEnumerable<Personel> GetPersoneller()
        {
            return listPersoneller;
        }
        public IHttpActionResult GetPersonel(int id)
        {
            var arananPersonel = (from p in listPersoneller
                                  where p.Id == id
                                  select p).FirstOrDefault();
            return Ok(arananPersonel);
        }

        public IHttpActionResult PostPersonel(Personel per)
        {
            if(listPersoneller.Where(p => p.Id == per.Id).Count() == 0)
            {
                return Ok();
            }
            else
            {
                return Conflict();
            }
        }
    }
}
