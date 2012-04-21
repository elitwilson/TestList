using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestList.Models
{
    public interface ITestListRepository
    {
        IEnumerable<Test> GetTests();
        Test GetTestById(int id);
        void InsertTest(Test test);
        void DeleteTest(int id);
        void EditTest(Test test);
    }
}