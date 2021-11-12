using UnityEngine;

public class MuestraArma : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,
            transform.eulerAngles.y + Time.deltaTime * speed, transform.eulerAngles.z);
    }
}