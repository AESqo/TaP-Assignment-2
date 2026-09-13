using UnityEngine;
[ExecuteAlways]

public class Circles : MonoBehaviour
{
    public int size = 1;
    private SpriteRenderer circle;
    [HideInInspector] public bool active = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnValidate()
    {
        Refresh();
    }
    public void Refresh() {
        circle = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(size,size,size);
        if (active) {
            circle.color = Color.green;
        }
        else {
            circle.color = Color.red;
        }
    }
}
