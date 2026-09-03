using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표: 스페이스바를 누를 때마다 총알을 생성해서 발사하고 싶다.
    // 필요 속성
    // - 총알 프리팹
    public GameObject BulletPrefab;
    public GameObject SubBulletPrefab;

    // - 생성 위치(총구)
    public Transform FirePointLeft;
    public Transform FirePointRight;    
    
    public Transform SubFirePointLeft;
    public Transform SubFirePointRight;

    public float FireRate;
    public float FireCoolTime = 0;
    
    public float SubFireRate;
    public float SubFireCoolTime = 0;

    public  bool isAuto = false;
        
    private void Update()
    {
        Fire();
        AutoFire();
    }

    private void Fire()
    {
        FireCoolTime += Time.deltaTime;
        SubFireCoolTime += Time.deltaTime;

        // 1. 스페이스바를 누르면
        if ((Input.GetKey(KeyCode.Space) || isAuto))
        {
            if(FireCoolTime >= FireRate)
            {
                // 2. 총알 프리팹을 생성한다.
                // Instantiate는 프리팹을 복사해서 (MonoBehavior를 상속받는) 게임 오브젝트를 생성하고 씬에 넣어주는 기능
                // 클래스로부터 객체를 만드는 과정을 인스턴트화(Instantiate)
                GameObject bulletLeft = Instantiate(BulletPrefab);
                bulletLeft.transform.position = FirePointLeft.position;

                GameObject bulletRight = Instantiate(BulletPrefab);
                bulletRight.transform.position = FirePointRight.position;            

                FireCoolTime = 0;
            }

            if (SubFireCoolTime >= SubFireRate)
            {
                GameObject subBulletLeft = Instantiate(SubBulletPrefab);
                subBulletLeft.transform.position = SubFirePointLeft.position;

                GameObject subBulletRight = Instantiate(SubBulletPrefab);
                subBulletRight.transform.position = SubFirePointRight.position;

                SubFireCoolTime = 0;
            }

        }
    }

    private void AutoFire()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isAuto = !isAuto;
        }
        
    }
}
