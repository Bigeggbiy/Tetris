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

    void Start()
    {
        //// Get or add the LineRenderer component
        //lineRenderer = GetComponent<LineRenderer>();

        //// Set up the LineRenderer properties
        //lineRenderer.loop = true; // Ensures the outline forms a closed loop
        //lineRenderer.useWorldSpace = false; // Keep the square local to the GameObject
        //lineRenderer.positionCount = 5; // 4 corners + 1 to close the loop

        //// Set the outline color and width
        //lineRenderer.startColor = outlineColor;
        //lineRenderer.endColor = outlineColor;
        //lineRenderer.startWidth = lineWidth;
        //lineRenderer.endWidth = lineWidth;

        //// Set the outline material
        //lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        ////Create the square outline
        //CreateSquareOutline();
    }

    void CreateSquareOutline()
    {
        // Calculate the positions of the square's corners
        float halfSize = size / 2f;

        Vector3[] positions = new Vector3[5]
        {
            new Vector3(-halfSize, -halfSize, 0), // Bottom-left
            new Vector3(-halfSize, halfSize, 0),  // Top-left
            new Vector3(halfSize, halfSize, 0),   // Top-right
            new Vector3(halfSize, -halfSize, 0),  // Bottom-right
            new Vector3(-halfSize, -halfSize, 0)  // Close the loop back to Bottom-left
        };

        // Assign the positions to the LineRenderer
        lineRenderer.SetPositions(positions);
    }

    void InitialSetup()
    {
        // Get or add the LineRenderer component
        lineRenderer = GetComponent<LineRenderer>();

        // Set up the LineRenderer properties
        lineRenderer.loop = true; // Ensures the outline forms a closed loop
        lineRenderer.useWorldSpace = false; // Keep the square local to the GameObject
        lineRenderer.positionCount = 5; // 4 corners + 1 to close the loop

        //// Set the outline color and width
        //lineRenderer.startColor = outlineColor;
        //lineRenderer.endColor = outlineColor;
        //lineRenderer.startWidth = lineWidth;
        //lineRenderer.endWidth = lineWidth;

        // Set the outline material
        lineRenderer.material = cellMaterial;

        //Create the square outline
        CreateSquareOutline();
    }

    // Optionally, allow dynamic updates in the Inspector
    void OnValidate()
    {

        if (lineRenderer != null)
        {
            lineRenderer.startColor = outlineColor;
            lineRenderer.endColor = outlineColor;
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;
            CreateSquareOutline();
        }
    }

    public void SetOutlineColorByValue(float r, float g, float b)
    {
        Color color = new Color(r, g, b);
        Debug.Log(color);
        // Get or add the LineRenderer component
        lineRenderer = GetComponent<LineRenderer>();

        // Set up the LineRenderer properties
        lineRenderer.loop = true; // Ensures the outline forms a closed loop
        lineRenderer.useWorldSpace = false; // Keep the square local to the GameObject
        lineRenderer.positionCount = 5; // 4 corners + 1 to close the loop

        // Set the outline color and width
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        // Set the outline material
        lineRenderer.material = cellMaterial;

        //Create the square outline
        CreateSquareOutline();

        //// Get or add the LineRenderer component
        //lineRenderer = GetComponent<LineRenderer>();

        //// Set up the LineRenderer properties
        //lineRenderer.loop = true;
        //lineRenderer.useWorldSpace = false;
        //lineRenderer.positionCount = 5;

        //// Ensure the LineRenderer has a default material
        //if (lineRenderer.material == null)
        //{
        //    lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        //}

        //// Create a new MaterialPropertyBlock
        //MaterialPropertyBlock block = new MaterialPropertyBlock();

        //// Check if the shader uses _TintColor or _Color for color properties
        //if (lineRenderer.material.HasProperty("_Color"))
        //{
        //    block.SetColor("_Color", new Color(r, g, b, 1f)); // For Default Sprites Shader
        //}
        //else if (lineRenderer.material.HasProperty("_TintColor"))
        //{
        //    block.SetColor("_TintColor", new Color(r, g, b, 1f)); // For LineRenderer-specific shaders
        //}

        //// Apply the property block to the LineRenderer
        //lineRenderer.SetPropertyBlock(block);

        //// Set the line width
        //lineRenderer.startWidth = lineWidth;
        //lineRenderer.endWidth = lineWidth;

        //// Create the square outline
        //CreateSquareOutline();
    }

}
