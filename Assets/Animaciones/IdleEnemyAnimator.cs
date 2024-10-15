using UnityEngine;

public class IdleEnemyAnimator : MonoBehaviour
{
    public Sprite[] idleSprites; // Asigna las imágenes en el Inspector
    public float frameRate = 0.1f; // Tiempo entre cambios de imagen

    private SpriteRenderer spriteRenderer;
    private int currentFrame;
    private float timer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentFrame = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            currentFrame = (currentFrame + 1) % idleSprites.Length;
            spriteRenderer.sprite = idleSprites[currentFrame];
            timer = 0f;
        }
    }
}
