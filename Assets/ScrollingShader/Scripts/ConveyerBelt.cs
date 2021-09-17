using UnityEngine;

namespace nickmaltbie.ScrollingShader
{
    /// <summary>
    /// Relative direction to face from a local transform.
    /// </summary>
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
    /// Conveyer belt that has a uniform direction and speed and will push objects that collide with it.
    /// </summary>
    public class ConveyerBelt : MonoBehaviour
    {
        /// <summary>
        /// Velocity of the conveyer belt in meters per second.
        /// </summary>
        [SerializeField]
        private float velocity;

        /// <summary>
        /// Direction that the conveyer belt pushes objects.
        /// </summary>
        [SerializeField]
        private RelativeDirection direction = RelativeDirection.Down;

        /// <summary>
        /// Get the world space direction that the conveyer belt will push objects.
        /// </summary>
        /// <returns>The direction in world space of teh conveyer belt, will be 1 unit long.</returns>
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

        private Vector3 position;
        private Rigidbody body;

        public void Start()
        {
            this.position = transform.position;
            this.body = GetComponent<Rigidbody>();
        }

        public void FixedUpdate()
        {
            Vector3 movement = velocity * GetDirection() * Time.deltaTime;
            body.MovePosition(this.position + movement);
            this.transform.position = this.position;
        }

        /// <summary>
        /// When colliding with an object, if it has a rigidbody and is not kinematic, push it forward by the speed of
        /// the conveyer belt.
        /// </summary>
        /// <param name="other">Collision event between the objects.</param>
        public void OnCollisionStay(Collision other)
        {
            // if (other.rigidbody != null && !other.rigidbody.isKinematic)
            // {
            //     Vector3 movement = velocity * GetDirection() * Time.deltaTime;
            //     other.rigidbody.MovePosition(other.transform.position + movement);
            // }
        }
    }
}