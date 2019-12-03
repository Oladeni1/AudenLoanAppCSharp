using TechTalk.SpecFlow;

namespace MyBDDProjt
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            Util.Initialize();
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            
            Util.driver.Quit();
        }
    }
}