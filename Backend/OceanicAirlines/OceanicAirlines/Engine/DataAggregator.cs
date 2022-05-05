using OceanicAirlines.APIModels;
using OceanicAirlines.Controllers;
using OceanicAirlines.Services;

namespace OceanicAirlines.Engine
{
	public class DataAggregator
	{
        public DataAggregator() { }

		public List<ApiRoute> getRoutes(APIRouteRequest request)
		{

			//ApiRoute AB = new ApiRoute("A", "B", 1, 10);
			//ApiRoute AC = new ApiRoute("A", "C", 5, 10);
			//ApiRoute BD = new ApiRoute("B", "D", 3, 10);
			//ApiRoute CD = new ApiRoute("C", "D", 4, 10);
			//ApiRoute AE = new ApiRoute("A", "E", 2, 7);
			//ApiRoute ED = new ApiRoute("E", "D", 2, 7);
			//ApiRoute[] myArray = { AB, AC, BD, CD, AE, ED };

			RoutesController RC = new RoutesController();
			Task<IEnumerable<ApiRoute>> task = RC.Post(request);
			return task.Result.ToList();

			//EastIndiaTrading EIT = new EastIndiaTrading();
			//Task<IEnumerable<ApiRoute>> task = EIT.GetApiRoutes(new APIRouteRequest { Category = "test", Height = 0, Length = 0, Weight = 0, Width = 0 });
			//return task.Result.ToList();

		}

		public Tuple<int[,], int[,], List<string>> Aggregate(bool Scramble, APIRouteRequest request)
		{
			List<ApiRoute> routeArray = getRoutes(request);

			// Find unique destinations
			List<string> cities = UniqueDestinations(routeArray);
			Console.WriteLine(String.Join(", ", cities));

			// make adjacency table with NxN entries
			int n = cities.Count();
			int[,] timeTable = new int[n, n];
			int[,] priceTable = new int[n, n];

			// fill out the adjacency table 
			fillTable(timeTable, routeArray, cities, true);
			fillTable(priceTable, routeArray, cities, false);
			Print2DArray(timeTable);
			Console.WriteLine("\n");
			Print2DArray(priceTable);

			if (Scramble)
            {
				ScrambleTable(timeTable);
				Console.Write("\n");
				Print2DArray(timeTable);
			}

			return Tuple.Create(timeTable, priceTable, cities);
		}

		List<string> UniqueDestinations(List<ApiRoute> routeArray)
		{
			List<string> stringList = new List<string>();
			for (int i = 0; i < routeArray.Count(); i++)
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

		public static void ScrambleTable(int[,] matrix)
        {
			List<Tuple<int, int>> nonzeros = new List<Tuple<int, int>>();

			// find nonzero elements
			for (int i = 0; i < matrix.GetLength(0); i++)
            {
				for (int j = 0; j < matrix.GetLength(1); j++)
                {
					if (matrix[i, j] != 0)
                    {
						nonzeros.Add(new Tuple<int, int>(i, j));
                    }
                }

			}

			// remove 3 random edges
			Random rnd = new Random();
			for (int i = 0; i < 3; i++) { 
				int removeIndex = rnd.Next(1, nonzeros.Count);
				matrix[nonzeros[removeIndex].Item1, nonzeros[removeIndex].Item2] = 0;
				matrix[nonzeros[removeIndex].Item2, nonzeros[removeIndex].Item1] = 0;  // mirror
			}
		}

		public static void fillTable(int[,] matrix, List<ApiRoute> routeArray, List<string> cities, bool ForTime)
		{
			for (int i = 0; i < routeArray.Count(); i++)
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
