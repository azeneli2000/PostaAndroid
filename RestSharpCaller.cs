using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RestSharp;

namespace FotoCel
{
    class RestSharpCaller
    {
        public RestClient client;
        public RestSharpCaller(string baseUrl)
        {
            client = new RestClient(baseUrl);
        }

        public List<Shoferi> GetShoferi()
        {
            var request = new RestRequest("", Method.GET);
            var response = client.Execute<List<Shoferi>>(request);
            return response.Data;
        }

        public List<Order> GetOrders()
        {
            var request = new RestRequest("", Method.GET);
            var response = client.Execute<List<Order>>(request);
            return response.Data;
        }

        public void UpdatePickup()
        {
            var request = new RestRequest("", Method.POST);
          
            client.Execute(request);
        
        }

        public List<Order> Raporte()
        {
            var request = new RestRequest("", Method.GET);
            var response = client.Execute<List<Order>>(request);
            return response.Data;
        }


    }
}