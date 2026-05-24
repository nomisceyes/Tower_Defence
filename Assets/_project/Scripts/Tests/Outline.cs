using UnityEngine;

public class Outline : MonoBehaviour
{
    public Material LineMaterial;
    public float LineWidth = 0.05f;
    public Color OutlineColor = Color.green;
    
    private bool _shouldDraw = false;
    private Vector3 _cellPosition;
    private float _cellSize;
    private float _offsetY = -0.5f;
    
    public void ShowOutline(Vector3 position, float size)
    {
        _cellPosition = position;
        _cellSize = size;
        _shouldDraw = true;
    }
    
    public void HideOutline()
    {
        _shouldDraw = false;
    }
    
    private void OnRenderObject()
    {
        if (!_shouldDraw) return;
    
        LineMaterial.SetPass(0);
        GL.PushMatrix();
        GL.Begin(GL.QUADS);
        GL.Color(OutlineColor);
    
        float half = _cellSize / 2;
        float halfWidth = LineWidth;
    
        Vector3 min = _cellPosition - new Vector3(half, _offsetY, half);
        Vector3 max = _cellPosition + new Vector3(half, _offsetY, half);
        float y = min.y;
        
        DrawQuad(
            new Vector3(min.x - halfWidth, y, min.z - halfWidth),
            new Vector3(min.x + halfWidth, y, max.z + halfWidth)
        );
    
        DrawQuad(
            new Vector3(max.x - halfWidth, y, min.z - halfWidth),
            new Vector3(max.x + halfWidth, y, max.z + halfWidth)
        );
    
        DrawQuad(
            new Vector3(min.x - halfWidth, y, min.z - halfWidth),
            new Vector3(max.x + halfWidth, y, min.z + halfWidth)
        );
    
        DrawQuad(
            new Vector3(min.x - halfWidth, y, max.z - halfWidth),
            new Vector3(max.x + halfWidth, y, max.z + halfWidth)
        );
    
        GL.End();
        GL.PopMatrix();
    }

    private void DrawQuad(Vector3 min, Vector3 max)
    {
        GL.Vertex3(min.x, min.y, min.z);
        GL.Vertex3(max.x, min.y, min.z);
        GL.Vertex3(max.x, max.y, max.z);
        GL.Vertex3(min.x, max.y, max.z);
    }
}