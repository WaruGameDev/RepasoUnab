using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyFollowController : MonoBehaviour
{
    public Transform model;
    public enum EnemyState
    {
        WAITING,
        ATTACKING,
        WAITING_ON_ATTACKED_SPOT,
        COMEBACK         
    }
    public EnemyState enemyState = EnemyState.WAITING;
    public Vector2 posicionInicial, playerSpot;
    public float timeToAtack = 4;
    private Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();

        posicionInicial = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && enemyState == EnemyState.WAITING)
        {
            playerSpot = other.transform.position;
            enemyState = EnemyState.ATTACKING;
            StartCoroutine(Attacking());
        }
    }
    public IEnumerator Attacking()
    {
        transform.DOMove(playerSpot, timeToAtack);
        yield return new WaitForSeconds(timeToAtack);
        enemyState = EnemyState.WAITING_ON_ATTACKED_SPOT;
        StartCoroutine(ComeBack());
        yield break;
    }
    public IEnumerator ComeBack()
    {
        transform.DOMove(posicionInicial, timeToAtack/2);
        yield return new WaitForSeconds(timeToAtack/2);
        enemyState = EnemyState.WAITING;
        col.enabled = false;
        yield return new WaitForSeconds(0.1f);
        col.enabled = true;

        yield break;
    }
}
