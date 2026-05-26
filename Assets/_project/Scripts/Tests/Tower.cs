using UnityEngine;

public class Tower : MonoBehaviour
{
    public string Name;
    public int Price;

    private void Start()
    {
        Name = gameObject.name;
    }
}