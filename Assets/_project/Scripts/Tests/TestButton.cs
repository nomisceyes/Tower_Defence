using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour
{
    public Button Button;

    private void Start()
    {
        Button.onClick.AddListener(Create);
    }

    private void Create()
    {
        BuilderController.Instance.StartToCreateTower();
    }
}