using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using YouMe;
using System.Collections.Generic;


public class TeamMode : MonoBehaviour
{

    //初始化状态标记值
    private volatile bool inited;
    //频道状态标记值
    private volatile YouMe.ChannelState state;
    private volatile string userID;
    private volatile string roomID;

    public Text tipsText;
    public Text speakerVolumeText;
    public Text buttonChannelText;
    public Toggle micToggle;
    public Toggle speakerToggle;

    public Button joinButton;
    public Button leaveButton;
    public Button returnButton;
    public Slider volumeSlider;
    public InputField userInput;
    public InputField roomInput;

    // Use this for initialization
    void Start()
    {
        //初设两个状态值
        inited = false;
        state = YouMe.ChannelState.CHANNEL_STATE_LEAVED;
        userID = null;
        roomID = null;

        //自行封装的未初始化成功时的ui展现
        NotInitedUI();
        SetID();


        //注册回调
        YouMe.YouMeVoiceAPI.GetInstance().SetCallback(gameObject.name);
        //初始化，填入从游密申请到的AppKey和AppSecret（可在游密官网https://console.youme.im/user/register注册账号或者直接联系我方商务获取）
        //YouMe.YouMeVoiceAPI.GetInstance ().Init (您获取的AppKey, 您获取的AppSecret);
        var errorCode = YouMe.YouMeVoiceAPI.GetInstance().Init("YOUME670584CA1F7BEF370EC7780417B89BFCC4ECBF78", "yYG7XY8BOVzPQed9T1/jlnWMhxKFmKZvWSFLxhBNe0nR4lbm5OUk3pTAevmxcBn1mXV9Z+gZ3B0Mv/MxZ4QIeDS4sDRRPzC+5OyjuUcSZdP8dLlnRV7bUUm29E2CrOUaALm9xQgK54biquqPuA0ZTszxHuEKI4nkyMtV9sNCNDMBAAE=", YOUME_RTC_SERVER_REGION.RTC_HK_SERVER, "");
        //如果直接返回值不是成功，则不会进入回调，可按初始化失败时的方法处理
        if (errorCode != YouMe.YouMeErrorCode.YOUME_SUCCESS)
        {
            tipsText.text = "初始化失败，错误码：" + (int)errorCode;
        }


    }

    // 回到主线程处理一些UI相关的操作
    void Update()
    {

    }


    public void OnClickButtonReturn()
    {
        //反初始化退出到登陆界面
        YouMe.YouMeVoiceAPI.GetInstance().UnInit();
        SceneManager.LoadScene("talkLogin");
    }

    public void OnClickButtonJoin()
    {
        //只有状态为leaved时才能直接加入频道
        if (YouMe.ChannelState.CHANNEL_STATE_LEAVED == state)
        {

            //获取userID和roomID
            GetID();

            //调用加入频道接口
            YouMe.YouMeVoiceAPI.GetInstance().SetVolume(70); //设置语音通话音量为 70%，可以减少近距离的啸叫
            var errorCode = YouMe.YouMeVoiceAPI.GetInstance().JoinChannelSingleMode(userID, roomID, YouMe.YouMeUserRole.YOUME_USER_TALKER_FREE);

            if (YouMe.YouMeErrorCode.YOUME_SUCCESS == errorCode)
            {
                //只有直接返回值为成功才会进回调
                state = YouMe.ChannelState.CHANNEL_STATE_JOINING;
                tipsText.text = "进入中";
            }
        }
        else
        {
            //其它状态值都直接返回
            return;
        }
    }

    public void OnClickButtonLeave()
    {
        //joining和joined的状态可以直接调用离开
        if (YouMe.ChannelState.CHANNEL_STATE_JOINING == state || YouMe.ChannelState.CHANNEL_STATE_JOINED == state)
        {
            //调用加入频道接口
            var errorCode = YouMe.YouMeVoiceAPI.GetInstance().LeaveChannelAll();

            if (YouMe.YouMeErrorCode.YOUME_SUCCESS == errorCode)
            {
                //只有直接返回值为成功才会进回调
                state = YouMe.ChannelState.CHANNEL_STATE_LEAVING_ALL;
                tipsText.text = "离开中";
            }
        }
        else
        {
            //其它状态值都直接返回
            return;
        }
    }



    //回调函数
    void OnEvent(string strParam)
    {
        string[] strSections = strParam.Split(new char[] { ',' }, 4);
        if (strSections == null)
        {

            return;
        }
        //解析后得到两个字段，第一个为事件类型，第二个为错误码类型
        YouMe.YouMeEvent eventType = (YouMeEvent)int.Parse(strSections[0]);
        YouMe.YouMeErrorCode errorCode = (YouMeErrorCode)int.Parse(strSections[1]);
        string channelID = strSections[2];
        string param = strSections[3];

        switch (eventType)
        {
            case YouMe.YouMeEvent.YOUME_EVENT_INIT_OK:
                tipsText.text = "初始化成功";
                inited = true;
                InitedUI();
                break;
            case YouMe.YouMeEvent.YOUME_EVENT_INIT_FAILED:
                tipsText.text = "初始化失败，错误码：" + errorCode;

                break;
            case YouMe.YouMeEvent.YOUME_EVENT_JOIN_OK:
                //如果已调用了离开接口，则无须再等此类回调
                if (YouMe.ChannelState.CHANNEL_STATE_LEAVING_ALL == state)
                {
                    return;
                }
                tipsText.text = tipsText.text + "\n加入频道成功";
                JoinedUI();
                state = YouMe.ChannelState.CHANNEL_STATE_JOINED;

                break;
            case YouMe.YouMeEvent.YOUME_EVENT_LEAVED_ALL:
                tipsText.text = tipsText.text + "\n离开频道成功";
                LeavedUI();
                state = YouMe.ChannelState.CHANNEL_STATE_LEAVED;

                break;

            case YouMe.YouMeEvent.YOUME_EVENT_JOIN_FAILED:
                //进入语音频道失败
                tipsText.text = tipsText.text + "\n加入频道失败，错误码：" + errorCode;
                LeavedUI();
                state = YouMe.ChannelState.CHANNEL_STATE_LEAVED;

                break;

			case YouMe.YouMeEvent.YOUME_EVENT_REC_PERMISSION_STATUS:
				if (errorCode == YouMe.YouMeErrorCode.YOUME_ERROR_REC_NO_PERMISSION) {
					tipsText.text = tipsText.text + "\n录音启动失败（此时不管麦克风mute状态如何，都没有声音输出";
				}

                break;
            case YouMe.YouMeEvent.YOUME_EVENT_RECONNECTING:
                tipsText.text = tipsText.text + "\n断网了，正在重连";

                break;
            case YouMe.YouMeEvent.YOUME_EVENT_RECONNECTED:
                tipsText.text = tipsText.text + "\n断网重连成功";

                break;
            case YouMe.YouMeEvent.YOUME_EVENT_OTHERS_MIC_OFF:
                //其他用户的麦克风关闭：
                //Send Event callback, event(18):OTHERS_SPEAKER_ON, errCode:0, room:, param:3026935
                tipsText.text = tipsText.text + "\n用户" + param + "的麦克风关闭";

                break;
            case YouMe.YouMeEvent.YOUME_EVENT_OTHERS_MIC_ON:
                //其他用户的麦克风打开：
                tipsText.text = tipsText.text + "\n用户" + param + "的麦克风打开";

                break;
            case YouMe.YouMeEvent.YOUME_EVENT_OTHERS_SPEAKER_ON:
                //其他用户的扬声器打开：
                tipsText.text = tipsText.text + "\n用户" + param + "的扬声器打开";

                break;
            case YouMe.YouMeEvent.YOUME_EVENT_OTHERS_SPEAKER_OFF:
                //其他用户的扬声器关闭
                tipsText.text = tipsText.text + "\n用户" + param + "的扬声器关闭";

                break;
            default:
                tipsText.text = tipsText.text + "\n事件类型" + eventType + ",错误码" + errorCode;
                break;
        }

    }

    void OnMemberChange(string strParam)
    {
        // strParam:
        // {"channelid":"123","memchange":[{"userid":"111",isJoin:"true"}]}
        // 参考 https://youme.im/doc/TalkUnityAPIInterface-v2.5.php#实现回调函数
    }


    public void onMicToggle()
    {
        if (micToggle.isOn)
        {
            //打开麦克风
            YouMe.YouMeVoiceAPI.GetInstance().SetMicrophoneMute(false);

        }
        else
        {
            //关闭麦克风
            YouMe.YouMeVoiceAPI.GetInstance().SetMicrophoneMute(true);

        }

        bool result = !micToggle.isOn;
        if (result)
        {
            tipsText.text = "麦克风状态：关";
        }
        else
        {
            tipsText.text = "麦克风状态：开";
        }
    }

    public void onSpeakerToggle()
    {
        if (speakerToggle.isOn)
        {
            //打开扬声器
            YouMe.YouMeVoiceAPI.GetInstance().SetSpeakerMute(false);
        }
        else
        {
            //关闭扬声器
            YouMe.YouMeVoiceAPI.GetInstance().SetSpeakerMute(true);
        }
        bool result = !speakerToggle.isOn;
        if (result)
        {
            tipsText.text = "扬声器状态：关";
        }
        else
        {
            tipsText.text = "扬声器状态：开";
        }
    }

    public void OnSpeakerVolumeChanged()
    {
        speakerVolumeText.text = volumeSlider.value.ToString();
        YouMe.YouMeVoiceAPI.GetInstance().SetVolume((uint)volumeSlider.value);
        var currentVolume = YouMe.YouMeVoiceAPI.GetInstance().GetVolume();
        tipsText.text = "当前音量：" + currentVolume;
    }


    //初始化成功后的ui变化，以保障初始化成功才能进行加入频道的操作
    private void InitedUI()
    {
        joinButton.interactable = true;
        leaveButton.interactable = true;
    }

    private void NotInitedUI()
    {
        LeavedUI();
        joinButton.interactable = false;
        leaveButton.interactable = false;
        tipsText.text = "还未初始化";
    }

    private void JoinedUI()
    {
        joinButton.interactable = false;
        micToggle.gameObject.SetActive(true);
        speakerToggle.gameObject.SetActive(true);
        volumeSlider.gameObject.SetActive(true);
        speakerVolumeText.gameObject.SetActive(true);

        micToggle.isOn = false;
        speakerToggle.isOn = false;
        volumeSlider.value = 70;
        speakerVolumeText.text = "70";
    }

    private void LeavedUI()
    {
        joinButton.interactable = true;
        micToggle.gameObject.SetActive(false);
        speakerToggle.gameObject.SetActive(false);
        volumeSlider.gameObject.SetActive(false);
        speakerVolumeText.gameObject.SetActive(false);
    }

    //每次重进频道，将所有相关状态重设
    private void ReSet()
    {
        YouMe.YouMeVoiceAPI.GetInstance().SetMicrophoneMute(true);
        YouMe.YouMeVoiceAPI.GetInstance().SetSpeakerMute(true);
        YouMe.YouMeVoiceAPI.GetInstance().SetVolume(100);
    }

    private void SetID()
    {
        roomID = "tRoom1234";
        int random;
        random = Random.Range(1, 10000000);
        userID = random.ToString();
        roomInput.text = roomID;
        userInput.text = userID;
    }

    private void GetID()
    {
        userID = userInput.text;
        roomID = roomInput.text;
    }

    private void OnApplicationQuit()
    {
        YouMe.YouMeVoiceAPI.GetInstance().UnInit();
    }

}
