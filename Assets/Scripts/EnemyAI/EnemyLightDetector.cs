using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLightDetector : MonoBehaviour
{
    public Transform enemyTransform;
    public float detectionRange = 5f;
    public float flickerSpeed = 0.5f;

    private bool isEnemyNearby = false;

    private void Update()
    {
        float distanceToEnemy = Vector3.Distance(transform.position, enemyTransform.position);

        if (distanceToEnemy <= detectionRange)
        {
            isEnemyNearby = true;
            StartCoroutine(Flicker());
        }
        else
        {
            isEnemyNearby = false;
            StopCoroutine(Flicker());
            gameObject.SetActive(true); // Ensure object is active when enemy is not nearby
        }
    }

    private IEnumerator Flicker()
    {
        while (isEnemyNearby)
        {
            gameObject.SetActive(!gameObject.activeSelf);
            yield return new WaitForSeconds(flickerSpeed);
        }
    }
}