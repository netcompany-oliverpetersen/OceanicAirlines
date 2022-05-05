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
			ApiRoute AE = new ApiRoute("A", "E", 2, 7);
			ApiRoute ED = new ApiRoute("E", "D", 2, 7);

			ApiRoute[] myArray = { AB, AC, BD, CD, AE, ED };

			return myArray;
		}

		public Tuple<int[,], List<string>> Aggregate(bool ForTime, bool Scramble)
		{

			ApiRoute[] routeArray = getRoutes();

			// Find unique destinations
			List<string> cities = UniqueDestinations(routeArray);
			Console.WriteLine(String.Join(", ", cities));

			// make adjacency table with NxN entries
			int n = cities.Count();
			int[,] adjTable = new int[n, n];

			// fill out the adjacency table 
			fillTable(adjTable, routeArray, cities, ForTime);
			Print2DArray(adjTable);

			if (Scramble)
            {
				ScrambleTable(adjTable);
            }

			return Tuple.Create(adjTable, cities);
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

		public static void ScrambleTable<T>(T[,] matrix)
        {
			// do something
        }

		public static void fillTable(int[,] matrix, ApiRoute[] routeArray, List<string> cities, bool ForTime)
		{
			for (int i = 0; i < routeArray.Length; i++)
			{
				int sourceIndex = cities.IndexOf(routeArray[i].Source);
				int destIndex = cities.IndexOf(routeArray[i].Destination);
				if (ForTime)
				{
					matrix[sourceIndex, destIndex] = routeArray[i].Time;
					matrix[destIndex, sourceIndex] = routeArray[i].Time;
				}
				else
				{
					matrix[sourceIndex, destIndex] = routeArray[i].Price;
					matrix[destIndex, sourceIndex] = routeArray[i].Price;
				}
			}
		}
	}
}
