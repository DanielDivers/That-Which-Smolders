using UnityEngine;

//base for every object that we can interact with
public class Interactable : MonoBehaviour {

    //radius we can interact with object
    public float radius = 3f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
