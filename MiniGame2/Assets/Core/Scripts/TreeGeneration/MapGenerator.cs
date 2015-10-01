using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using UnityEngine;

namespace Assets
{
    public class MapGenerator : MonoBehaviour
    {

        public int Width;
        public int Height;

        public string seed;
        public bool useRandomSeed;

        [Range(0, 100)]
        public int randomFillPercent;

        [Range(0,100)]
        public int HeightLimit ;
        
        private List<List<Vector3>> _pointsInPlane;

        private float _largestY;
        private float _smallestY;
        private float _boundaryY;

        public GameObject[] Trees;
        
        int[,] map;

        void Start()
        {
            var vertices = GetComponent<MeshFilter>().mesh.vertices;
            vertices = vertices.OrderBy(s => s.x).ThenBy(s => s.z).ToArray();
            var v1 = vertices.OrderBy(s => s.y);
            _largestY = v1.LastOrDefault().y;
            _smallestY = v1.FirstOrDefault().y;
            _boundaryY = _smallestY + (_largestY - _smallestY)*(0.01f*HeightLimit);

            Debug.Log("Largest: " + _largestY + " smallest: " + _smallestY); 
            _pointsInPlane = new List<List<Vector3>>();
            for (int i = 0; i < Width; i++)
            {
                var t = new List<Vector3>();
                
                for (int j = 0; j < Height; j++)
                {
                    Debug.Log(i * Height + j);
                    t.Add(vertices[i* Height + j]);
                }
                _pointsInPlane.Add(t);
            }
            
            GenerateMap();
            Draw();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GenerateMap();
            }
        }

        void GenerateMap()
        {
            map = new int[Width, Height];
            RandomFillMap();

            for (int i = 0; i < 1; i++)
            {
                SmoothMap();
            }
        }


        void RandomFillMap()
        {
            if (useRandomSeed)
            {
                seed = Random.value.ToString(CultureInfo.InvariantCulture);
            }

            var pseudoRandom = new System.Random(seed.GetHashCode());

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    map[x, y] = (pseudoRandom.Next(0, 100) < randomFillPercent) ? 1 : 0;
                }
            }
        }

        void SmoothMap()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int neighbourWallTiles = GetSurroundingWallCount(x, y);

                    if (neighbourWallTiles > 4)
                        map[x, y] = 1;
                    else if (neighbourWallTiles < 4)
                        map[x, y] = 0;

                }
            }
        }

        int GetSurroundingWallCount(int gridX, int gridY)
        {
            int wallCount = 0;
            for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
            {
                for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
                {
                    if (neighbourX >= 0 && neighbourX < Width && neighbourY >= 0 && neighbourY < Height)
                    {
                        if (neighbourX != gridX || neighbourY != gridY)
                        {
                            wallCount += map[neighbourX, neighbourY];
                        }
                    }
                }
            }

            return wallCount;
        }


        void OnDrawGizmos()
        {
            if (map != null)
            {
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        Gizmos.color = (map[x, y] == 1) ? Color.black : Color.white;
                        Vector3 pos = new Vector3(-Width / 2 + x + .5f, 0, -Height / 2 + y + .5f);
                        Gizmos.DrawCube(pos, Vector3.one);
                    }
                }
            }
        }

        private void Draw()
        {


            var thisMatrix = transform.localToWorldMatrix;
            if (map != null)
            {
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        if(map[x,y] == 0)
                            continue;
                        Debug.Log("y: " + y);
                        //Debug.Log("x: " + x + "y: " + y);


                        var pointInPlain = _pointsInPlane[x][y];
                        if(pointInPlain.y < _boundaryY)
                            continue;

                        var tempTree = (GameObject)Instantiate(Trees[new System.Random().Next(0, Trees.Length)], thisMatrix.MultiplyPoint3x4(pointInPlain), Quaternion.identity);
                    }
                }
            }
        }

    }
}