using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 목적 : 키보드 입력에 따라서 플레이어 이동 처리를 하고 싶다.
    // 플레이어의 키보드 입력은 계속해서 받는 것이기에 Update에 작성

    // 필요 필드:
    public float Speed;
    float borderLeft = -2.3f;
    float borderRight = 2.3f;
    float borderUp = 0f;
    float borderUnder = -5f;
    
    // 매 프레임마다 실행된다.
    // 초당 프레임 실행 횟수는 : 별다른 설정이 없을 경우 가능한 많이 (컴퓨터 성능에 따라, 환경에 따라 다름)
    
    public void Update()
    {
        // 1. 키보드 입력을 받는다.
        // 1.1 
        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     
        // }
        
        // Debug.Log("왼쪽 방향키를 누르는 중");
        
        // 1.2 
        float h = Input.GetAxisRaw("Horizontal"); // 키보드 좌/우 입력 상태에 따라 -1f ~ 1f
        float v = Input.GetAxisRaw("Vertical"); // 키보드 위/아래 입력 상태에 따라 -1f ~ 1f
        
        Debug.Log($"h:{h}, v:{v}");
        
        // 실습 과제 1
        // if ((h != 0) && (transform.position.x < borderLeft || transform.position.x > borderRight))
        // {
        //     h = h * -1;
        // }
        //
        // if((v != 0) && (transform.position.y > borderUp || transform.position.y < borderUnder))
        // {
        //     v = v * -1;
        // }
        
        // 실습 과제 2
        if ((h != 0) && (transform.position.x < borderLeft || transform.position.x > borderRight))
        {
            transform.position = new Vector2(transform.position.x * -1, transform.position.y);
        }
        
        if((v != 0) && (transform.position.y > borderUp || transform.position.y < borderUnder))
        {
            if (transform.position.y > borderUp)
            {
                transform.position = new Vector2(transform.position.x, borderUnder);
            }
            else if (transform.position.y < borderUnder)
            {
                transform.position = new Vector2(transform.position.x, borderUp);
            }
        }
        
        Vector2 direction = new Vector2(h, v);
        
        // 실습 과제 3
        if (Input.GetKeyDown(KeyCode.E))
        {
            Speed += 0.1f;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Speed -= 0.1f;
        }
        
        // 2. 키보드 입력에 따라 방향을 구한다.
        // 게임에는 벡터라는 타입이 있다. 벡터는 크기와 방향을 의미한다.
        // Vector2 direction = new Vector2(h, v); // 왼쪽 방향
        // Vector2 dircetion = Vector2.left; 내부적으로는 위와 같은 값
        // GameObject의 위치를 바꾸려면 Transform의 Position을 바꾸어 주면 된다.
            
            
        // 3. 방향과 속도에 따라 이동한다.
        // 속도 = 방향 * 속력                      // 매직 넘버 : 보는 사람에 따라 의미가 달라질 수 있는 헷갈리는 숫자

        Vector2 normalizedSpeed = direction.normalized * Speed;
        transform.Translate( normalizedSpeed * Time.deltaTime);
        // deltaTime : 이전 프레임으로부터 지금 프레임까지 시간이 얼마나 지났는지 MS(밀리세컨즈)로 반환
        
        // 새로운 위치 = 현재 위치 + (방향 * 속력 * 시간)
        // transform.position += new Vector2(transform.position + (Vector3)direction * Speed * Time.deltaTime);
    }
}