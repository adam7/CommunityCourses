using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;
using CommunityCourses.Web.Indexes;
using CommunityCourses.Web.Model;

namespace CommunityCourses.Web.Controllers
{
	[HandleError]
	[Authorize]
	public partial class HomeController : Controller
	{
		public virtual ActionResult Index()
		{
			return View();
		}

		public virtual FileContentResult PeopleChart()
		{
			int peopleCount = MvcApplication.CurrentSession.Query<Person>(new People_All().IndexName).Count();
			int studentCount = MvcApplication.CurrentSession.LuceneQuery<RoleCount>(new PeopleCount_ByRole().IndexName)
				.Where("Role:" + Roles.Student).First().Count;
			int volunteerCount = MvcApplication.CurrentSession.LuceneQuery<RoleCount>(new PeopleCount_ByRole().IndexName)
				.Where("Role:" + Roles.Volunteer).First().Count;
			int verifierCount = MvcApplication.CurrentSession.LuceneQuery<RoleCount>(new PeopleCount_ByRole().IndexName)
				.Where("Role:" + Roles.Verifier).First().Count;
			int tutorCount = MvcApplication.CurrentSession.LuceneQuery<RoleCount>(new PeopleCount_ByRole().IndexName)
				.Where("Role:" + Roles.Tutor).First().Count;			

			int[] yValues = { peopleCount, studentCount, volunteerCount, verifierCount, tutorCount };
			string[] xValues = { "All people", "Students", " Volunteers", " Verifiers", " Tutors" };

			var chart = CreateStandardChart("People and their roles", 500, 400);

			Series series = new Series("Default")
			{
				ChartType = SeriesChartType.Column,
				CustomProperties = "Label = Top, DrawingStyle = Cylinder",
				Label = "#VALY",
				ShadowOffset = 3
			};

			series.Points.DataBindXY(xValues, yValues);
			
			chart.Series.Add(series);

			chart.ChartAreas.Add("Default");
			chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
			chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

			return GetChartResultAsImage(chart);
		}

		static Chart CreateStandardChart(string title, int width, int height)
		{
			var chart = new Chart();
			chart.RenderType = RenderType.BinaryStreaming;
			chart.AntiAliasing = AntiAliasingStyles.All;
			chart.Palette = ChartColorPalette.Pastel;
			chart.Titles.Add(title);
			chart.Width = width;
			chart.Height = height;
			
			return chart;
		}

		static FileContentResult GetChartResultAsImage(Chart chart)
		{
			var imageStream = new MemoryStream();
			chart.SaveImage(imageStream, ChartImageFormat.Png);
			return new FileContentResult(imageStream.ToArray(), "image/png");
		}

		void SetLegend(string legendPosition, Chart chart)
		{
			if (!String.IsNullOrWhiteSpace(legendPosition))
			{
				chart.Legends.Add("Legend1");

				switch (legendPosition)
				{
					case "Bottom":
						chart.Legends["Legend1"].Docking = Docking.Bottom;
						break;

					case "Left":
						chart.Legends["Legend1"].Docking = Docking.Left;
						break;

					case "Right":
						chart.Legends["Legend1"].Docking = Docking.Right;
						break;

					case "Top":
						chart.Legends["Legend1"].Docking = Docking.Top;
						break;

					default:
						break;
				}
			}
		}
	}
}
