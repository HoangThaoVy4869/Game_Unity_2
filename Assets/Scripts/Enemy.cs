using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody2D m_rb;

    GameController m_gc;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2.down = (0,-1)
        m_rb.velocity = Vector2.down * moveSpeed;
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Deathzone"))
		{
            m_gc.SetGameOver(true);
            Destroy(gameObject);
            Debug.Log("Enemy va cham voi DeathZone, GameOver");
		}
	}
}
