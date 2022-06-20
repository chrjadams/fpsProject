using UnityEngine;
using System.Collections;

public class gunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;
    public float spreadFactor;
    private float scopedSpreadFactor;
    private float initSpreadFactor;




    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public ParticleSystem tracer;
    public GameObject impactEffect;
    
    public Animator animator;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;


    //public Animator recoilAnimator;
    private bool isFired = false;

    private float nextTimeToFire = 0f;
    public bool isScoped = false;
    
    public Camera mainCam;
    public float scopedFOV;
    private float initFOV;
    //private float initSens; 

    void Start() {
        initFOV = mainCam.fieldOfView;
        scopedSpreadFactor = spreadFactor / 4;
        initSpreadFactor = spreadFactor;
}
    
    // Update is called once per frame
    void Update()
    {
        //firing logic (full auto)
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) {
            nextTimeToFire = Time.time + 1f / fireRate;
            
            animator.SetBool("isFired", true);
            Shoot();
            //mainCam.transform.localRotation = Quaternion.Euler(1, 1, 0);
        }

        if (Input.GetButtonUp("Fire1")) {
            animator.SetBool("isFired", false);
        }


        //scoping logic
        if (Input.GetButton("Fire2"))
        {
            isScoped = true;
            //Debug.Log(isScoped);
            animator.SetBool("isScoped", isScoped);
        }
        if (!Input.GetButton("Fire2"))
        {
            isScoped = false;
            animator.SetBool("isScoped", isScoped);
        }
        Debug.Log("isScoped ="+ isScoped);
            scopeOverlay.SetActive(isScoped); 
        if (isScoped)
            StartCoroutine(onScoped());

        else
            onUnscoped();

    }//end update()

    void Shoot() {
        RaycastHit hit;
        muzzleFlash.Play();
        tracer.Play();
        if (isScoped) {
            spreadFactor = scopedSpreadFactor;
        }

        //fpsCam.transform.localRotation = Quaternion.Euler(10, 0, 0);
        Vector3 direction = fpsCam.transform.forward;
        direction.x += Random.Range(-spreadFactor, spreadFactor);
        direction.y += Random.Range(-spreadFactor, spreadFactor);
        direction.z += Random.Range(-spreadFactor, spreadFactor);
        //isFired = true;
        //animator.SetBool("isFired", true);

        if (Physics.Raycast(fpsCam.transform.position, direction, out hit, range)) {
            //Debug.Log(hit.transform.name);
            target target = hit.transform.GetComponent<target>();
            targetScript target2 = hit.transform.GetComponent<targetScript>();
            if (target != null) {
                target.TakeDamage(damage);
            }

            if (target2 != null)
            {
                target2.TakeDamage(damage);
            }

            if (hit.rigidbody != null) {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }//end damage if()
        spreadFactor = initSpreadFactor;
    }//end Shoot()

    IEnumerator onScoped() {
        yield return new WaitForSeconds(.05f);
        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);
        mainCam.fieldOfView = scopedFOV;
    }

    void onUnscoped() {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
        Debug.Log("initFOV = " + initFOV);
        mainCam.fieldOfView = initFOV;
    }

}//end gunScript
