using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AirlinePlanner.Models;

namespace AirlinePlanner.Models.Tests
{
  [TestClass]
  public class CityTests : IDisposable
  {
    public void Dispose()
    {
      City.ClearAll();
    }

    public CityTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=airline_test;";
    }

    [TestMethod]
    public void GetAll_RetrievesEmptyListOfCitiesFromDatabase_0()
    {
        List<City> cities = City.GetAll();

        Assert.AreEqual(0, cities.Count);
    }

    [TestMethod]
    public void Save_SavesCityToDatabase_City()
    {
        City newCity = new City("Portland");
        newCity.Save();

        List<City> cities = City.GetAll();
        List<City> expectedCities = new List<City>{newCity};
        Console.WriteLine("CITIES IN DB: " + cities[0].GetName());
        Console.WriteLine("EXPECTED CITIES: " + expectedCities[0].GetName());
        Console.WriteLine("CITIES IN DB ID: " + cities[0].GetId());
        Console.WriteLine("EXPECTED CITIES ID: " + expectedCities[0].GetId());
        CollectionAssert.AreEqual(expectedCities, cities);
    }
  }
}