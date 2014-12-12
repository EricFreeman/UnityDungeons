using Dungeon.Generator.Generation;
using UnityEngine;

namespace Assets.Resources.Scripts
{
    public class Director : MonoBehaviour
    {
        public GameObject Tile;

        void Start()
        {
            var g = Generator.Generate(MapSize.Small);
            for (var z = 0; z < g.Height; z++)
            {
                for (var x = 0; x < g.Width; x++)
                {
                    if (g[x, z] == 1)
                    {
                        var t = (GameObject) Instantiate(Tile);
                        t.transform.position = new Vector3(x, 0, z);
                    }
                }
            }
        }
    }
}