using UnityEngine;

public class CameraController : MonoBehaviour {


    public float panspeed = 30f;
    public float panborderthickness;
    public float scrollspeed = 5f;

    public float miny = 10f;
    public float maxy = 80f;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if(GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }
        if (Input.GetKey("w") || Input.mousePosition.y >=Screen.height-panborderthickness)
        {
            transform.Translate(Vector3.forward * panspeed * Time.deltaTime,Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panborderthickness)
        {
            transform.Translate(Vector3.back * panspeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panborderthickness)
        {
            transform.Translate(Vector3.right * panspeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.y <= panborderthickness)
        {
            transform.Translate(Vector3.left * panspeed * Time.deltaTime, Space.World);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        pos.y -= scroll * scrollspeed * Time.deltaTime * 1000;
        pos.y = Mathf.Clamp(pos.y, miny, maxy);
        transform.position = pos;
    }
}
