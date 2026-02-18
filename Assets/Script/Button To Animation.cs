using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonToAnimation : MonoBehaviour
{
    [SerializeField] GameObject model;
    [SerializeField] Button IdleButton;
    [SerializeField] Button SkillButton;
    [SerializeField] Button DeathButton;
    [SerializeField] Button ExitButton;


    Animator animator;
    private void Start()
    {
        animator = model.GetComponent<Animator>();

        IdleButton.onClick.AddListener(StartIdle);
        SkillButton.onClick.AddListener(StartSkill);
        DeathButton.onClick.AddListener(StartDeath);
        ExitButton.onClick.AddListener(Back);
    }

    void Back() => SceneManager.LoadScene(1);
    void StartIdle() => animator.SetTrigger("Idle");
    void StartSkill() => animator.SetTrigger("Skill");
    void StartDeath() => animator.SetTrigger("Death");
    
}
