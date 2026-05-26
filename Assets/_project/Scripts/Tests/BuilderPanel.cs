using UnityEngine;

public class BuilderPanel : MonoBehaviour
{
    public GameObject Panel;
    
    public bool IsActive => Panel.activeSelf;

    public void On()
    {
        Panel.SetActive(true);
    }

    public void Off()
    {
        Panel.SetActive(false);
        TowerTooltip.Instance.HideTooltip();
    }
}