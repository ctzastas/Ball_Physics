using UnityEngine;

public class PlatformRaycast : MonoBehaviour {
    
    private float minHeight = 2.5f;
    private float forceBoost = 50f;
    private Rigidbody platform;

    // Start is called before the first frame update
    void Start() {
        platform = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {
       CheckHeight();
    }

    void CheckHeight() {
        RaycastHit hit;
        Ray distance = new Ray (transform.position, Vector3.down);
        Debug.DrawRay (transform.position, Vector3.down, Color.red);
        if (Physics.Raycast (distance, out hit, minHeight)) {
            if (hit.collider != null) {
                platform.AddForce (Vector3.up * forceBoost);
            }
        }
    }
}
