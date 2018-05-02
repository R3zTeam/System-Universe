using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intractable : MonoBehaviour {
    public float radius = 3f;

    public Transform player;
    bool isFocus = true;
    bool hasIntracted = false;

    public Transform intractionTransform;
    public virtual void Intearct() {
        Debug.Log("Anda Menemukan" + " " + transform.name);
    }
    void Update() {

        if (isFocus && !hasIntracted) {

            float distance = Vector3.Distance(player.position, intractionTransform.position);
            if(distance <= radius ){
               
                Intearct();
                hasIntracted = true;
            }
        }
    }
    void OnDrawGizmosSelected() {

        if(intractionTransform == null){
            intractionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(intractionTransform.position, radius);
    }
}
