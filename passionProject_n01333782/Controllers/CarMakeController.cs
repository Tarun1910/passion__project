using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using passionProject_n01333782.Models;
using System.Data.SqlClient;
using passionProject_n01333782.Models.ViewModels;


namespace passionProject_n01333782.Controllers
{
    public class CarMakeController : Controller
    {
        private CarCMSContext db = new CarCMSContext();

        public ActionResult Create()
        {
            return View(db.car_Manufactures.ToList());
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarMake carMake = db.car_Makes.Find(id);
            {
                if (carMake == null)
                {
                    return HttpNotFound();
                }

                return View(carMake);
            }
        }
       
        [HttpPost]
        public ActionResult Create(string modelText, string yearText, string descText, int car_manu)
        {
            string query = "insert into CarMakes (ModelName, ModelYear,Description,CarManufactures_Name_id) values (@Mname, @Myear,@Mdescription,@CarManufacturer)";
            SqlParameter[] myparams = new SqlParameter[4];
            myparams[0] = new SqlParameter("@Mname", modelText);
            myparams[1] = new SqlParameter("@Myear", yearText);
            myparams[2] = new SqlParameter("@Mdescription", descText);
            myparams[3] = new SqlParameter("@CarManufacturer", car_manu);


            db.Database.ExecuteSqlCommand(query, myparams);
            return RedirectToAction("List");
            //return View("List");
        }

        public ActionResult List()
        {
            IEnumerable<CarMake> CarMakes = db.car_Makes.ToList();
            return View(CarMakes);
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CarMake carMake = db.car_Makes.Find(Id);
            if (Id == null)
            {
                return HttpNotFound();
            }
            return View(carMake);            
        }

        public ActionResult Edit(int? id)
        {
            if ((id == null) || (db.car_Makes.Find(id) == null))
            {
                return HttpNotFound();
            }

            //CarMake car_Makes = db.car_Makes.Find(id);
            carMakeEdit carMakeEdit = new carMakeEdit();
            carMakeEdit.carMake = db.car_Makes.Find(id);
            carMakeEdit.carManufactures = db.car_Manufactures.ToList();

            if (carMakeEdit.carMake != null)
                return View(carMakeEdit);
            else
                return HttpNotFound();
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(int? id, string Mname, string year, string Mdesc, int car_manu)
        {
            
            if ((id == null) || (db.car_Makes.Find(id) == null))
            {
                return HttpNotFound();

            }
            string query = "update CarMakes set ModelName=@ModelName, ModelYear=@ModelYear, Description=@Description,CarManufactures_Name_id=@CarManufacturer where ModelID=@id";
            SqlParameter[] myparams = new SqlParameter[5];
            myparams[0] = new SqlParameter("@ModelName", Mname);
            myparams[1] = new SqlParameter("@ModelYear", year);
            myparams[2] = new SqlParameter("@Description", Mdesc);
            myparams[3] = new SqlParameter("@id", id);
            myparams[4] = new SqlParameter("@CarManufacturer", car_manu);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarMake ModelID = db.car_Makes.Find(id);
            db.car_Makes.Remove(ModelID);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}