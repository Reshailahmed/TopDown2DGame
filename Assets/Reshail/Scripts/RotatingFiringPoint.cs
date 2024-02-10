using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingFiringPoint : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        Vector2 targetDirection = player.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, 1f);
    }
}
