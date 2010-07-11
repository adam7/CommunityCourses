using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;
using System.IO;
using System;
using System.Drawing;
using CommunityCourses.Web.Model;
using System.Linq;
using System.Collections.Generic;

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
		
		public FileContentResult PeopleChart()
		{
			IList<Person> people = MvcApplication.CurrentSession.Query<Person>("AllPeople").ToList();
			
			int peopleCount = people.Count;
			int studentCount = people.Where(person => person.Roles.Contains(Roles.Student)).Count();
			int volunteerCount = people.Where(person => person.Roles.Contains(Roles.Volunteer)).Count();
			int verifierCount = people.Where(person => person.Roles.Contains(Roles.Verifier)).Count();
			int tutorCount = people.Where(person => person.Roles.Contains(Roles.Tutor)).Count();

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

		public static Chart CreateStandardChart(string title, int width, int height)
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
		
		public static FileContentResult GetChartResultAsImage(Chart chart)
		{
			var imageStream = new MemoryStream();
			chart.SaveImage(imageStream, ChartImageFormat.Png);
			return new FileContentResult(imageStream.ToArray(), "image/png");
		}

		public static void SetLegend(string legendPosition, Chart chart)
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


		public static SeriesChartType GetChartType(string strChart)
		{
			SeriesChartType chartType;
			switch (strChart)
			{
				case "Bar":
					chartType = SeriesChartType.Bar;
					break;

				case "Column":
					chartType = SeriesChartType.Column;
					break;

				case "Pie":
					chartType = SeriesChartType.Pie;
					break;

				case "Line":
					chartType = SeriesChartType.Line;
					break;

				default:
					chartType = SeriesChartType.Bar;
					break;
			}
			return chartType;
		}

	}
}
