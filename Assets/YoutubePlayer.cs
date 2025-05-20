// using System.Collections;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.Video;

// namespace YoutubePlayer
// {
// public class YoutubePlayer : MonoBehaviour
// {
//     // 비디오 객체에 붙인 유튜브 플레이어
//     public YoutubePlayer youtubePlayer;
//     // 비디오 객체의 비디오 플레이어
//     public VideoPlayer videoPlayer;
//     // 유튜브 동영상이 플레이 가능한지 확인하기 위한 버튼
//     // 위치는 화면 밖으로 날려버려 보이지않게 하자.
//     public Button playBtn;
//     // 실제 비디오가 재생될 렌더 텍스처
//     public RenderTexture renderTexture;
//     // 비디오 재생전에 아무것도 보이지 않을 임시 렌더 텍스처
//     public RenderTexture nonRenderTexture;
//     // 렌더 텍스처를 관리하는 RawImage 객체
//     public RawImage rawImage;

//     void Awake()
//     {
//         rawImage.texture = nonRenderTexture;
//         playBtn.interactable = false;
//     }

//     public void SetYoutubeVideo(string url)
//     {
//         try
//         {
//             videoPlayer.prepareCompleted -= VideoReadyAndCompleted;
//         }
//         catch (System.Exception ex)
//         {
//             // TODO
//         }
//         try
//         {
//             videoPlayer.prepareCompleted += VideoReadyAndCompleted;
//         }
//         catch (System.Exception ex)
//         {
//             // TODO
//         }
//         playBtn.interactable = false;
//         youtubePlayer.
//         Prepare(youtubePlayer.youtubeUrl);
//     }

//     void VideoReadyAndCompleted(VideoPlayer source)
//     {
//         playBtn.interactable = source.isPrepared;
//     }

//     public async void Prepare(string url = null)
//     {


//         try
//         {
//             await youtubePlayer.PrepareVideoAsync();
//             StartCoroutine(Play());
//         }
//         catch (System.Exception e)
//         {
//             Debug.LogWarning(e.Message);
//         }
//     }

//     public IEnumerator Play()
//     {
//         while (true)
//         {
//             yield return null;
//             if (playBtn.interactable == true)
//             {
//                 rawImage.texture = renderTexture;
//                 videoPlayer.Play();
//                 break;
//             }
//         }
//     }

//     public void OnDestroy()
//     {
//         videoPlayer.Stop();
//         rawImage.texture = nonRenderTexture;
//         videoPlayer.prepareCompleted -= VideoReadyAndCompleted;
//     }
// }

// }
