using TechTalk.SpecFlow;
using UnitTest.Net.Pages;

namespace UnitTest.Net.Hooks
{
    [Binding]
    public sealed class Hooks
    {
      
        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Close();
        }
    }
}
