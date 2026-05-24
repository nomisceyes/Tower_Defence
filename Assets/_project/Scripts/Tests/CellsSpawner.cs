using UnityEngine;

public class CellsSpawner : MonoBehaviour
{
   public GameObject CellPrefab;
   public int CellSize = 1;
   
   private Terrain _terrain;
   private Cell[,] _cells;
   private Vector2Int _gridSize;

   private void Awake()
   {
       _terrain = GetComponent<Terrain>();
       
       _gridSize.x = (int)_terrain.terrainData.size.x;
       _gridSize.y = (int)_terrain.terrainData.size.z;
   }

   private void Start()
   {
       Debug.Log(_gridSize);
       CreateGrid();
   }

   private void CreateGrid()
   {
       _cells = new Cell[_gridSize.x, _gridSize.y];
       
       Vector3 terrainPosition = _terrain.transform.position;
       Vector3 startPosition = terrainPosition + new Vector3(0.5f, 0, 0.5f);

       for (int x = 0; x < _gridSize.x; x++)
       {
           for (int z = 0; z < _gridSize.y; z++)
           {
               Vector3 cellPosition = startPosition + new Vector3(x * CellSize, 0, z * CellSize);
               
               float terrainHeight = _terrain.SampleHeight(cellPosition);
               cellPosition.y = terrainHeight - 0.49f;
               
               GameObject cellObject = Instantiate(CellPrefab, cellPosition, Quaternion.identity, transform);
               Cell cell = cellObject.GetComponent<Cell>();
               cell.Init(cellPosition, x, z);
               
               _cells[x, z] = cell;
           }
       }
   }
}