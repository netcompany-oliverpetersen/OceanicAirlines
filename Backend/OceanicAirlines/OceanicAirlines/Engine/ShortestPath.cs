using OceanicAirlines.APIModels;

namespace OceanicAirlines.Engine
{
    public class ShortestPath
    {
		private static readonly int NO_PARENT = -1;

		// Function that implements Dijkstra's
		// single source shortest path
		// algorithm for a graph represented
		// using adjacency matrix
		// representation
		public ListElement Compute(
											int[,] TimeMatrix,
											int[,] PriceMatrix,
											List<string> cities,
											int startVertex,
											int stopVertex)
		{
			int nVertices = TimeMatrix.GetLength(0);

			// shortestDistances[i] will hold the
			// shortest distance from src to i
			int[] shortestDistances = new int[nVertices];

			// added[i] will true if vertex i is
			// included / in shortest path tree
			// or shortest distance from src to
			// i is finalized
			bool[] added = new bool[nVertices];

			// Initialize all distances as
			// INFINITE and added[] as false
			for (int vertexIndex = 0; vertexIndex < nVertices;
												vertexIndex++)
			{
				shortestDistances[vertexIndex] = int.MaxValue;
				added[vertexIndex] = false;
			}

			// Distance of source vertex from
			// itself is always 0
			shortestDistances[startVertex] = 0;

			// Parent array to store shortest
			// path tree
			int[] parents = new int[nVertices];

			// The starting vertex does not
			// have a parent
			parents[startVertex] = NO_PARENT;

			// Find shortest path for all
			// vertices
			for (int i = 1; i < nVertices; i++)
			{

				// Pick the minimum distance vertex
				// from the set of vertices not yet
				// processed. nearestVertex is
				// always equal to startNode in
				// first iteration.
				int nearestVertex = -1;
				int shortestDistance = int.MaxValue;
				for (int vertexIndex = 0;
						vertexIndex < nVertices;
						vertexIndex++)
				{
					if (!added[vertexIndex] &&
						shortestDistances[vertexIndex] <
						shortestDistance)
					{
						nearestVertex = vertexIndex;
						shortestDistance = shortestDistances[vertexIndex];
					}
				}

				// Mark the picked vertex as
				// processed
				added[nearestVertex] = true;

				// Update dist value of the
				// adjacent vertices of the
				// picked vertex.
				for (int vertexIndex = 0;
						vertexIndex < nVertices;
						vertexIndex++)
				{
					int edgeDistance = TimeMatrix[nearestVertex, vertexIndex];

					if (edgeDistance > 0
						&& ((shortestDistance + edgeDistance) <
							shortestDistances[vertexIndex]))
					{
						parents[vertexIndex] = nearestVertex;
						shortestDistances[vertexIndex] = shortestDistance +
														edgeDistance;
					}
				}
			}

			printSolution(startVertex, shortestDistances, parents, cities);

			List<string> pathString = new List<string>();
			savePath(stopVertex, parents, cities, pathString);
			(int time, int price) = calculateTimeAndPrice(pathString, TimeMatrix, PriceMatrix);
			return new ListElement(cities[startVertex], cities[stopVertex], shortestDistances[stopVertex], 99, string.Join(", ", pathString.ToArray()));
		}

		// A utility function to print
		// the constructed distances
		// array and shortest paths
		private static void printSolution(int startVertex,
										int[] distances,
										int[] parents,
										List<string> cities)
		{
			int nVertices = distances.Length;
			Console.Write("\n");
			Console.Write("City\t Distance\tPath");

			for (int vertexIndex = 0;
					vertexIndex < nVertices;
					vertexIndex++)
			{
				if (vertexIndex != startVertex)
				{
					Console.Write("\n" + cities[startVertex] + " -> ");
					Console.Write(cities[vertexIndex] + " \t\t ");
					Console.Write(distances[vertexIndex] + "\t\t");
					printPath(vertexIndex, parents, cities);
				}
			}

			Console.WriteLine();
		}

		// Function to print shortest path
		// from source to currentVertex
		// using parents array
		private static void printPath(int currentVertex,
									int[] parents,
									List<string> cities)
		{

			// Base case : Source node has
			// been processed
			if (currentVertex == NO_PARENT)
			{
				return;
			}
			printPath(parents[currentVertex], parents, cities);
			Console.Write(cities[currentVertex] + " ");
		}

		private static void savePath(int currentVertex,
							int[] parents,
							List<string> cities, List<string> output)
		{

			// Base case : Source node has
			// been processed
			if (currentVertex == NO_PARENT)
			{
				return;
			}
			savePath(parents[currentVertex], parents, cities, output);
			output.Add(cities[currentVertex]);
		}

		private Tuple<int, int> calculateTimeAndPrice(string[] pathString,
			int[,] TimeMatrix,
			int[,] PriceMatrix)
		{
			return Tuple.Create(5, 8);
		}
	}
}
