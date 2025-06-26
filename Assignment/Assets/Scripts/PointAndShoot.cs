using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 target;
    public GameObject crosshairs;
    public GameObject Weapon;
    public GameObject bulletPrefab;
    public GameObject bulletStart;
    public PlayerController Player;
    public float bulletSpeed = 60.0f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {   
        // Croshair movement
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
      

        

        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 PlayerScale = Player.getTransformScale();
            Vector3 difference = target - Weapon.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            if (difference[0] < -3.33 && PlayerScale[0] > 0) {
                Player.transform.localScale = new Vector3(-0.3f, 0.3f, 1);
             //   if (PlayerScale[0] > 0) { Weapon.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ); Debug.Log("Shoot one"); }
             //   else { Weapon.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 180); Debug.Log("Shoot two"); }
                Debug.Log("Hello"); }
            else if (difference[0] > -3.33 && PlayerScale[0] < 0) {
                Player.transform.localScale = new Vector3(0.3f, 0.3f, 1);
             //   if (PlayerScale[0] > 0) { Weapon.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ); Debug.Log("Shoot one"); }
             //   else { Weapon.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 180); Debug.Log("Shoot two"); }
                Debug.Log("Hi"); }
            else
            {
                if (PlayerScale[0] > 0) { Weapon.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ); Debug.Log("Shoot one"); }
                else { Weapon.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 180); Debug.Log("Shoot two"); }
            }



            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction,rotationZ);
        }
    }
    void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f,0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().linearVelocity = direction*bulletSpeed;
    }
}
