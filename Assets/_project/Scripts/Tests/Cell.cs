using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector3 Position;
    public int X;
    public int Z;
    public bool IsBusy;

    private Renderer _renderer;
    private Outline _outline;

    public void Init(Vector3 position, int x, int z)
    {
        Position = position;
        X = x;
        Z = z;
    }
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _outline = GetComponent<Outline>();
    }

    private void OnMouseEnter()
    {
        _outline.ShowOutline(transform.position, 1);
    }

    private void OnMouseExit()
    {
       _outline.HideOutline();
    }
}