using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestList.Models;
using System.ComponentModel.DataAnnotations;

namespace TestList.ViewModels
{
    public class TestBatteryVM
    {
        public IEnumerable<Test> Tests { get; set; }
        public TestBattery TestBattery { get; set; }
    }
}