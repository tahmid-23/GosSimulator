using Movement;
using UnityEngine;
using Aiming;

public class PlayerAiming : MonoBehaviour
{
    private MovementGos _movementGos;
    private bool _isAiming;
    private AimingAbstract _aimingAbstract;
    public Camera camera;
    private Transform _player;

    // Start is called before the first frame update
    private void Start()
    {
        _isAiming = false;
        _movementGos = GetComponent<MovementGos>();
        _aimingAbstract = GetComponent<AimingAbstract>();
        _player = GetComponent<Transform>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            _isAiming = !_isAiming;
        }

        if (_isAiming)
        {
            float direction = _movementGos.direction;
            drawCones(direction);
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
    
    private void drawCones(float direction)
    {
        float angleLow = direction - Mathf.PI / 8;
        float angleHigh = direction + Mathf.PI / 8;
        
        _aimingAbstract.DrawTestCone(direction, angleLow, angleHigh);
        _aimingAbstract.setAngle(AimingAbstract.ClampAngle(GetAngle(), angleLow, angleHigh));
        Vector3 endpoint = new Vector3(5 * Mathf.Cos(getAngleHelper()), 5 * Mathf.Sin(getAngleHelper()), 0);
        Debug.DrawRay(_player.position, endpoint, Color.red, Time.deltaTime);
    }

    public float getAngleHelper()
    {
        return _aimingAbstract.getAngle();
    }
    
    public bool IsAiming()
    {
        return _isAiming;
    }
}
