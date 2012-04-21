using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace TestList.Models
{
    public class TestListRepository : ITestListRepository
    {
        private List<Test> allTests;
        private XDocument testListData;

        //CONSTRUCTOR ----------------------------------------------------------------------------------
        public TestListRepository()
        {
            allTests = new List<Test>();

            testListData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/TestList.xml"));

            var tests = from test in testListData.Descendants("test")
                        select new Test
                            ((int)test.Element("id"),
                            test.Element("name").Value,
                            test.Element("abbreviation").Value,
                            test.Element("normVariables").Value,
                            test.Element("age").Value,
                            test.Element("type").Value,
                            test.Element("scoring").Value,
                            test.Element("usage").Value);


            allTests.AddRange(tests.ToList<Test>());
        }

        //METHODS --------------------------------------------------------------------------------------
        
        //Get All Tests
        public IEnumerable<Test> GetTests()
        {
            return allTests;
        }

        //Get Test By Id
        public Test GetTestById(int id)
        {
            return allTests.Find(item => item.Id == id);
        }

        //Insert
        public void InsertTest(Test test)
        {
            test.Id = (int)(from t in testListData.Descendants("test")
                            orderby (int)t.Element("id") descending
                            select (int)t.Element("id")).FirstOrDefault() + 1;

            testListData.Root.Add(
                new XElement("test",
                new XElement("id", test.Id),
                new XElement("name", test.Name),
                new XElement("abbreviation", test.Abbreviation),
                new XElement("normVariables", test.NormVariables),
                new XElement("age", test.Age),
                new XElement("type", test.Type),
                new XElement("scoring", test.Scoring),
                new XElement("usage", test.Usage)));

            testListData.Save(HttpContext.Current.Server.MapPath("~/App_Data/TestList.xml"));
        }

        //Delete
        public void DeleteTest(int id)
        {
            testListData.Root.Elements("test").Where(i => (int)i.Element("id") == id).Remove();

            testListData.Save(HttpContext.Current.Server.MapPath("~/App_Data/TestList.xml"));
        }

        //Edit
        public void EditTest(Test test)
        {
            XElement element = testListData.Root.Elements("test").Where(t => (int)t.Element("id") == test.Id).FirstOrDefault();

            element.SetElementValue("name", test.Name);
            element.SetElementValue("abbreviation", test.Abbreviation);
            element.SetElementValue("normVariables", test.NormVariables);
            element.SetElementValue("age", test.Age);
            element.SetElementValue("type", test.Type);
            element.SetElementValue("scoring", test.Scoring);
            element.SetElementValue("usage", test.Usage);

            testListData.Save(HttpContext.Current.Server.MapPath("~/App_Data/TestList.xml"));
        }


    }
}