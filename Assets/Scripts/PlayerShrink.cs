using UnityEngine;

public class PlayerShrink : MonoBehaviour
{
    [SerializeField] private float shrinkDuration = 5f; //The shrink will last for 5 seconds
    [SerializeField] private Transform visuals; //This is in the inspector, drag the player head here so the collectable doesn't shrink with it
    [SerializeField] private Vector3 shrinkScale = new Vector3(0.5f, 0.5f, 1f);

    private Vector3 normalScale;
    private float shrinkTimer;

    private void Awake()
    {
        normalScale = visuals.localScale;
    }

    private void Update()
    {
        if (shrinkTimer > 0f)
        {
            shrinkTimer -= Time.deltaTime;
            if (shrinkTimer <= 0f)
            visuals.localScale = normalScale;
        }
    }

    public void ShrinkPlayer()
    {
        visuals.localScale = shrinkScale;
        shrinkTimer = shrinkDuration;
    }   
}

