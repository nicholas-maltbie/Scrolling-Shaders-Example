using UnityEngine;

namespace nickmaltbie.ScrollingShader
{
    /// <summary>
    /// Conveyer belt that has a uniform direction and speed and will push objects that collide with it.
    /// </summary>
    public class ConveyerBelt : MonoBehaviour
    {
        /// <summary>
        /// How does this belt move objects, by pushing objects sitting
        /// on top of the belt or by "moving" the belt forward and pulling
        /// them forward with the object.
        /// </summary>
        public enum BeltForceMode
        {
            Push,
            Pull
        }

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
        /// Velocity of the conveyer belt in meters per second.
        /// </summary>
        [SerializeField]
        [Tooltip("Velocity of the conveyer belt.")]
        private float velocity;

        /// <summary>
        /// Direction that the conveyer belt pushes objects.
        /// </summary>
        [SerializeField]
        [Tooltip("Local direction does this push objects.")]
        private RelativeDirection direction = RelativeDirection.Down;

        /// <summary>
        /// Kind of force used to move objects. <see cerf="BeltForceMode" /> for more details on 
        /// how the belt force modes work.
        /// </summary>
        // [SerializeField]
        // [Tooltip("Belt force mode used to push physics objects in the scene.")]
        private BeltForceMode beltMode = BeltForceMode.Push;

        /// <summary>
        /// Rigidbody associated with conveyer belt.
        /// </summary>
        private Rigidbody body;

        /// <summary>
        /// Position of the conveyer belt.
        /// </summary>
        private Vector3 pos;

        /// <summary>
        /// Awake event to initialize belt configuration.
        /// </summary>
        public void Awake()
        {
            this.body = GetComponent<Rigidbody>();
            pos = transform.position;
        }

        /// <summary>
        /// Fixed update to move the belt and pull objects along with it.
        /// </summary>
        public void FixedUpdate()
        {
            if (body != null && beltMode == BeltForceMode.Pull)
            {
                Vector3 movement = velocity * GetDirection() * Time.fixedDeltaTime;
                transform.position = pos - movement;
                body.MovePosition(pos);
            }
        }

        /// <summary>
        /// When colliding with an object, if it has a rigidbody and is not kinematic, push it forward by the speed of
        /// the conveyer belt.
        /// </summary>
        /// <param name="other">Collision event between the objects.</param>
        public void OnCollisionStay(Collision other)
        {
            if (other.rigidbody != null && !other.rigidbody.isKinematic && beltMode == BeltForceMode.Push)
            {
                Vector3 movement = velocity * GetDirection() * Time.deltaTime;
                other.rigidbody.MovePosition(other.transform.position + movement);
            }
        }

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
    }
}