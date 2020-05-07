using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chacarter : MonoBehaviour

{
    public float jumpForce = 6f;
    private bool isGrounded = false;
    public bool jump;
    private Animator anim;
    public AudioClip jump_sound;
    public AudioClip lose_sound;
    private Rigidbody2D body;
    private gameconroller gm;
    private SpriteRenderer sprite;
    
        public bool lose = false;
    private CharStaye State


    //public bool jum = false;
    {
        get { return (CharStaye)anim.GetInteger("State"); }

        set { anim.SetInteger("State", (int)value); }
    }
    // Start is called before the first frame update
    void Start()
    {
        State = CharStaye.walk;
    }
    private void Awake()
    {
        gm = GetComponent<gameconroller>();
        sprite = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
      //  gm.lose_panel();

    }
    void FixedUpdate()
    {
        CheckGround();
        if (isGrounded && !lose)
        {
            State = CharStaye.walk;
            jump = true;
            

        }
        if (isGrounded && lose)
        {
            State = CharStaye.povrezd;
            jump = false;


        }
        if (!isGrounded) { State = CharStaye.jump; jump = false; }

        if (Input.GetMouseButtonDown(0)&& jump) { Jump(); }
    }
    private void Jump()
    {
        body.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        MakeSound(jump_sound);
        //soundscipt.Instance.MakejumpSound();
        // State = CharStaye.jump;
    }

        void OnTriggerEnter2D(Collider2D collider)
        {

            // PlayerPrefs.SetInt("relese", 0);
           if (collider.tag == "enimy")
            {
            lose = true;
            MakeSound(lose_sound);
            PlayerPrefs.SetInt("L", 1);


        }
        }
    private void CheckGround()// проверка земли
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position - transform.up * 0.5f, 0.3f); // берем текущию позицию  икрока и радиус его колайдера
        isGrounded = colliders.Length > 1;
    }

    private void MakeSound(AudioClip originalClip)
    {
        
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
    public enum CharStaye
    {

        Idle,
        walk,
        jump,
        fall,
        povrezd
    }


