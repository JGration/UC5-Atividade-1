using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Animator anim;
    private Rigidbody2D rb2d;
    private float shootingRate = 0.1f;
    private float shootCooldown = 0f;
    public Transform posPe;
    public Transform spawnBullet;
    public GameObject bullet;
    public float Velocidade;
    public float ForcaPulo = 1000f;
    [HideInInspector] public bool viradoDireita = true;
    [HideInInspector] public bool tocachao = false;
    [HideInInspector] public bool jump;

    public Image vida;
    private MensagemControle MC;

    void Start () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        GameObject mensagemControleObject = GameObject.FindWithTag ("MensagemControle");
		if (mensagemControleObject != null) {
			MC = mensagemControleObject.GetComponent<MensagemControle> ();
		}
	}

    // Codigos para tiro e pulo
    void Update()
    {
        if (shootCooldown > 0)
            shootCooldown -= Time.deltaTime;

        var forceX = 0f;
        var forceY = 0f;
        var absVelX = Mathf.Abs(rb2d.velocity.x);

        if (Input.GetKey("space"))
        {
            Fire();
            shootCooldown = shootingRate;
        }

        rb2d.AddForce(new Vector2(forceX, forceY));
        tocachao = Physics2D.Linecast(transform.position, posPe.position, 1 << LayerMask.NameToLayer("chao"));
        if (Input.GetKeyDown("up") && tocachao)
        {
            jump = true;
            sound.Play("Jump");
        }
    }

    void FixedUpdate()
    {
        float translationY = 0;
        float translationX = Input.GetAxis("Horizontal") * Velocidade;
        transform.Translate(translationX, translationY, 0);
        transform.Rotate(0, 0, 0);
        if (translationX != 0 && tocachao)
        {
            anim.SetTrigger("run");
            GetComponent<AudioSource>().UnPause();
            if (Input.GetKeyDown("space"))
            {
                anim.SetTrigger("shootrun");
            }
        }
        else
        {
            GetComponent<AudioSource>().Pause();
            if (Input.GetKeyDown("space"))
            {
                anim.SetTrigger("shoot");
            }

            else
            {
                anim.SetTrigger("idle");
            }
        }
        if (jump)
        {

            rb2d.AddForce(new Vector2(0f, ForcaPulo));
            anim.SetTrigger("jump");
            jump = false;
        }
        if (translationX > 0 && !viradoDireita)
            Flip();
        else if (translationX < 0 && viradoDireita)
            Flip();
    }
    //codigo para bala
    void Fire()
    {
        if (shootCooldown <= 0f)
        {
            if (bullet != null)
            {
                var cloneBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity) as GameObject;
                cloneBullet.transform.localScale = this.transform.localScale;
                sound.Play("Laser1");
            }
        }

    }

    void Flip()
	{
		viradoDireita = !viradoDireita;
		Vector3 escala = transform.localScale;
		escala.x *= -1;
		transform.localScale = escala;
	}

	public void SubtraiVida()
	{
		vida.fillAmount-=0.1f;
		if (vida.fillAmount <= 0) {
			MC.GameOver();
			Destroy(gameObject);
		}
	}
	
}
