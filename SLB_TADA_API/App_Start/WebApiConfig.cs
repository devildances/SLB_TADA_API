﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace SLB_TADA_API
{
    public static class WebApiConfig
    {
        public static MySqlConnection conns()
        {
            string conn_string = "server=localhost;port=3306;database=fea_starhub;username=root;password=135246;";
            MySqlConnection conns = new MySqlConnection(conn_string);
            return conns;
        }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}
