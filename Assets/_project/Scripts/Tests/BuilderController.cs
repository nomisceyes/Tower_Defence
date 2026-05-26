using UnityEngine;

public class BuilderController : MonoBehaviour
{
    public static BuilderController Instance;

    public BuilderPanel BuilderPanel;
    public Tower TowerPrefab; 

    private Camera _camera;
    private Cell _currentCell;
    private readonly Vector3 _offsetY = new(0, 1, 0);

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && BuilderPanel.IsActive == false)
            TrySelectCell();
    }
    
    public void StartCreateTower()
    {
        if (_currentCell != null)
        {
            Instantiate(TowerPrefab, _currentCell.Position + _offsetY, Quaternion.identity, transform);
            BuilderPanel.Off();
        }
    }

    private void TrySelectCell()
    {
        if (TryRaycastToCell(out Cell cell) == false)
            return;

        _currentCell = cell;
        
        if (_currentCell.IsBusy == false)
            BuilderPanel.On();
    }

    private bool TryRaycastToCell(out Cell cell)
    {
        cell = null;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.collider.TryGetComponent(out cell);
        }
        
        return false;
    }
}