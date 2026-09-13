using UnityEngine;
[ExecuteAlways]

public class Squares : MonoBehaviour
{
    public int size = 1;
    private SpriteRenderer square;
    [HideInInspector] public bool active = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnValidate()
    {
        Refresh();
    }
    public void Refresh() {
        square = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(size,size,size);
        if (active) {
            square.color = Color.green;
        }
        else {
            square.color = Color.red;
        }
    }
}
