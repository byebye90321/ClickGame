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
    [SerializeField]
    private AudioClip deadClip;
    public EnemyData enemyData;
    public bool IsDead {
        get {
            return healthComponent.IsOver; 
        }
    }

    private void Awake() {
        animator = GetComponent<Animator>();
        meshFader = GetComponent<MeshFader>();
        audioSource = GetComponent<AudioSource>();
        healthComponent = GetComponent<HealthComponent>();
    }
    private void OnEnable()
    {
        StartCoroutine(meshFader.FadeIn());  //
        
    }

    [ContextMenu("Text Execute")]
    private void TestExecute() {
        StartCoroutine(Execute(enemyData));
    }

    public IEnumerator Execute(EnemyData enemyData) {  //寫入資料
        healthComponent.Init(enemyData.health);  //讀入血量
        while (IsDead == false) {
            yield return null; //等待
        }
        animator.SetTrigger("die");
        audioSource.clip = deadClip;
        audioSource.Play();
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        yield return StartCoroutine(meshFader.FadeOut());
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
