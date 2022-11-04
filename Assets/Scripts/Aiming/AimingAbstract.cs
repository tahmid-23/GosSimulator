using UnityEngine;

namespace Aiming
{
    public class AimingAbstract : MonoBehaviour
    {
        private Transform _player;
        private const int R = 5;
        
        public float Angle { get; private set; }

        private void Awake()
        {
            _player = GetComponent<Transform>();
        }

        public void DrawTestCone(float angleLow, float angleHigh)
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

        public static float ClampAngle(float angle, float from, float to)
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

        public void setAngle(float new_angle)
        {
            Angle = new_angle;
        }

        public float getAngle()
        {
            return Angle;
        }
    }
}