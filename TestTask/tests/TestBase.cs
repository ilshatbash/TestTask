using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebTestTask
{
    public class TestBase
    {

        protected ApplicationManager app;


        [SetUp]
        public void SetupTest()
        {
            app = ApplicationManager.GetInstance();
           
        }
               
    }

}
