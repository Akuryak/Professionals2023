using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Axes;
using TerminalDivisionEmployee.Models;

namespace TerminalDivisionEmployee.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
        }

        private void VisitsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(Environment.SpecialFolder.MyDocuments + "/Отчеты ТБ"))
            {
                Directory.CreateDirectory(Environment.SpecialFolder.MyDocuments + "/Отчеты ТБ");
            }
            List<Division> divisions = Helpers.ApiRequests.GetList<Division>("http://localhost:8080/getDivision");
            PlotModel dayModel = new PlotModel() { Title = "День"};
            foreach (Division division in divisions)
            {
                OxyPlot.Series.LineSeries line = new OxyPlot.Series.LineSeries()
                {
                    Title = $"Количество посетителей в {division.Name}",
                    StrokeThickness = 1
                };
                foreach (Visit visit in Helpers.ApiRequests.GetList<Visit>("http://localhost:8080/getVisit").Where(x=>x.VisitDate.Date.CompareTo(DateTime.Now.Date) == 0).OrderBy(x=>x.VisitDate))
                {
                    line.Points.Add(new DataPoint(DateTimeAxis.ToDouble(visit.VisitDate), 1));
                }
            }
            using (var stream = File.Create(Environment.SpecialFolder.MyDocuments + "/Отчеты ТБ/График отчет за день"))
            {
                var pdfExporter = new PdfExporter { Width = 600, Height = 400 };
                pdfExporter.Export(dayModel, stream);
            }

            PlotModel monthModel = new PlotModel() { Title = "Месяц" };
            foreach (Division division in divisions)
            {
                OxyPlot.Series.LineSeries line = new OxyPlot.Series.LineSeries()
                {
                    Title = $"Количество посетителей в {division.Name}",
                    StrokeThickness = 1
                };
                foreach (Visit visit in Helpers.ApiRequests.GetList<Visit>("http://localhost:8080/getVisit").Where(x => x.VisitDate.Date.Month.CompareTo(DateTime.Now.Date.Month) == 0).OrderBy(x => x.VisitDate))
                {
                    line.Points.Add(new DataPoint(DateTimeAxis.ToDouble(visit.VisitDate), 1));
                }
            }
            using (var stream = File.Create(Environment.SpecialFolder.MyDocuments + "/Отчеты ТБ/График отчет за месяц"))
            {
                var pdfExporter = new PdfExporter { Width = 600, Height = 400 };
                pdfExporter.Export(monthModel, stream);
            }

            PlotModel yearModel = new PlotModel() { Title = "Год" };
            foreach (Division division in divisions)
            {
                OxyPlot.Series.LineSeries line = new OxyPlot.Series.LineSeries()
                {
                    Title = $"Количество посетителей в {division.Name}",
                    StrokeThickness = 1
                };
                foreach (Visit visit in Helpers.ApiRequests.GetList<Visit>("http://localhost:8080/getVisit").Where(x => x.VisitDate.Date.Year.CompareTo(DateTime.Now.Date.Year) == 0).OrderBy(x => x.VisitDate))
                {
                    line.Points.Add(new DataPoint(DateTimeAxis.ToDouble(visit.VisitDate), 1));
                }
            }
            using (var stream = File.Create(Environment.SpecialFolder.MyDocuments + "/Отчеты ТБ/График отчет за год"))
            {
                var pdfExporter = new PdfExporter { Width = 600, Height = 400 };
                pdfExporter.Export(yearModel, stream);
            }
        }
    }
}
