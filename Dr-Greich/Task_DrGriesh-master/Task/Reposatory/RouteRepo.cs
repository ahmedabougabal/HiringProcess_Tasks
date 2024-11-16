using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Reposatory
{
    public class RouteRepo : CrudOperationRepo<Routes>,IRoute
    {
        private readonly Context context;

        public RouteRepo(Context context) : base(context)
        {
            this.context = context;
        }



        public List<Sample> GetSamples()
        {
            List<SamplesRoutes> samplesroute = context.samplesRoutes.Include(s => s.sample).ToList();

            List<Sample> sample = samplesroute.Select(s => s.sample).ToList();
            return sample;
        }

        //public void Delete2(Routes route)
        //{
        //    Routes routes = GetById(route.Code);
        //    context.Routes.Remove(routes);
        //}
    }
}
