using Task.Models;

namespace Task.Reposatory
{
    public interface IRoute :Icrudoperation<Routes>
    {
         List<Sample> GetSamples();
        //void Delete2(Routes route);

    }
}
