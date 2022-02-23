using NetTopologySuite.Geometries;

namespace Vivel.Helpers
{
    public class GeographyHelper
    {
        static public Point CreatePoint(decimal? longitude, decimal? latitude)
        {
            return new Point((double)longitude, (double)latitude) { SRID = 4326 };
        }
    }
}
