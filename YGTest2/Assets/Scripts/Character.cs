using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour {
    private CharacterController controller;
    private Animator animator;
    public float Speed;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Vector3 move = Vector3.ClampMagnitude(new Vector3(0, 0, v), 1);
        if (animator.GetBool("Attack") == true)
            move = Vector3.zero;
        if (v != 0 || h != 0)
        {
            controller.Move(transform.TransformVector(move) * (Time.deltaTime * Speed));
            transform.Rotate(Vector3.up * h * Time.deltaTime * 180);
        }
        if (Input.GetKeyUp(KeyCode.Space))
            animator.SetBool("Attack", true);
        animator.SetFloat("y", move.z);
    }
    public void DesAttack()
    {
        animator.SetBool("Attack", false);
    }
}
