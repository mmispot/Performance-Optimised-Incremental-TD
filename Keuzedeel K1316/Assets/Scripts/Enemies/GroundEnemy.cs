using UnityEngine;

public class GroundEnemy : BaseEnemy
{
    private float timer = 3f;
    private SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f && spriteRenderer.enabled)
        {
            spriteRenderer.enabled = false;
            timer = 3f;
        } else if (timer <= 0f && !spriteRenderer.enabled)
        {
            spriteRenderer.enabled = true;
            timer = 3f;
        }
    }
}
