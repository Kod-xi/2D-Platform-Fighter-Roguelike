using UnityEngine;
using System.Collections.Generic;

public static class ZoneValidator
{
    public static bool IsValidPlacement(Vector2 candidatePosition, 
        Vector2 candidateSize, List<PlacementZone> zones)
    {
        Bounds candidate = new Bounds(candidatePosition, candidateSize);

        bool insideAllowZone = false;

        foreach (PlacementZone zone in zones)
        {
            Bounds zoneBounds = zone.ZoneBounds;

            if (zone.zoneType == ZoneType.Allow)
            {
                if (zoneBounds.Contains(candidate.min) &&
                    zoneBounds.Contains(candidate.max))
                {
                    insideAllowZone = true;
                }
            }

            if (zone.zoneType == ZoneType.Deny)
            {
                if (zoneBounds.Intersects(candidate))
                {
                    return false;
                }
            }
        }

        return insideAllowZone;
    }
}