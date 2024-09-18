using UnityEngine;

public class GridBackground : MonoBehaviour
{
    public float cellSize = 1f; // Size of each grid cell
    public int width = 10; // Number of cells in width
    public int height = 20; // Number of cells in height
    public Color gridColor = Color.white; // Color of the grid lines

    // Draw the grid in the Scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = gridColor;

        // Draw vertical lines
        for (int x = 0; x <= width; x++)
        {
            Vector3 start = new Vector3(x * cellSize, 0, 0);
            Vector3 end = new Vector3(x * cellSize, height * cellSize, 0);
            Gizmos.DrawLine(start, end);
        }

        // Draw horizontal lines
        for (int y = 0; y <= height; y++)
        {
            Vector3 start = new Vector3(0, y * cellSize, 0);
            Vector3 end = new Vector3(width * cellSize, y * cellSize, 0);
            Gizmos.DrawLine(start, end);
        }
    }
}