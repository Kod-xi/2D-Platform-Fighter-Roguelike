using UnityEngine;

public class PlacementZone : MonoBehaviour
{
    public ZoneType zoneType;

    private BoxCollider2D box;

    public Bounds ZoneBounds
    {
        get
        {
            if (box == null)
                box = GetComponent<BoxCollider2D>();

            return box.bounds;
        }
    }

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();

        if (box == null)
            Debug.LogError("PlacementZone requires a BoxCollider2D!");
    }

    private void OnDrawGizmos()
    {
        BoxCollider2D col = GetComponent<BoxCollider2D>();

        if (col == null) return;

        Gizmos.color = zoneType == ZoneType.Allow
            ? new Color(0, 1, 0, 0.25f)
            : new Color(1, 0, 0, 0.25f);

        Gizmos.DrawCube(col.bounds.center, col.bounds.size);

        Gizmos.color = zoneType == ZoneType.Allow
            ? Color.green
            : Color.red;

        Gizmos.DrawWireCube(col.bounds.center, col.bounds.size);
    }
}

public enum ZoneType{ Allow, Deny};