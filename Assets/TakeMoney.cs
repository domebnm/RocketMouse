using UnityEngine;

public class TakeMoney : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "money") { Debug.Log("Money"); Destroy(collision.gameObject); }
    }
}
