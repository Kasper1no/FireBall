using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rigibody;
    [SerializeField] private float bounceForce;
    [SerializeField] private float bounceRadius;
    [SerializeField] private int minMaxBounceDirection;
    [SerializeField] private int delayAfterBounce;
    
    public Rigidbody Rigidbody => rigibody;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Block block))
        {
            block.Destroy();
            gameObject.SetActive(false);
        }

        if (other.TryGetComponent(out Obstacle obstacle))
        {
            Bounce();
        }
    }

    private void Bounce()
    {
        rigibody.velocity = Vector3.zero;

        var randomVectorRight = new Vector3(Random.Range(-minMaxBounceDirection,minMaxBounceDirection),0,0);
        var bounceDirection = transform.position - randomVectorRight;
            
        rigibody.AddExplosionForce(bounceForce, bounceDirection, bounceRadius);

        StartCoroutine(DisableAfterBounce());
    }

    private IEnumerator DisableAfterBounce()
    {
        yield return new WaitForSeconds(delayAfterBounce);
        
        gameObject.SetActive(false);
    }
}
