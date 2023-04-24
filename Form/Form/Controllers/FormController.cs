using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form.Controllers
{
    public class FormController : Controller
    {
        FormManager fm = new FormManager(new EfFormRepository());
        public IActionResult Index()
        {
            var value = fm.GetList();
            return View(value);
        }

        public IActionResult forms(int id)
        {
            var value = fm.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult AddForm(EntityLayer.Concrete.Form p)
        {
            UserManager um = new UserManager(new EfUserRepository());
            var userName = User.Identity.Name;

            p.CreatedBy = um.GetList().Where(x => x.Username == userName).Select(y => y.Id).FirstOrDefault();
            p.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Description = $@"<form method='post'>
            <div class='form-group'>
                <label>Ad</label>
                <input type='text' class='form-control' name='name' required=''>
            </div>
            <div class='form-group'>
                <label>Soyad</label>
                <input type='text' class='form-control' name='surname' required=''>
            </div>
            <div class='form-group'>
                <label>Yaş</label>
                <input type='number' class='form-control' name='age' required=''>
            </div>
            <button type='submit' class='btn btn-primary'>Kaydet</button>
            </form>";

            fm.Add(p);

            return RedirectToAction("Index","Form");
        }
    }
}
