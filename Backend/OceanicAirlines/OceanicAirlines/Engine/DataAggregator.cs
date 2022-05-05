using OceanicAirlines.APIModels;

namespace OceanicAirlines.Engine
{
	public class DataAggregator
	{
        public DataAggregator() { }

		public ApiRoute[] getRoutes()
		{

			ApiRoute AB = new ApiRoute("A", "B", 1, 10);
			ApiRoute AC = new ApiRoute("A", "C", 5, 10);
			ApiRoute BD = new ApiRoute("B", "D", 3, 10);
			ApiRoute CD = new ApiRoute("C", "D", 4, 10);

			ApiRoute[] myArray = { AB, AC, BD, CD };

			return myArray;
		}

		public int[,] Aggregate()
		{

			ApiRoute[] routeArray = getRoutes();

			// Find unique destinations
			List<string> cities = UniqueDestinations(routeArray);
			Console.WriteLine(String.Join(", ", cities));

			// make adjacency table with NxN entries
			int n = cities.Count();
			int[,] adjTable = new int[n, n];
			Print2DArray(adjTable);

			// fill out the adjacency table 
			fillTable(adjTable, routeArray, cities);
			Print2DArray(adjTable);

			// compare adjacency tables and find the lowest value at each location

			// decide source
			int source = cities.IndexOf("A");

			// calculate dist		
			ShortestPath t = new ShortestPath();
			t.compute(adjTable, source, cities);

			return "this works";
		}

		List<string> UniqueDestinations(ApiRoute[] routeArray)
		{
			List<string> stringList = new List<string>();
			for (int i = 0; i < routeArray.Length; i++)
			{
				stringList.Add(routeArray[i].Source);
				stringList.Add(routeArray[i].Destination);
			}

			return stringList.Distinct().ToList();

		}

		public static void Print2DArray<T>(T[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					Console.Write(matrix[i, j] + "\t");
				}
				Console.WriteLine();
			}
		}

		public static void fillTable(int[,] matrix, ApiRoute[] routeArray, List<string> cities)
		{
			for (int i = 0; i < routeArray.Length; i++)
			{
				int sourceIndex = cities.IndexOf(routeArray[i].Source);
				int destIndex = cities.IndexOf(routeArray[i].Destination);
				matrix[sourceIndex, destIndex] = routeArray[i].Time;
				matrix[destIndex, sourceIndex] = routeArray[i].Time;
			}
		}
	}
}
