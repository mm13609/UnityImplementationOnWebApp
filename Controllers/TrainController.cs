using CodeFirstTutorial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;
using TrainData;
namespace UnityImplementationOnWebApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TrainController : Controller
    {
        private readonly ITrainRepository _trainRepository;

        public TrainController(ITrainRepository trainRepository)
        {
            _trainRepository = trainRepository;
        }
        // GET: Train
        public ActionResult GetTrains()
        {
            JsonResult jsonResult = new JsonResult();
            jsonResult.Data = _trainRepository.ListTrains();
            jsonResult.ContentType = "application/json";
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonResult;
        }

        public ActionResult CreateTrains()
        {
            return View();
        }

        public ActionResult DisplayTrains()
        {
            return View();
        }

        // GET: Train/Details/5
        public ActionResult Details(int id)
        {
            var train = _trainRepository.GetTrain(id);
            
            return View(train);
        }

        // GET: Train/Create
        //public ActionResult Create(Train train)
        //{
        //    return View(train);
        //}

        // POST: Train/Create
        [HttpPost]
        public ActionResult Create(Train train, TrainStation trainStation)
        {
            try
            {
                // TODO: Add insert logic here
                _trainRepository.Add(train, trainStation);
                //_trainRepository.Add(collection["TrainSymbol"], Convert.ToInt32(collection["Speed"]), collection["stationAddress"], 
                //    collection["Description"]);
                return View("DisplayTrains");
                //return RedirectToAction("DisplayTrains");
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }

        // GET: Train/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Train/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _trainRepository.Edit(id, collection["TrainSymbol"], Convert.ToInt32(collection["Speed"]), collection["Description"]);
                return RedirectToAction("DisplayTrains");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Train/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Train/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _trainRepository.Delete(id);
                return RedirectToAction("DisplayTrains");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
