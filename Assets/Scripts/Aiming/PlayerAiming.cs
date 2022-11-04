using Movement;
using UnityEngine;
using Aiming;

public class PlayerAiming : MonoBehaviour
{
    private MovementGos _movementGos;
    private bool _isAiming;
    public AimingAbstract _aimingAbstract;
    public Camera camera;
    private Transform _player;

    // Start is called before the first frame update
    private void Start()
    {
        _isAiming = false;
        _movementGos = GetComponent<MovementGos>();
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
            _aimingAbstract.drawCones(direction);
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

    public float getAngle()
    {
        return _aimingAbstract.getAngle();
    }
    
    public bool IsAiming()
    {
        return _isAiming;
    }
}
