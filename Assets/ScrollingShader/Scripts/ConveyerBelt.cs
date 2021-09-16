using UnityEngine;

namespace nickmaltbie.ScrollingShader
{
    public enum RelativeDirection
    {
        Up,
        Down,
        Left,
        Right,
        Forward,
        Backward
    }

    /// <summary>
    /// Conveyer belt that has a uniform direction and speed
    /// </summary>
    public class ConveyerBelt : MonoBehaviour
    {
        [SerializeField]
        private float velocity;

        [SerializeField]
        private RelativeDirection direction = RelativeDirection.Down;

        public Vector3 GetDirection()
        {
            switch (this.direction)
            {
                case RelativeDirection.Up:
                    return transform.up;
                case RelativeDirection.Down:
                    return -transform.up;
                case RelativeDirection.Left:
                    return -transform.right;
                case RelativeDirection.Right:
                    return transform.right;
                case RelativeDirection.Forward:
                    return transform.forward;
                case RelativeDirection.Backward:
                    return -transform.forward;
            }
            return transform.forward;
        }

        public void OnCollisionStay(Collision other)
        {
            if (other.rigidbody != null && !other.rigidbody.isKinematic)
            {
                Vector3 movement = velocity * GetDirection() * Time.deltaTime;
                other.gameObject.GetComponent<Rigidbody>().MovePosition(
                    other.gameObject.transform.position + movement);
            }
        }
    }
}