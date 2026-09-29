using UnityEngine;

public class TowerClick : MonoBehaviour
{
    private Collider2D collider2D;

    void Start()
    {
        collider2D = GetComponent<Collider2D>();
    } 
    void Update()
    {
        if(Input.GetMouseButtonDown(8))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (collider2D.OverlapPoint(mousePosition))
            {
                Debug.Log("Mouse is over the collider of " + gameObject.name);
            }
        }
    }
}
