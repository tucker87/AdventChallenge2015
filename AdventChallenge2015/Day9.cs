using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventChallenege2015
{
    internal class Day9
    {
        //117
        public static int Solve1(List<string> input)
        {
            return GetDistance(BuildMap(input), GetShortestDistance).Select(x => x.Item1).Min();
        }

        //909
        public static int Solve2(List<string> input)
        {
            return GetDistance(BuildMap(input), GetLongestDistance).Select(x => x.Item1).Max();
        }

        public static IEnumerable<Tuple<int, string, string>> GetDistance(List<Place> places, Func<Place, Place, Place, int, List<string>, int> method)
        {
            return (from start in places
                 from end in places.Where(x => x.Name != start.Name)
                 select new Tuple<int, string, string>(method.Invoke(start, start, end, 0, null), start.Name, end.Name));
        }

        private static List<Place> BuildMap(IEnumerable<string> input)
        {
            var places = new List<Place>();
            foreach (var direction in input)
            {
                var placesArr = direction.Split(new[] {"to", "="}, StringSplitOptions.RemoveEmptyEntries);
                var distance = Convert.ToInt32(placesArr[2]);
                
                var from = places.GetOrAddPlace(placesArr[0].Trim());
                var to = places.GetOrAddPlace(placesArr[1].Trim());
                from.Connections.Add(new Connection {Destination = to, Distance = distance});
                to.Connections.Add(new Connection {Destination = from, Distance = distance});
            }
            return places;
        }

        private static int GetShortestDistance(Place start, Place current, Place end, int distance = 0, List<string> visited = null)
        {
            return GetSomeDistance(start, start, end, Enumerable.OrderBy);
        }

        private static int GetLongestDistance(Place start, Place current, Place end, int distance = 0, List<string> visited = null)
        {
            return GetSomeDistance(start, start, end, Enumerable.OrderByDescending);
        }
        
        private static int GetSomeDistance(Place start, Place current, Place end, Func<IEnumerable<Connection>, Func<Connection, int>, IOrderedEnumerable<Connection>> orderby, int distance = 0, List<string> visited = null)
        {
            if (visited == null)
                visited = new List<string> { start.Name };
            else
                visited.Add(current.Name);

            if (!current.Connections.Any(x => !visited.Contains(x.Destination.Name) && x.Destination.Name != end.Name))
                return distance + current.Connections.Single(x => x.Destination.Name == end.Name).Distance;

            var connection = orderby.Invoke(current.Connections,x => x.Distance).First(x => !visited.Contains(x.Destination.Name) && x.Destination.Name != end.Name);
            return distance + GetSomeDistance(start, connection.Destination, end, orderby, connection.Distance, visited);
        }
    }

    class Place
    {
        public string Name { get; set; }
        public List<Connection> Connections { get; set; } = new List<Connection>();
    }

    class Connection
    {
        public Place Destination { get; set; }
        public int Distance { get; set; }
    }

    static class PlaceExtension
    {
        public static Place GetOrAddPlace(this ICollection<Place> places, string name)
        {
            var place = places.FirstOrDefault(x => x.Name == name);
            if (place != null)
                return place;

            place = new Place { Name = name };
            places.Add(place);
            return place;
        }
    }
}