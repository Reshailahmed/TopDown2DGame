using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class grappler : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer _lineRenderer;
    public DistanceJoint2D _distanceJoint;
    public Transform grapplePosition;
    public Transform SwordPosition;
    public ManaBar mana;
    private int currMana;

    private float timer = 0f;
    private float targetTime = 10f;
    public float moveSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        _distanceJoint.enabled = false;
        currMana = 10;
        mana.SetMaxMana(currMana);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame && currMana >= 2)
        {


            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            _lineRenderer.SetPosition(0, mousePos);
            _lineRenderer.SetPosition(1, grapplePosition.position);
            _distanceJoint.connectedAnchor = mousePos;
            _distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
            currMana -= 2;
            mana.SetMana(currMana);

            Ray ray = new Ray(transform.position, mousePos);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    // The ray hit an object with the "Enemy" tag
                    Debug.Log("Enemy hit!");

                    // Access the enemy gameObject
                    GameObject enemy = hit.collider.gameObject;

                    enemy.transform.position = Vector2.MoveTowards(SwordPosition.position,
                                                      hit.collider.transform.position,
                                                      moveSpeed * Time.fixedDeltaTime);
                }
            }
        }
        else if (Mouse.current.rightButton.wasReleasedThisFrame)
        {
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
        }
        if (_distanceJoint.enabled)
        {
            _lineRenderer.SetPosition(1, grapplePosition.position);
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
}