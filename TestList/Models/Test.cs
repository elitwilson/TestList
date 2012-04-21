using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TestList.Models
{
    public class Test
    {
        public Test()
        {
            this.Id = 0;
            this.Name = null;
            this.Abbreviation = null;
            this.NormVariables = null;
            this.Age = null;
            this.Type = null;
            this.Scoring = null;
            this.Usage = null;
        }
        
        public Test(int id, string name, string abbreviation, string normVariables, string age, string type, string scoring, string usage)
        {
            this.Id=id;
            this.Name = name;
            this.Abbreviation = abbreviation;
            this.NormVariables = normVariables;
            this.Age = age;
            this.Type = type;
            this.Scoring = scoring;
            this.Usage = usage;
        }
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Test Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage="Abbreviation is required")]
        public string Abbreviation { get; set; }

        public string NormVariables { get; set; }
        public string Age { get; set; }
        public string Type { get; set; }
        public string Scoring { get; set; }
        public string Usage { get; set; }

        
        //Just an experiment...
        private string[] _ageTypes;
        public string[] AgeTypes
        {
            get { return _ageTypes; }
            set
            {
                _ageTypes = new string[3] { "Test", "Testes", "Testing" };
            }
        }

    }
}