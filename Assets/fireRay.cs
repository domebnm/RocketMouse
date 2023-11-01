using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class fireRay : MonoBehaviour
{
    [SerializeField] float timePlay;
    float now_time = 0f;

    Animator anim;
    bool valueAnim;

    Collider2D coll;
    private void Start()
    {
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        valueAnim = anim.GetBool("bool");
    }
    private void Update()
    {
        if(now_time < timePlay)
        {
            now_time += Time.deltaTime;
        }
        else
        {
            now_time = 0f;
            valueAnim = !valueAnim;
            anim.SetBool("bool", valueAnim);
            coll.enabled = valueAnim;
        }
    }
}
