using UnityEngine.Tilemaps;
using UnityEngine;

namespace PlatformerMVC.game.GenerateLevel
{
    public class GenerateLevelController
    {
        private GenerateLevelView View;
        private Tilemap _tilemap;
        private Tile _groundTile;
        private int _mapHeight;
        private int _mapWidth;
        private bool _borders;
        private int _FillPersent;
        private int _FactorSmooth;

        private int[,] _map;

        private int countWall = 4;

        public GenerateLevelController()
        {
            View = Object.FindObjectOfType<GenerateLevelView>();
            _tilemap = View.Tilemap;
            _groundTile = View.GroundTile;
            _mapHeight = View.MapHeight;
            _mapWidth = View.MapWidth;
            _borders = View.Borders;
            _FillPersent = View.FillPersent;
            _FactorSmooth = View.FactorSmooth;

            _map = new int[_mapWidth, _mapHeight];
            Init();
        }

        public void Init()
        {
            FillMap();
            for (int i = 0; i < _FactorSmooth; i++) SmoothMap();
            DrawTiles();
        }

        private void FillMap()
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    if (x == 0 || x == _mapWidth - 1 || y == 0 || y == _mapHeight - 1)
                    {
                        if (_borders)
                        {
                            _map[x, y] = 1;
                        }
                    }
                    else
                    {
                        _map[x, y] = Random.Range(0, 100) < _FillPersent ? 1 : 0;
                    }
                }
            }
        }

        private void SmoothMap()
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    int neighbour = GetNeighbour(x, y);

                    if (neighbour > countWall)
                    {
                        _map[x, y] = 1;
                    }
                    else if( neighbour < countWall)
                    {
                        _map[x, y] = 0;
                    }
                }
            }
        }

        private int GetNeighbour(int x, int y)
        {
            int neighbourCounter = 0;
            for (int gridX = x - 1; gridX <= x + 1; gridX++)
            {
                for (int gridY = y - 1; gridY <= y + 1; gridY++)
                {
                    if (gridX >= 0 && gridX < _mapWidth && gridY >= 0 && gridY < _mapHeight)
                    {
                        if (gridX != x || gridY != y)
                        {
                            neighbourCounter += _map[gridX, gridY];
                        }
                    }
                    else
                    {
                        neighbourCounter++;
                    }
                }
                
            }
            return neighbourCounter;
        }

        private void DrawTiles()
        {
            if (_map == null) return;

            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    Vector3Int TilePosition = new Vector3Int(-_mapWidth / 2 + x, -_mapHeight / 2 + y, 0);
                    if (_map[x, y] == 1)
                    {
                        _tilemap.SetTile(TilePosition, _groundTile);
                    }
                }
            }
        }
    }
}
