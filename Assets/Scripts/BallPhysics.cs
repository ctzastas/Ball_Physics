using UnityEngine;

public class BallPhysics : MonoBehaviour {
    
    private float power = 3f;
    private float radius = 2f;
    private float speed = 700f;
    private float explosionSpeed = 100f;
    private float rotSpeed = 200f;
    private Rigidbody ball;                                
    [SerializeField] LayerMask explosionLayers;

    // Start is called before the first frame update
    void Start() {
        ball = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision) {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius, explosionLayers);
        foreach (Collider hit in colliders) {
            ball = hit.GetComponent<Rigidbody>();
            if (ball != null) {
                ball.AddExplosionForce(power, explosionPos, radius, 1f, ForceMode.Impulse);
            }
        }
    }

    void OnCollisionStay(Collision collision) {
        if (collision.collider.gameObject.CompareTag("Platform")) {
            ball.AddForce(Vector3.right * speed, ForceMode.Force);
        }
        if (collision.collider.gameObject.CompareTag("Platform3")) {
            ball.AddTorque(Vector3.forward * rotSpeed, ForceMode.Impulse);
        }
    }
    
    void OnCollisionExit(Collision collision) {
        if (collision.collider.gameObject.CompareTag("Platform2")) {
            ball.AddForce(Vector3.left * speed, ForceMode.Force);
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Wall")) {
            ball.AddTorque(Vector3.back * rotSpeed, ForceMode.Acceleration);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Wall")) {
            ball.AddForce(Vector3.right * explosionSpeed, ForceMode.Impulse);
        }
    }
}
