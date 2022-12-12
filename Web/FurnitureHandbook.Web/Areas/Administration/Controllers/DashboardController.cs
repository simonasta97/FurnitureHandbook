namespace FurnitureHandbook.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;

    using FurnitureHandbook.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class DashboardController : AdministrationController
    {
        public IActionResult Index()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint("Симона", 25));
            dataPoints.Add(new DataPoint("Мартин", 13));
            dataPoints.Add(new DataPoint("Борислав", 8));
            dataPoints.Add(new DataPoint("Елена", 7));
            dataPoints.Add(new DataPoint("Ивайло", 6.8));

            this.ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return this.View();
        }
    }
}
