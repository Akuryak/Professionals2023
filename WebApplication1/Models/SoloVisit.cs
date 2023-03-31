using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System.Windows;

namespace WebAPI.Models
{
    public class SoloVisit
    {
        public static string UserPhoto { get; set; } = "/assets/User.jpg";
        public static InputDate<DateTime> InputDate { get; set; } = new InputDate<DateTime>();
        public static List<Models.PurposOfTheVisit>? GetPurposeOfTheVisits()
        {
            using (HttpClient client = new HttpClient())
            {
                return JsonConvert.DeserializeObject<List<Models.PurposOfTheVisit>>(client.GetAsync("http://localhost:8080/getPurposeOfTheVisit", HttpCompletionOption.ResponseContentRead).Result.Content.ReadAsStringAsync().Result) ?? new List<Models.PurposOfTheVisit>();
            }
        }

        public static List<Models.Division>? GetDivisions()
        {
            using (HttpClient client = new HttpClient())
            {
                return JsonConvert.DeserializeObject<List<Models.Division>>(client.GetAsync("http://localhost:8080/getDivision", HttpCompletionOption.ResponseContentRead).Result.Content.ReadAsStringAsync().Result) ?? new List<Models.Division>();
            }
        }
    }
}
