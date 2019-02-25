using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using passionProject_n01333782.Models;
using System.Web.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Net;




namespace passionProject_n01333782.Controllers
{
    public class CarManufactureController : Controller
    {
        private CarCMSContext db = new CarCMSContext();
        public ActionResult Create()
        {
           
            return View();
        }
        
        public ActionResult Detail (int? id)
        {
            if (id ==null)
            {                
              return new HttpStatusCodeResult(HttpStatusCode.BadRequest);                
            }
            CarManufactures carManufactures = db.car_Manufactures.Find(id);
            {
               if (carManufactures == null)
                {
                    return HttpNotFound();
                }

                return View(carManufactures);
            }
        }
        //actually want to write to db
        [HttpPost]
        public ActionResult Create(string carmaketext, string caryear)        
        {
            //Can I see the information which I just requested?
            Debug.WriteLine(carmaketext + caryear);
            //am I even accessing this function?
            Debug.WriteLine("I got into the create methodd of the carmanufactuerer controller!");
            
            //get all pieces of information that we need to build a carmake
            //generate an mssql query insert into  values **
            //then use db variable and method db.Database.ExecuteSqlCommand
            //Once done, redirect to list
            string query = "insert into CarManufactures (CompanyName, Year) values (@name, @year)";
            SqlParameter[] myparams = new SqlParameter[2];
            myparams[0] = new SqlParameter("@name", carmaketext);
            myparams[1] = new SqlParameter("@year", caryear);
            

            db.Database.ExecuteSqlCommand(query, myparams);

            //return RedirectToAction("View");



                
            
         Debug.WriteLine(query);
            //redirect this to list 
          return RedirectToAction("List");
        }
        public ActionResult Edit(int? id)
        {
            if ((id== null) || (db.car_Manufactures.Find(id) == null))
            {
                return HttpNotFound();
            }

            CarManufactures carManufactures = db.car_Manufactures.Find(id);


            return View(carManufactures);
        }

        [HttpPost,ActionName("Edit")]
        public ActionResult Edit(int? id, string name, string year)
        {
           
            if ((id == null) || (db.car_Manufactures.Find(id) == null))
            {
                return HttpNotFound();

            }
            string query = "update CarManufactures set CompanyName=@CompanyName, Year=@Year where Name_id=@id";
            SqlParameter[] myparams = new SqlParameter[3];
            myparams[0] = new SqlParameter("@CompanyName", name);
            myparams[1] = new SqlParameter("@Year", year);
            myparams[2] = new SqlParameter("@id", id);
            
            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            CarManufactures carManufactures = db.car_Manufactures.Find(Id);
            if (Id == null)
            {
                return HttpNotFound();
            }
            return View(carManufactures);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            string query = "delete from CarMakes where CarManufactures_Name_id= @id";
            db.Database.ExecuteSqlCommand(query, new SqlParameter("@id", id));


            query = "delete from CarManufactures where Name_id= @id";
            db.Database.ExecuteSqlCommand(query, new SqlParameter("@id", id));


            return RedirectToAction("List");
        }


           
        public ActionResult List()
        {

            IEnumerable<CarManufactures> Manufactures = db.car_Manufactures.ToList();
            return View(Manufactures);
            //connnect to DB
            //use either .ToList() or generate a sql query of type "select * from.."
            //return information to the view list.cshtml
            //list.cshtml should be of model type IEnumerable<CarManufacturer>
        }
       // public ActionResult Edit(int? Name_id)
       // {
            
       //     CarManufactures 
        //    else return HttpNotFound();
        //}
    }
}