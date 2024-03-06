using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Object : MonoBehaviour
{
    public GameObject vfxDestroy;

    public Vector2 dir;

    public float moveSpeed;

    private bool canMove;

    private Rigidbody2D rb;

    private void Start()
    {
        canMove = false;

        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        canMove = true;
    }

    private void Update()
    {
        if (!canMove) return;

        rb.velocity = dir * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Wall"))
        {
            GameObject vfx = Instantiate(vfxDestroy, transform.position, Quaternion.identity) as GameObject;

            Destroy(vfx, 1f);

            gameObject.SetActive(false);

            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);

            GameManager.Instance.CheckLevelUp();
        }
    }
}
