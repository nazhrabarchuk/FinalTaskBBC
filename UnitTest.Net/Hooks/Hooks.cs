using TechTalk.SpecFlow;
using FinalTaskBBC.Pages;

namespace FinalTaskBBC.Hooks
{
    [Binding]
    public sealed class Hooks
    {
      
        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }
    }
}
