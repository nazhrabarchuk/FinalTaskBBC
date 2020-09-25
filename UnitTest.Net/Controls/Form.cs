using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnitTest.Net.Controls
{
    public class Form
    {
        protected IWebDriver driver;

        private string className { get; set; }

        public Form(IWebDriver driver, string className)
        {
            this.driver = driver;
            this.className = className;
        }

        public void FillForm(Dictionary<string, string> values)
        {
            Type pageType = Type.GetType(className);
            ConstructorInfo magicConstructor = pageType.GetConstructor(new[] { typeof(IWebDriver) });
            object magicClassObject = magicConstructor.Invoke(new object[] { driver});

            foreach (KeyValuePair<string, string> keyValue in values)
            {
                PropertyInfo p = pageType.GetProperty(keyValue.Key, BindingFlags.NonPublic | BindingFlags.Instance); 
                MethodInfo m = p.PropertyType.GetMethod("SendKeys");   

                m.Invoke(magicClassObject, new object[] { keyValue.Value });                        
            }

        }

        /*public Dictionary<string, string> GetDictionary()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            values.Add("UserStoryTexarea", "Another story");
            values.Add("UserNameInput", "Name");
            values.Add("UserEmailInput", "email");
            values.Add("UserNumberInput", "111");
            values.Add("UserLocationInput", "Location");

            return values;
        }*/

        //test page
       /* var Form = new Form(GetDriver(), "UnitTest.Net.Pages.CoronavirusPage");
        Form.FillForm(GetCoronavirusPage().GetDictionary());*/

    }
}
