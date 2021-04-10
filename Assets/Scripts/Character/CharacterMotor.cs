using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class CharacterMotor : MonoBehaviour
    {
        private bool IsActive = true;

        // Rotation Variables
        [SerializeField] private float HorizontalRotationSpeed = 720f;
        [SerializeField] private float VerticalRotationSpeed = 180f;
        [SerializeField] private Transform FollowTargetTransform = null;
        [SerializeField] private Vector2 MouseDelta = Vector2.zero;

        // Movement Variables
        [SerializeField] private float Acceleration = 4f;
        [SerializeField] private float WalkSpeed = 4f;
        [SerializeField] private float RunSpeed = 6f;
        private float CurrentSpeed
        {
            get
            {
                return PlayerController.IsRunning ? RunSpeed : WalkSpeed;
            }
        }
        [SerializeField] private float JumpForce = 5f;
        [SerializeField] private bool CanJump = false;

        private Vector2 MovementInput = Vector2.zero;
        private Vector3 CurrentMoveDirection = Vector3.zero;

        private bool DoJump = false;

        // External References
        private Animator PlayerAnimator = null;
        private PlayerController PlayerController = null;
        private Rigidbody PlayerRigidbody = null;
        private Transform PlayerTransform = null;

        //Animator Hashes
        private readonly int MovementXHash = Animator.StringToHash("MovementX");
        private readonly int MovementZHash = Animator.StringToHash("MovementZ");
        private readonly int IsRunningHash = Animator.StringToHash("IsRunning");
        private readonly int IsJumpingHash = Animator.StringToHash("IsJumping");

        private void Awake()
        {
            PlayerController = GetComponent<PlayerController>();
            PlayerAnimator = GetComponent<Animator>();
            PlayerRigidbody = GetComponent<Rigidbody>();

            PlayerTransform = transform;
        }

        private void Update()
        {
            if (!IsActive)
            {
                return;
            }

            UpdateMovement();
            UpdateJump();
            UpdateLook();
            UpdateAnimation();
        }

        #region Update

        public void UpdateMovement()
        {
            if (PlayerController.IsJumping)
            {
                return;
            }

            Vector3 TargetMoveDirection = PlayerTransform.forward * MovementInput.y + PlayerTransform.right * MovementInput.x;

            CurrentMoveDirection = Vector3.Lerp(CurrentMoveDirection, TargetMoveDirection, Acceleration);

            PlayerTransform.position += CurrentMoveDirection * CurrentSpeed * Time.deltaTime;
        }

        public void UpdateJump()
        {
            if (DoJump)
            {
                PlayerController.IsJumping = true;
                PlayerAnimator.SetBool(IsJumpingHash, true);
                PlayerRigidbody.AddForce((transform.up + CurrentMoveDirection) * JumpForce, ForceMode.Impulse);
                DoJump = false;
            }
        }

        public void UpdateLook()
        {
            FollowTargetTransform.localEulerAngles += new Vector3(-1 * MouseDelta.y * Time.deltaTime * VerticalRotationSpeed, 0, 0);

            PlayerTransform.localEulerAngles += new Vector3(0, MouseDelta.x * Time.deltaTime * HorizontalRotationSpeed, 0);

            MouseDelta = Vector2.zero;
        }

        public void UpdateAnimation()
        {
            if (PlayerAnimator.GetBool(IsRunningHash) != PlayerController.IsRunning)
            {
                PlayerAnimator.SetBool(IsRunningHash, PlayerController.IsRunning);
            }

            PlayerAnimator.SetFloat(MovementXHash, MovementInput.x);
            PlayerAnimator.SetFloat(MovementZHash, MovementInput.y);
        }

        #endregion

        #region Input Capture

        public void OnMovement(InputValue value)
        {
            if (!IsActive)
            {
                return;
            }
            MovementInput = value.Get<Vector2>();
        }

        public void OnRun(InputValue button)
        {
            if (!IsActive)
            {
                return;
            }
            PlayerController.IsRunning = button.isPressed;
        }

        public void OnJump(InputValue button)
        {
            if (!IsActive || !CanJump)
            {
                return;
            }
            DoJump = true;
        }

        public void OnLook(InputValue delta)
        {
            if (!IsActive)
            {
                return;
            }
            MouseDelta = delta.Get<Vector2>();
        }

        #endregion

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Ground") && !PlayerController.IsJumping) return;

            PlayerController.IsJumping = false;
            PlayerAnimator.SetBool(IsJumpingHash, false);
        }
    }
}
