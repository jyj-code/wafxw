[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(share.App_Start.Combres), "PreStart")]
namespace share.App_Start {
	using System.Web.Routing;
	using global::Combres;
	
    public static class Combres {
        public static void PreStart() {
            RouteTable.Routes.AddCombresRoute("Combres");
        }
    }
}