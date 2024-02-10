using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrappleHook : MonoBehaviour
{
    LineRenderer line;

    [SerializeField] LayerMask enemyMask;
    [SerializeField] float maxDistance = 10f;
    [SerializeField] float grappleSpeed = 1f;
    [SerializeField] float grappleShootSpeed = 10f;
    private GameObject enemy;
    public Transform SwordPosition;
    public Transform grapplePosition;

    bool isGrappling = false;
    [HideInInspector] public bool retracting = false;

    Vector2 target;
    public ManaBar mana;
    public int currMana;
    private float timer = 0f;
    private float targetTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        currMana = 10;
        mana.SetMaxMana(currMana);
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.rightButton.wasPressedThisFrame && !isGrappling)
        {
            StartGrapple();
        }

        if (retracting)
        {
            Vector2 grapplePos = Vector2.Lerp(target, grapplePosition.position, grappleSpeed * Time.deltaTime);
            enemy.transform.position = Vector2.MoveTowards(SwordPosition.position,
                                                      enemy.transform.position,
                                                      grappleSpeed * Time.fixedDeltaTime);

            line.SetPosition(0, grapplePosition.position);
            line.enabled = false;
            retracting = false;
            isGrappling = false;
        }

        timer += Time.deltaTime;

        // If the timer exceeds the target time, set isTimerReached to true
        if (timer >= targetTime)
        {
            currMana += 1;
            mana.SetMana(currMana);
            timer = 0f;
        }
    }

    private void StartGrapple()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - grapplePosition.position;

        RaycastHit2D hit = Physics2D.Raycast(grapplePosition.position, direction, maxDistance, enemyMask);

        if(hit.collider != null)
        {
            enemy = hit.collider.gameObject;
            isGrappling = true;
            target = hit.point;
            line.enabled = true;
            line.positionCount = 2;
            currMana -= 2;
            mana.SetMana(currMana);

            StartCoroutine(Grapple());
        }
    }

    IEnumerator Grapple()
    {
        float t = 0f;
        float time = 10f;

        line.SetPosition(0, grapplePosition.position);
        line.SetPosition(1, grapplePosition.position);

        Vector2 newPos;

        for (; t < time; t += grappleShootSpeed * Time.deltaTime)
        {
            newPos = Vector2.Lerp(grapplePosition.position, target, t / time);
            line.SetPosition(0, grapplePosition.position);
            line.SetPosition(1, newPos);
            yield return null;
        }

        line.SetPosition(1, target);
        retracting = true;
    }
}
