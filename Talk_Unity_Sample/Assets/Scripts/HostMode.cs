using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using YouMe;

public class HostMode : MonoBehaviour {

	public Dropdown roomDropdown;
	public Toggle hostAuthorityToggle;
	public Toggle commanderAuthorityToggle;
	public Toggle speakerToggle;
	public Toggle bgMusicToggle;
	public Toggle monitorToggle;
	public Toggle micToggle;
	public Toggle mixToggle;
	public Text tipsText;
	public Text bgmVolumeText;
	public Text labelDropdown;
	public Text speakerVolumeText;
	public Slider speakerSlider;
	public Slider bgMusicSlider;
	public InputField userIDInput;
	public InputField hostRoomIDInput;
	public InputField commanderRoomIDInput;

	private bool hostAuthority;
	private bool commanderAuthority;
	private string userID;
	private string hostRoomID;
	private string commanderRoomID;

	//初始化状态标记值
	private bool inited;
	//频道状态标记值
	private YouMe.ChannelState state;
	private YouMe.YouMeUserRole role;

	private string nextRoomID = null;
	private YouMe.YouMeUserRole nextRole = YouMe.YouMeUserRole.YOUME_USER_NONE;

	// Use this for initialization
	void Start () {
		hostAuthority = false;
		commanderAuthority = false;
		inited = false;
		state = YouMe.ChannelState.CHANNEL_STATE_LEAVED;
		NotInitedUI ();
		SetID ();



		//注册回调
		YouMe.YouMeVoiceAPI.GetInstance ().SetCallback (gameObject.name);
		//初始化，填入从游密申请到的AppKey和AppSecret（可在游密官网https://console.youme.im/user/register注册账号或者直接联系我方商务获取）
		//YouMe.YouMeVoiceAPI.GetInstance ().Init (您获取的AppKey, 您获取的AppSecret);
		var errorCode = YouMe.YouMeVoiceAPI.GetInstance ().Init ("YOUME670584CA1F7BEF370EC7780417B89BFCC4ECBF78", "yYG7XY8BOVzPQed9T1/jlnWMhxKFmKZvWSFLxhBNe0nR4lbm5OUk3pTAevmxcBn1mXV9Z+gZ3B0Mv/MxZ4QIeDS4sDRRPzC+5OyjuUcSZdP8dLlnRV7bUUm29E2CrOUaALm9xQgK54biquqPuA0ZTszxHuEKI4nkyMtV9sNCNDMBAAE=",YOUME_RTC_SERVER_REGION.RTC_HK_SERVER,"");
		//如果直接返回值不是成功，则不会进入回调，可按初始化失败时的方法处理
		if (errorCode != YouMe.YouMeErrorCode.YOUME_SUCCESS) {
			tipsText.text = "初始化失败，错误码：" + (int)errorCode;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//回调函数
	void OnEvent (string strParam)
	{ 
		string[] strSections = strParam.Split (new char[] { ',' },4);
		if (strSections == null){

			return;
		}
		//解析后得到两个字段，第一个为事件类型，第二个为错误码类型
		YouMe.YouMeEvent eventType = (YouMeEvent)int.Parse (strSections [0]);
		YouMe.YouMeErrorCode errorCode = (YouMeErrorCode)int.Parse (strSections [1]);

		switch (eventType) {
		case YouMe.YouMeEvent.YOUME_EVENT_INIT_OK:
			tipsText.text = "初始化成功";
			inited = true;
			InitedUI ();
			break;
		case YouMe.YouMeEvent.YOUME_EVENT_INIT_FAILED:
			tipsText.text = "初始化失败，错误码：" + errorCode;
			break;
		case YouMe.YouMeEvent.YOUME_EVENT_JOIN_OK:
			tipsText.text = "加入频道成功";
			nextRole = YouMe.YouMeUserRole.YOUME_USER_NONE;
			nextRoomID = null;
			state = YouMe.ChannelState.CHANNEL_STATE_JOINED;
			JoinedUI ();
			break;
		case YouMe.YouMeEvent.YOUME_EVENT_LEAVED_ALL:
			if (YouMe.YouMeUserRole.YOUME_USER_NONE != nextRole) {
				//需要加入新频道
				errorCode = YouMe.YouMeVoiceAPI.GetInstance ().JoinChannelSingleMode (userID, nextRoomID, nextRole);
				if (YouMe.YouMeErrorCode.YOUME_SUCCESS == errorCode) {
					state = YouMe.ChannelState.CHANNEL_STATE_JOINING;
					JoiningUI ();
				}
			} else {
				tipsText.text = "离开频道成功";
				labelDropdown.text = "静音";
				roomDropdown.interactable = true;
				LeavedUI ();
				state = YouMe.ChannelState.CHANNEL_STATE_LEAVED;
			}
			break;
		default:
			tipsText.text = tipsText.text + "\n事件类型" + eventType + ",错误码" + errorCode;
			break;

		}

	}



	public void onToggleHostAuthority(){
		if (hostAuthorityToggle.isOn) {
			hostAuthority = true;
		} else {
			hostAuthority = false;
		}

	}
	public void onToggleCommanderAuthority(){
		if (commanderAuthorityToggle.isOn) {
			commanderAuthority = true;
		} else {
			commanderAuthority = false;
		}
	}


	public void onDropdown(){
		roomDropdown.interactable = false;
		LeavedUI ();
		switch (roomDropdown.value) {
		case 0:
			tipsText.text = "静音模式";
			//调用离开频道
			var errorCode = YouMe.YouMeVoiceAPI.GetInstance ().LeaveChannelAll ();
			if (YouMe.YouMeErrorCode.YOUME_SUCCESS == errorCode) {
				state = YouMe.ChannelState.CHANNEL_STATE_LEAVING_ALL;
				LeavingUI ();
			}
			break;
		case 1:
			tipsText.text = "主播模式";

			if (YouMe.ChannelState.CHANNEL_STATE_LEAVED == state) {
				//当前状态为不在房间，则可直接加入新房间
				if (hostAuthority) {
					//为主播身份
					GetID();
					errorCode = YouMe.YouMeVoiceAPI.GetInstance ().JoinChannelSingleMode(userID,hostRoomID,YouMe.YouMeUserRole.YOUME_USER_HOST);
					if (YouMe.YouMeErrorCode.YOUME_SUCCESS == errorCode) {
						state = YouMe.ChannelState.CHANNEL_STATE_JOINING;
						JoiningUI ();
					}

					//SpeakerUI ();
				} else {
					//为听众身份
					GetID();
					errorCode = YouMe.YouMeVoiceAPI.GetInstance ().JoinChannelSingleMode(userID,hostRoomID,YouMe.YouMeUserRole.YOUME_USER_LISTENER);
					if (YouMe.YouMeErrorCode.YOUME_SUCCESS == errorCode) {
						state = YouMe.ChannelState.CHANNEL_STATE_JOINING;
						JoiningUI ();
					}
					//ListenerUI ();
				}
			}

			if (YouMe.ChannelState.CHANNEL_STATE_JOINED == state) {
				//当前状态为已经在房间，需要先退出并等回调成功，再重新加入
				nextRoomID = hostRoomID;
				if (hostAuthority) {
					//准备以主播身份加入主播频道
					nextRole = YouMe.YouMeUserRole.YOUME_USER_HOST;
				} else {
					//准备以听众身份加入主播频道
					nextRole = YouMe.YouMeUserRole.YOUME_USER_LISTENER;
				}
				//先调用离开频道
				 errorCode = YouMe.YouMeVoiceAPI.GetInstance ().LeaveChannelAll ();
				if (YouMe.YouMeErrorCode.YOUME_SUCCESS == errorCode) {
					state = YouMe.ChannelState.CHANNEL_STATE_LEAVING_ALL;
					LeavingUI ();
				}
			}
			break;
		case 2:
			tipsText.text = "指挥模式";
	
			if (YouMe.ChannelState.CHANNEL_STATE_LEAVED == state) {
				//当前状态为不在房间，则可直接加入新房间
				if (commanderAuthority) {
					//为指挥身份
					GetID();
					errorCode = YouMe.YouMeVoiceAPI.GetInstance ().JoinChannelSingleMode(userID,commanderRoomID,YouMe.YouMeUserRole.YOUME_USER_COMMANDER);
					if (YouMe.YouMeErrorCode.YOUME_SUCCESS == errorCode) {
						state = YouMe.ChannelState.CHANNEL_STATE_JOINING;
						JoiningUI ();
					}
						
				} else {
					//为听众身份
					GetID();
					errorCode = YouMe.YouMeVoiceAPI.GetInstance ().JoinChannelSingleMode(userID,commanderRoomID,YouMe.YouMeUserRole.YOUME_USER_LISTENER);
					if (YouMe.YouMeErrorCode.YOUME_SUCCESS == errorCode) {
						state = YouMe.ChannelState.CHANNEL_STATE_JOINING;
						JoiningUI ();
					}
				}
			}

			if (YouMe.ChannelState.CHANNEL_STATE_JOINED == state) {
				//当前状态为已经在房间，需要先退出并等回调成功，再重新加入
				nextRoomID = commanderRoomID;
				if (hostAuthority) {
					//准备以指挥身份加入指挥频道
					nextRole = YouMe.YouMeUserRole.YOUME_USER_COMMANDER;
				} else {
					//准备以听众身份加入指挥频道
					nextRole = YouMe.YouMeUserRole.YOUME_USER_LISTENER;
				}
				//先调用离开频道
				errorCode = YouMe.YouMeVoiceAPI.GetInstance ().LeaveChannelAll ();
				if (YouMe.YouMeErrorCode.YOUME_SUCCESS == errorCode) {
					state = YouMe.ChannelState.CHANNEL_STATE_LEAVING_ALL;
					LeavingUI ();
				}
			}
			break;
		}
	}

	public void onMicToggle() {
		if (micToggle.isOn) {
			//打开麦克风
			YouMe.YouMeVoiceAPI.GetInstance().SetMicrophoneMute (false);

		} else {
			//关闭麦克风
			YouMe.YouMeVoiceAPI.GetInstance().SetMicrophoneMute (true);

		}

        bool result = !micToggle.isOn;
        if(result){
			tipsText.text = "麦克风状态：关";
		} else {
			tipsText.text = "麦克风状态：开";
		}
	}

	public void onSpeakerToggle() {
		if (speakerToggle.isOn) {
			//打开扬声器
			YouMe.YouMeVoiceAPI.GetInstance().SetSpeakerMute (false);
		} else {
			//关闭扬声器
			YouMe.YouMeVoiceAPI.GetInstance().SetSpeakerMute (true);
		}
		bool result = !speakerToggle.isOn;
		if(result){
			tipsText.text = "扬声器状态：关";
		} else {
			tipsText.text = "扬声器状态：开";
		}
	}

	public void onMonitorToggle() {
		if (monitorToggle.isOn) {
			YouMe.YouMeVoiceAPI.GetInstance().SetHeadsetMonitorOn (true);

		} else {
			YouMe.YouMeVoiceAPI.GetInstance().SetHeadsetMonitorOn (false);

		}
	}

	public void onMixToggle() {
		if (mixToggle.isOn) {
			YouMe.YouMeVoiceAPI.GetInstance ().SetReverbEnabled (true);
		} else {
			YouMe.YouMeVoiceAPI.GetInstance ().SetReverbEnabled (false);

		}
	}

	//播放背景音乐
	public void onBgmusicToggle() {
		if (bgMusicToggle.isOn) {
			YouMe.YouMeVoiceAPI.GetInstance ().PlayBackgroundMusic ("/sdcard/backmusic/test.mp3", true);
		} else {
			YouMe.YouMeVoiceAPI.GetInstance ().StopBackgroundMusic ();
		}
	}

	public void OnSpeakerVolumeChanged()
	{
		speakerVolumeText.text =  speakerSlider.value.ToString();
		YouMe.YouMeVoiceAPI.GetInstance().SetVolume ((uint)speakerSlider.value);
		var currentVolume = YouMe.YouMeVoiceAPI.GetInstance().GetVolume();
		tipsText.text = "当前音量：" + currentVolume;
	}

	public void OnBgmVolumeChanged()
	{
		bgmVolumeText.text =  bgMusicSlider.value.ToString();
		YouMe.YouMeVoiceAPI.GetInstance().SetBackgroundMusicVolume ((int)bgMusicSlider.value);

	}

	public void OnClickButtonReturn(){
		//反初始化退出到登陆界面
		YouMe.YouMeVoiceAPI.GetInstance().UnInit();
		SceneManager.LoadScene ("talkLogin");
	}


	private void SpeakerUI(){
		speakerToggle.gameObject.SetActive (true);
		speakerSlider.gameObject.SetActive (true);
		speakerVolumeText.gameObject.SetActive (true);
		bgMusicToggle.gameObject.SetActive (true);
		bgMusicSlider.gameObject.SetActive (true);
		bgmVolumeText.gameObject.SetActive (true);
		monitorToggle.gameObject.SetActive (true);
		micToggle.gameObject.SetActive (true);
		mixToggle.gameObject.SetActive (true);
	}

	private void ListenerUI(){
		speakerToggle.gameObject.SetActive (true);
		speakerSlider.gameObject.SetActive (true);
		speakerVolumeText.gameObject.SetActive (true);
	}

	private void LeavedUI(){
		//labelDropdown.text = "静音";
		speakerToggle.gameObject.SetActive (false);
		speakerSlider.gameObject.SetActive (false);
		speakerVolumeText.gameObject.SetActive (false);
		bgMusicToggle.gameObject.SetActive (false);
		bgMusicSlider.gameObject.SetActive (false);
		bgmVolumeText.gameObject.SetActive (false);
		monitorToggle.gameObject.SetActive (false);
		micToggle.gameObject.SetActive (false);
		mixToggle.gameObject.SetActive (false);
	}

	private void NotInitedUI(){
		roomDropdown.interactable = false;
		LeavedUI ();
		tipsText.text = "还未初始化";
	}

	private void InitedUI(){
		roomDropdown.interactable = true;
		tipsText.text = "初始化成功";

	}

	private void SetID(){
		hostRoomID = "hRoom1";
		commanderRoomID = "cRoom2";
		int random;
		random = Random.Range (1, 10000000);
		userID = random.ToString ();
		userIDInput.text = userID;
		hostRoomIDInput.text = hostRoomID;
		commanderRoomIDInput.text = commanderRoomID;
	}

	private void GetID(){
		userID = userIDInput.text ;
		hostRoomID = hostRoomIDInput.text ;
		commanderRoomID = commanderRoomIDInput.text ;
	}

	private void JoiningUI(){
		labelDropdown.text = "进入中";
	}

	private void LeavingUI(){
		labelDropdown.text = "退出中";
	}

	private void JoinedUI(){
		if (roomDropdown.value == 1) {
			labelDropdown.text = "主播频道";
			if (hostAuthority) {
				SpeakerUI ();
			} else {
				ListenerUI ();
			}
		}else if(roomDropdown.value == 2) {
			labelDropdown.text = "指挥频道";
			if (commanderAuthority) {
				SpeakerUI ();
			} else {
				ListenerUI ();
			}
		}
		roomDropdown.interactable = true;
	}

    private void OnApplicationQuit()
    {
        YouMe.YouMeVoiceAPI.GetInstance().UnInit();
    }
}
