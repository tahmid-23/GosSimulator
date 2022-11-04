using Movement;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{

    private Transform _player;
    private MovementGos _movementGos;
    public Camera camera;
    public bool Aiming { get; private set; }
    public float Angle { get; private set; }
    
    private const int R = 5;

    // Start is called before the first frame update
    private void Start()
    {
        Aiming = false;
        _player = transform;
        _movementGos = GetComponent<MovementGos>();
        Angle = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Aiming = !Aiming;
        }

        if (Aiming)
        {
            float direction = _movementGos.direction;
            float angleLow = direction - Mathf.PI / 8;
            float angleHigh = direction + Mathf.PI / 8;

            DrawTestCone(direction, angleLow, angleHigh);
            Angle = ClampAngle(GetAngle(), angleLow, angleHigh);
            Vector3 endpoint = R * new Vector3(Mathf.Cos(Angle), Mathf.Sin(Angle));
            Debug.DrawRay(_player.position, endpoint, Color.red, Time.deltaTime);
        }
    }

    private float GetAngle()
    {
        Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerPos = _player.position;
        float dx = mousePos.x - playerPos.x;
        float dy = mousePos.y - playerPos.y;

        return Mathf.Atan2(dy, dx);
    }

    private void DrawTestCone(float angle, float angleLow, float angleHigh)
    {
        Vector3 dirLow = R * new Vector3(Mathf.Cos(angleLow), Mathf.Sin(angleLow));
        Vector3 dirHigh = R * new Vector3(Mathf.Cos(angleHigh), Mathf.Sin(angleHigh));
        
        Vector3 position = _player.position;
        Debug.DrawRay(position, dirLow, Color.black, Time.deltaTime);
        Debug.DrawRay(position, dirHigh, Color.black, Time.deltaTime);
    }

    private static float FixAngle360(float angle)
    {
        if (angle < 0)
        {
            return angle + 2 * Mathf.PI;
        }

        if (angle >= 360)
        {
            return angle - 2 * Mathf.PI;
        }

        return angle;
    }

    private static float FixAngle180(float angle)
    {
        if (angle > Mathf.PI)
        {
            return angle - 2 * Mathf.PI;
        }

        return angle;
    }

    private static float ClampAngle(float angle, float from, float to)
    {
        from = FixAngle360(from);
        to = FixAngle360(to);
        angle = FixAngle360(angle);
        float mid = FixAngle180(from + FixAngle360(to - from) / 2);
        float fromNye = FixAngle180(from - mid);
        float toNye = FixAngle180(to - mid);
        float angleNye = FixAngle180(angle - mid);

        return Mathf.Clamp(angleNye, fromNye, toNye) + mid;
    }

}
