using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))] //attribute
[RequireComponent(typeof(MeshFader))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(HealthComponent))]


public class EnemyBehavoir : MonoBehaviour {

    private Animator animator;
    private MeshFader meshFader;
    private AudioSource audioSource;
    private HealthComponent healthComponent;
    [SerializeField]
    private AudioClip hurtClip; 

    private void Awake() {
        animator = GetComponent<Animator>();
        meshFader = GetComponent<MeshFader>();
        audioSource = GetComponent<AudioSource>();
        healthComponent = GetComponent<HealthComponent>();
    }
    private void OnEnable()
    {
        StartCoroutine(meshFader.FadeIn());  //
        healthComponent.Init(100);  //初始化時100血量
    }

    public void DoDamage(int attack) {  
        animator.SetTrigger("hurt");    //被攻擊時觸發
        audioSource.clip = hurtClip;
        audioSource.Play();
        healthComponent.Hurt(attack);
    }

    private void Update() {
        if (healthComponent.IsOver) {
            return;
        }
        if (Input.GetButtonDown("Fire1")) {
            DoDamage(10);  //一次扣血量
        }
    }

}
