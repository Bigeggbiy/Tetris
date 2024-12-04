using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCellColor : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [Header("Square Settings")]
    public float size = 1f; // Size of the square (length of one side)
    public float lineWidth = 0.1f; // Thickness of the outline
    public Color outlineColor = Color.white; // Color of the outline
    public Material cellMaterial = null;

    void CreateSquareOutline()
    {
        // Calculate the positions of the square's corners
        float halfSize = size / 2f;

        // Define the vertices of the square in a local coordinate space
        // The positions array includes 4 corners and a 5th point to close the square loop
        Vector3[] positions = new Vector3[5]
        {
        new Vector3(-halfSize, -halfSize, 0), // Bottom-left corner
        new Vector3(-halfSize, halfSize, 0),  // Top-left corner
        new Vector3(halfSize, halfSize, 0),   // Top-right corner
        new Vector3(halfSize, -halfSize, 0),  // Bottom-right corner
        new Vector3(-halfSize, -halfSize, 0)  // Closing the loop back to Bottom-left
        };

        // Assign the calculated positions to the LineRenderer component to draw the square outline
        lineRenderer.SetPositions(positions);
    }

    // Automatically update the square outline when changes are made in the Unity Inspector
    void OnValidate()
    {
        // Check if the LineRenderer component is assigned
        if (lineRenderer != null)
        {
            // Update the LineRenderer's color and width properties
            lineRenderer.startColor = outlineColor;
            lineRenderer.endColor = outlineColor;
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;

            // Regenerate the square outline with updated properties
            CreateSquareOutline();
        }
    }

    // Public method to dynamically set the outline color using RGB values
    public void SetOutlineColorByValue(float r, float g, float b)
    {
        // Create a new color instance using the provided RGB values
        Color color = new Color(r, g, b);
        Debug.Log(color); // Log the new color value for debugging purposes

        // Get the LineRenderer component from the current GameObject
        // Add it dynamically if it's not already assigned
        lineRenderer = GetComponent<LineRenderer>();

        // Configure the LineRenderer to create a closed-loop square
        lineRenderer.loop = true; // Ensures the outline forms a closed loop
        lineRenderer.useWorldSpace = false; // Keep the square relative to the GameObject's local space
        lineRenderer.positionCount = 5; // Set the number of points (4 corners + 1 to close the loop)

        // Set the LineRenderer's color and width properties
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        // Assign the material for rendering the square outline
        lineRenderer.material = cellMaterial;

        // Generate the square outline with the updated properties
        CreateSquareOutline();
    }


}
