using UnityEditor;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform playerTr;
    float offsetX;

    [SerializeField] SpriteRenderer rendererGr;
    [SerializeField] float speedX;
    private void Start()
    {
        offsetX = transform.position.x - playerTr.position.x;
    }
    private void Update()
    {
        transform.position = new Vector3(playerTr.position.x + offsetX, transform.position.y, transform.position.z);
        rendererGr.material.mainTextureOffset += new Vector2(speedX * Time.deltaTime, 0f);
    }
}
