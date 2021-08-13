// <copyright file="Startup.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using HelloWorldWeb.Controllers;

namespace HelloWorldWeb
{
    public class WeatherControllerSettings : IWeatherControllerSettings
    {
        public string Longitude { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public string Latitude { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public string ApiKey { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}