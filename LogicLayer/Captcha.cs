using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Created By: Tyler Barz
    /// Date Created: 04/02/2024
    /// Summary: Simplified google recaptcha solving
    /// </summary>
    public static class Captcha
    {
        // Would obviously be private, however the DB script is public already so...
        public static string SiteKey = "6LeC5awpAAAAAF3KDarTVFHhe0-OpzVN3Podo9Lz";
        private static string SecretKey = "6LeC5awpAAAAAB6C9KaqmYQXOJVIGN25u-CPL3XE";
        public static string Endpoint = "https://www.google.com/recaptcha/api/siteverify?secret=" + SecretKey;
        public static async Task<bool> SolveCaptcha(string response)
        {
            var resp = await RequestCaptcha(response);
            return resp.IsSuccessStatusCode && await Validate(resp);
        } 

        private static async Task<bool> Validate(HttpResponseMessage resp)
        {
            var content = await resp.Content.ReadAsStringAsync();
            return content.Contains("\"success\": true");
        }

        private static async Task<HttpResponseMessage> RequestCaptcha(string response)
        {
            return await new HttpClient().GetAsync($"{Endpoint}&response={response}");
        }    
    }
}
