using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

namespace PlatformerMVC.game.GenerateLevel
{
    public class GenerateLevelView : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private Tile _groundTile;
        [SerializeField] private int _mapHeight;
        [SerializeField] private int _mapWidth;
        [SerializeField] private bool _borders;
        [SerializeField] [Range(0, 100)] private int _FillPersent;
        [SerializeField] [Range(0, 100)] private int _FactorSmooth;
        public Tilemap Tilemap { get => _tilemap; set => _tilemap = value; }
        public Tile GroundTile { get => _groundTile; set => _groundTile = value; }
        public int MapHeight { get => _mapHeight; set => _mapHeight = value; }
        public int MapWidth { get => _mapWidth; set => _mapWidth = value; }
        public bool Borders { get => _borders; set => _borders = value; }
        public int FillPersent { get => _FillPersent; set => _FillPersent = value; }
        public int FactorSmooth { get => _FactorSmooth; set => _FactorSmooth = value; }
    }
}
