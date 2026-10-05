using UnityEngine;

public class TowerClick : MonoBehaviour
{
    private Collider2D collider2D;

    public TowerManager towerManagerScript;

    void Start()
    {
        towerManagerScript = GameObject.Find("TowerManager").GetComponent<TowerManager>();
        collider2D = GetComponent<Collider2D>();
    } 
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (collider2D.OverlapPoint(mousePosition))
            {
                towerManagerScript.OnSpotClicked(gameObject);
            }
        }
    }
}
