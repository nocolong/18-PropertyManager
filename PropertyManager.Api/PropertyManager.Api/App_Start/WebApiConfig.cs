﻿using AutoMapper;
using PropertyManager.Api.Domain;
using PropertyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PropertyManager.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Set API to return json insteadof XML
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            CreateMaps();
        }
            private static void CreateMaps()
        {
            Mapper.CreateMap<Lease, LeaseModel>();
            Mapper.CreateMap<Property, PropertyModel>();
            Mapper.CreateMap<Tenant, TenantModel>();
            Mapper.CreateMap<WorkOrder, WorkOrderModel>();
            Mapper.CreateMap<Address, AddressModel>();
        }
    }
}
