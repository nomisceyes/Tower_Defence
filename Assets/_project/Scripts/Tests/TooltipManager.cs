using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    public TowerTooltip TowerTooltip;

    public void Awake()
    {
        Canvas canvas = FindFirstObjectByType<Canvas>();
        
        GameObject towerObj = new GameObject("TowerTooltip") { transform = { parent = transform } };
        towerObj.AddComponent<TowerTooltip>();
        
        GameObject tooltipTower = Instantiate(Resources.Load<GameObject>("Tooltip/TowerTooltip"), canvas.transform);
        TowerTooltip = towerObj.GetComponent<TowerTooltip>();
        
        TowerTooltip.Init(tooltipTower);
    }
}