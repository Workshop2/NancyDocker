using Nancy;

namespace NancyConsole
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => "Hello world...again";
        }
    }
}