using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   public Tower TowerPrefab;
   public Button Button;
   
   private void Start()
   {
      Button.onClick.AddListener(Create);
   }

   private void Create()
   {
      BuilderController.Instance.StartCreateTower();
   }

   public void OnPointerEnter(PointerEventData eventData)
   {
      TowerTooltip.Instance.UpdateTooltip(TowerPrefab);
      TowerTooltip.Instance.ShowTooltip(transform.position);
   }

   public void OnPointerExit(PointerEventData eventData)
   {
      TowerTooltip.Instance.HideTooltip();
   }
}