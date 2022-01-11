using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshRayMusic : MonoBehaviour
{
    private AudioSource audioSourceSpring;
    public AudioClip audioClipSpring; //public 으로 선언해줬으므로 , 에디터에서 봄 mp3파일 드래그해서 추가가 가능하다~
    //mp3 파일 더 넣고싶으면 public 변수로 이름만 다르게 선언해준 후 에디터에서 드래그해주면 됨! 

    private AudioSource audioSourceSummer;
    public AudioClip audioClipSummer;  //에디터에서 여름 mp3파일 드래그해서 추가해주면 됨~

    private AudioSource audioSourceAutumn;
    public AudioClip audioClipAutumn;  //에디터에서 가을 mp3파일 드래그해서 추가해주면 됨~

    private AudioSource audioSourceWinter;
    public AudioClip audioClipWinter;  //에디터에서 겨울 mp3파일 드래그해서 추가해주면 됨~

    void Start()
    {

    }


    void Update() //씬이 계속 업데이트 된다
    {
        var myRay = new Ray(transform.GetChild(0).position + new Vector3(0.0f, 0.1f, 0.0f), Vector3.down);
        //이 스크립트를 가지고 있는 주인(Player)의  첫 번째 자식(positionOfRay) 의 위치(transform.GetChild(0).position)에서, 
        //down 방향(0,-1,0)으로, 
        // 광선(myRay)를 쏜다.


        myRayCasting(myRay);
    }




    void myRayCasting(Ray ray)
    {

        RaycastHit hitObj;

        if (Physics.Raycast(ray, out hitObj, Mathf.Infinity))
        {
            // Physics.Raycast()를 실행하면, Ray 객체의 origin 에서 direction 으로 Ray 를 쏴 준다.
            // 충돌되는 객체가 있으면  true 를 반환한다.
            // RaycastHit 객체를 out 키워드를 통해서 파라미터로 던져 주면 충돌 된 객체의 정보를 hitObj에 담아 반환해준다.



            if (hitObj.transform.tag.Equals("PlaneSpring"))
            { //내가 쏜 레이가 충돌한 객체의 TAG 가 만약 PlaneSpring 이라면,
                Debug.Log("나. 봄 바닥에 광선 쏨."); // 콘솔창에 로그를 이렇게 찍겠다~

                //이제 여기서 봄 노래 키기 !
                audioSourceSpring = GetComponent<AudioSource>();
                playSound(audioClipSpring, audioSourceSpring);

            }

            if (hitObj.transform.tag.Equals("PlaneSummer")) //내가 쏜 레이가 충돌한 객체의 TAG 가 만약 PlaneSummer 이라면,
            {
                Debug.Log("나. 여름 바닥에 광선 쏨."); // 콘솔창에 로그를 이렇게 찍겠다~

                //이제 여기서 여름 노래 키기 !
                //코드 추가
                audioSourceSummer = GetComponent<AudioSource>();
                playSound(audioClipSummer, audioSourceSummer);

            }

            if (hitObj.transform.tag.Equals("PlaneAutumn")) //내가 쏜 레이가 충돌한 객체의 TAG 가 만약 PlaneAutumn 이라면,
            {
                Debug.Log("나. 가을 바닥에 광선 쏨."); // 콘솔창에 로그를 이렇게 찍겠다~

                //이제 여기서 가을 노래 키기 !
                //코드 추가
                audioSourceAutumn = GetComponent<AudioSource>();
                playSound(audioClipAutumn, audioSourceAutumn);

            }

            if (hitObj.transform.tag.Equals("PlaneWinter")) //내가 쏜 레이가 충돌한 객체의 TAG 가 만약 PlaneWinter 이라면,
            {
                Debug.Log("나. 겨울 바닥에 광선 쏨."); // 콘솔창에 로그를 이렇게 찍겠다~

                //이제 여기서 겨울 노래 키기 !
                //코드 추가
                audioSourceWinter = GetComponent<AudioSource>();
                playSound(audioClipWinter, audioSourceWinter);
            }
        }
    }

    public static void playSound(AudioClip clip, AudioSource audioPlayer)
    {
        audioPlayer.Stop();
        audioPlayer.clip = clip;
        audioPlayer.loop = true;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }
}
