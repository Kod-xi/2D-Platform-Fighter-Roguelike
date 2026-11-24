using UnityEngine;
using System.Collections.Generic;

public class DemoPlatformGeneration : MonoBehaviour
{
    public GameObject platformPrefab;

    public List<PlacementZone> zones;

    public int platformCount = 8;

    public Vector2 platformSize = new Vector2(2f, 0.5f);

    public void GenerateLevel()
    {
        short generated = 0;
        short attempts = 0;

        while (generated < platformCount && attempts < 100)
        {
            attempts++;

            List<PlacementZone> allowZones = 
                zones.FindAll(z =>z.zoneType == ZoneType.Allow);

            if (allowZones.Count == 0) break;

            PlacementZone zone = allowZones[Random.Range(0, allowZones.Count)];

            Bounds bounds = zone.ZoneBounds;

            float x = Random.Range(
                bounds.min.x + platformSize.x / 2,
                bounds.max.x - platformSize.x / 2
            );

            float y = Random.Range(
                bounds.min.y + platformSize.y / 2,
                bounds.max.y - platformSize.y / 2
            );

            Vector2 position = new Vector2(x, y);

            // if (ZoneValidator.IsValidPlacement(
            //     position, platformSize, zones))
            {
                Instantiate(platformPrefab, position,
                    Quaternion.identity);

                generated++;
            }
        }

        Debug.Log("Generated " + generated + " platforms.");
    }
}
