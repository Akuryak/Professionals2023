using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Helpers
{
    public class ApiRequests
    {
        public static T? GetObject<T>(string httpString)
        {
            if (!string.IsNullOrWhiteSpace(httpString))
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(new HttpClient().GetAsync(httpString, HttpCompletionOption.ResponseContentRead).Result.Content.ReadAsStringAsync().Result);
                }
                catch
                {
                    return default;
                }
            }
            else return default;
        }

        public static List<T> GetList<T>(string httpString)
        {
            if (!string.IsNullOrWhiteSpace(httpString))
            {
                try
                {
                    return JsonConvert.DeserializeObject<List<T>>(new HttpClient().GetAsync(httpString, HttpCompletionOption.ResponseContentRead).Result.Content.ReadAsStringAsync().Result);
                }
                catch
                {
                    return default;
                }
            }
            else return default;
        }

        public static void PostObject<T>(string httpString, T sendObject)
        {
            if (!string.IsNullOrWhiteSpace(httpString) || sendObject != null)
            {
                try
                {
                    HttpClient httpClient = new HttpClient();
                    var responce = httpClient.PostAsync(httpString, new StringContent(JsonConvert.SerializeObject(sendObject, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }), Encoding.UTF8, "application/json"));
                    if (!responce.Result.IsSuccessStatusCode)
                        MessageBox.Show(responce.Result.Content.ReadAsStringAsync().Result, "Ошибка");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
            else
                MessageBox.Show("Строка подключение и объект пустые", "Ошибка");
        }

        public static void DeleteObject<T>(string httpString)
        {
            if (!string.IsNullOrWhiteSpace(httpString))
            {
                try
                {
                    HttpClient httpClient = new HttpClient();
                    var responce = httpClient.DeleteAsync(httpString).Result;
                    if (!responce.IsSuccessStatusCode)
                        MessageBox.Show(responce.Content.ReadAsStringAsync().Result, "Ошибка");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
            else
                MessageBox.Show("Строка подключение и объект пустые", "Ошибка");
        }
    }
}
