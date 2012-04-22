using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TestList.Models
{
    public class TestBattery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public ICollection<Test> Tests { get; set; }
    }
}
