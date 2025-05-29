using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ObjectPusher : MonoBehaviour
{
    [SerializeField] LayerMask layerToPush;
    [SerializeField] float pushStrength = 20;


    void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.layer != layerToPush) return;

        if(collision.TryGetComponent(out Rigidbody2D rb))
        {
            var direction = transform.position.x - collision.transform.position.x;
            rb.AddForce((direction > 0 ? Vector3.left : Vector3.right) * pushStrength,ForceMode2D.Impulse);
        }
    }
}
