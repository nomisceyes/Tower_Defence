using UnityEngine;
using UnityEngine.UI;

public class TowerTooltip : MonoBehaviour
{
   public static TowerTooltip Instance;
   
   public GameObject TooltipPanel;
   public RectTransform RectTransform;

   private Text _nameText;
   private Text _priceText;

   private float _offsetX;
   private float _offsetY;

   public void ShowTooltip(Vector2 targetIcon)
   {
      TooltipPanel.gameObject.SetActive(true);
      PositionTooltip(targetIcon);
   }

   public void HideTooltip() =>
      TooltipPanel.SetActive(false);
    
   public void Init(GameObject tooltip)
   {
      if (Instance == null)
         Instance = this;
      
      TooltipPanel = tooltip;
      TooltipPanel.SetActive(false);
      RectTransform = TooltipPanel.GetComponent<RectTransform>();
        
      _nameText = TooltipPanel.transform.Find("Name").GetComponent<Text>();
      _priceText = TooltipPanel.transform.Find("Price").GetComponent<Text>();

      _offsetX = 200f;
      _offsetY = 150f;
   }
    
   public void UpdateTooltip(Tower tower)
   {
      if (TooltipPanel == null)
      {
         Debug.LogWarning("Tooltip Panel не назначен!");
         return;
      }

      _nameText.text = tower.Name;
      _priceText.text = tower.Price.ToString();
   }
   
   private void PositionTooltip(Vector2 targetIcon)
   {
      TooltipPanel.transform.position = targetIcon;
   
      RectTransform.anchoredPosition = new Vector2(
         RectTransform.anchoredPosition.x + _offsetX,
         RectTransform.anchoredPosition.y + _offsetY);
   }
}