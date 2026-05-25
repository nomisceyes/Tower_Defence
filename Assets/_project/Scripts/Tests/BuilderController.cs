using UnityEngine;

public class BuilderController : MonoBehaviour
{
    public Tower TowerPrefab;
    private Camera _camera;

    private Vector3 _offsetY = new Vector3(0, 1, 0);

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Build();
    }

    private void Build()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Cell cell))
                {
                    if (cell.IsBusy == false)
                        cell.Tower = CreateTower(cell);
                }
            }
        }
    }

    private Tower CreateTower(Cell cell)
    {
        cell.IsBusy = true;
        return Instantiate(TowerPrefab, cell.Position + _offsetY, Quaternion.identity, transform);
    }
}