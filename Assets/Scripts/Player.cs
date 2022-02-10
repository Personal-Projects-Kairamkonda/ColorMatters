#region Using Statements
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
#endregion

namespace Robot
{
    public class Player : MonoBehaviour
    {
        [Header("Movement Settings")]
        [Range(5f, 10f)]
        public float speed = 5f;
        public float force;
     
        [Header("Jump Settings")]
        public LayerMask mask;
        private float distanceToGround = 0.1f;

        [Header("Gun Settings")]
        public Transform Gun;

        public bool canJump;
        public bool tempMove;

        #region Player Components

        Rigidbody rbody;

        #endregion Player Components

        #region Unity functions

        private void Awake()
        {
            rbody = this.GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if (tempMove)
                tempMovement();
            else
                Movement();
        }

        void Update()
        {
            if(canJump)
                Jump();

            ReloadGame();
        }

        #endregion Unity functions

        /// <summary>
        /// Player Movement based on horizontal axis and vertical axis
        /// </summary>
        public void Movement()
        {
            float xPos = Input.GetAxis("Horizontal");
            float zPos = Input.GetAxis("Vertical");

            Vector3 temp = new Vector3(zPos, 0, -xPos);

            rbody.MovePosition(temp * speed * Time.deltaTime + transform.position);

        }

        /// <summary>
        /// Player Jump multipled with the force
        /// Checking the player if player is not ground with raycast
        /// </summary>
        public void Jump()
        {
            if(Input.GetKeyDown(KeyCode.Space)&& GetInfo()=="Terrain")
            {
                rbody.AddForce(Vector3.up * force);
            }
        }

        /// <summary>
        /// Reloading the scene for a new game to reset positions and data
        /// </summary>
        public void ReloadGame()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Game");
            }
        }

        #region Collider Functions

        private void OnCollisionEnter(Collision collision)
        {
            PowerUp powerUp = collision.gameObject.GetComponent<PowerUp>();

            if (powerUp!=null)
            {
                StartCoroutine(powerUp.ChangeToSphere(3,this.transform));
            }

        }

        #endregion Collider Functions

        /// <summary>
        ///  information of the collided object name with the raycast
        /// </summary>
        public string GetInfo()
        {
            RaycastHit hitInfo;
            string objectName;

            bool hit=Physics.Raycast(transform.position, -Vector3.up, out hitInfo, 0.5f+ distanceToGround, mask);

            Debug.DrawRay(transform.position, -Vector3.up,Color.red, distanceToGround + 0.5f);

            if (hit)
                return objectName = hitInfo.transform.gameObject.name;
            else
                return null;
        }

        #region Basic code

        /// <summary>
        /// temporary movement
        /// </summary>
        public void tempMovement()
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-transform.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(transform.forward * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(-transform.forward * speed * Time.deltaTime);
            }
        }

        #endregion

    }
}
