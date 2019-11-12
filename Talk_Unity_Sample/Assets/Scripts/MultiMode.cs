using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using YouMe;
using UnityEngine.SceneManagement;


public class MultiMode : MonoBehaviour {
	
	public Text tipsText;
	public Text ATipsText;
	public Text BTipsText;
	public InputField ARoomIDInput;
	public InputField BRoomIDInput;
	public InputField userIDInput;
	public Toggle AMicToggle;
	public Toggle BMicToggle;
	public Toggle micToggle;
	public Button joinAButton;
	public Button joinBButton;
	public Button leaveAButton;
	public Button leaveBButton;
	public Button leaveAllButton;
	public Button returnButton;

	private string ARoomID = null;
	private string BRoomID = null ;
	private string userID = null;


	//初始化状态标记值
	private bool inited;

	//频道状态标记值
	private YouMe.ChannelState stateA;
	private YouMe.ChannelState stateB;


	// Use this for initialization
	void Start () {
		inited = false;
		stateA = YouMe.ChannelState.CHANNEL_STATE_LEAVED;
		stateB = YouMe.ChannelState.CHANNEL_STATE_LEAVED;

		NotInitedUI ();
		SetID ();

		//注册回调
		YouMe.YouMeVoiceAPI.GetInstance ().SetCallback (gameObject.name);
        
        //初始化，填入从游密申请到的AppKey和AppSecret（可在游密官网https://console.youme.im/user/register注册账号或者直接联系我方商务获取）
        //YouMe.YouMeVoiceAPI.GetInstance ().Init (您获取的AppKey, 您获取的AppSecret);
        var errorCode = YouMe.YouMeVoiceAPI.GetInstance ().Init ("YOUME670584CA1F7BEF370EC7780417B89BFCC4ECBF78", "yYG7XY8BOVzPQed9T1/jlnWMhxKFmKZvWSFLxhBNe0nR4lbm5OUk3pTAevmxcBn1mXV9Z+gZ3B0Mv/MxZ4QIeDS4sDRRPzC+5OyjuUcSZdP8dLlnRV7bUUm29E2CrOUaALm9xQgK54biquqPuA0ZTszxHuEKI4nkyMtV9sNCNDMBAAE=",YOUME_RTC_SERVER_REGION.RTC_EXT_SERVER,"CN");
		//如果直接返回值不是成功，则不会进入回调，可按初始化失败时的方法处理
		if (errorCode != YouMe.YouMeErrorCode.YOUME_SUCCESS) {
			tipsText.text = "初始化失败，错误码：" + (int)errorCode;
		}
        // YouMe.YouMeVoiceAPI.GetInstance().SetServerRegion(new string[]{"US","HK","HK","SG","SG"});
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
		string channelID =  strSections [2];
		string param =  strSections [3];

		//打印输出
		//Debug.LogError ("eventType:" + eventType.ToString ());
		//Debug.LogError ("iErrorCode:" + iErrorCode.ToString ());

		switch (eventType) {
		case YouMe.YouMeEvent.YOUME_EVENT_INIT_OK:
			//			callbackList.Add (() => {
			//				
			//			});
			tipsText.text = "初始化成功";
			inited = true;
			InitedUI ();
			break;
		case YouMe.YouMeEvent.YOUME_EVENT_INIT_FAILED:
			tipsText.text = "初始化失败,错误码：" + errorCode;
			break;

		case YouMe.YouMeEvent.YOUME_EVENT_JOIN_OK:
			YouMe.YouMeVoiceAPI.GetInstance ().SetMicrophoneMute (false);
			Debug.LogError(YouMe.YouMeVoiceAPI.GetInstance().SetVadCallbackEnabled(true));
			if (YouMe.ChannelState.CHANNEL_STATE_LEAVING_ALL == stateA) {
				//说明已经调用了离开所有频道的操作，此时只需要等离开所有频道的回调就行
				return;
			}

			tipsText.text = "";
			micToggle.gameObject.SetActive (true);
                YouMe.YouMeVoiceAPI.GetInstance().SetSpeakerMute(false);
			if (string.Equals (channelID, ARoomID)) {
				stateA = YouMe.ChannelState.CHANNEL_STATE_JOINED;
				ATipsText.text = "已进入";

				//加入A频道成功后，则离开A频道按钮变为可交互。B频道根据状态恢复UI
				leaveAButton.interactable = true;
				AMicToggle.gameObject.SetActive (true);
				if (YouMe.ChannelState.CHANNEL_STATE_JOINED == stateB) {
					BMicToggle.gameObject.SetActive (true);
					leaveBButton.interactable = true;
				} else {
					joinBButton.interactable = true;
				}
			} else if (string.Equals (channelID, BRoomID)) {
				BTipsText.text = "已进入";

				stateB = YouMe.ChannelState.CHANNEL_STATE_JOINED;
				//加入B频道成功后，则离开B频道按钮变为可交互。A频道根据状态恢复UI
				leaveBButton.interactable = true;
				BMicToggle.gameObject.SetActive (true);
				if (YouMe.ChannelState.CHANNEL_STATE_JOINED == stateA) {
					AMicToggle.gameObject.SetActive (true);
					leaveAButton.interactable = true;
				} else {
					joinAButton.interactable = true;
				}
			}
			break;
		case YouMe.YouMeEvent.YOUME_EVENT_LEAVED_ONE:
			
			if (YouMe.ChannelState.CHANNEL_STATE_LEAVING_ALL == stateA) {
				//说明已经调用了离开所有频道的操作，此时只需要等离开所有频道的回调就行
				return;
			}

			if (string.Equals (channelID, ARoomID)) {
				stateA = YouMe.ChannelState.CHANNEL_STATE_LEAVED;
				ATipsText.text = "已离开";

				//离开A频道成功后，则加入A频道按钮变为可交互。B频道根据状态恢复UI
				joinAButton.interactable = true;
				if (YouMe.ChannelState.CHANNEL_STATE_JOINED == stateB) {
					BMicToggle.gameObject.SetActive (true);
					micToggle.gameObject.SetActive (true);

					leaveBButton.interactable = true;
				} else {
					joinBButton.interactable = true;
				}
			} else if (string.Equals (channelID, BRoomID)) {
				BTipsText.text = "已离开";

				stateB = YouMe.ChannelState.CHANNEL_STATE_LEAVED;
				//加入B频道成功后，则加入B频道按钮变为可交互。A频道根据状态恢复UI
				joinBButton.interactable = true;
				if (YouMe.ChannelState.CHANNEL_STATE_JOINED == stateA) {
					AMicToggle.gameObject.SetActive (true);
					leaveAButton.interactable = true;
					micToggle.gameObject.SetActive (true);
				} else {
					joinAButton.interactable = true;
				}
			}
			break;
		case YouMe.YouMeEvent.YOUME_EVENT_LEAVED_ALL:
			tipsText.text = "已退出所有频道";
			stateA = YouMe.ChannelState.CHANNEL_STATE_LEAVED;
			ATipsText.text = "已离开";
			stateB = YouMe.ChannelState.CHANNEL_STATE_LEAVED;
			BTipsText.text = "已离开";
			joinAButton.interactable = true;
			joinBButton.interactable = true;
			leaveAllButton.interactable = true;
			break;

		case YouMe.YouMeEvent.YOUME_EVENT_SPEAK_SUCCESS:
			AMicToggle.interactable = true;
			BMicToggle.interactable = true;
			micToggle.interactable = true;
			
			if (string.Equals (channelID, ARoomID)) {
				tipsText.text = "可以对A房间说话";
			} else if (string.Equals (channelID, BRoomID)) {
				tipsText.text = "可以对B房间说话";
			}
			break;
		case YouMe.YouMeEvent.YOUME_EVENT_SPEAK_FAILED:
			AMicToggle.interactable = true;
			BMicToggle.interactable = true;
			micToggle.interactable = true;
			if (string.Equals (channelID, ARoomID)) {
				tipsText.text = "对A房间说话的操作失败";
				AMicToggle.isOn = false;
				YouMe.YouMeVoiceAPI.GetInstance ().SetMicrophoneMute (true);
				micToggle.isOn = true;

			} else if (string.Equals (channelID, BRoomID)) {
				tipsText.text = "对B房间说话的操作失败";
				BMicToggle.isOn = false;
				YouMe.YouMeVoiceAPI.GetInstance ().SetMicrophoneMute (true);
				micToggle.isOn = true;

			}
			break;
		case YouMe.YouMeEvent.YOUME_EVENT_OTHERS_VOICE_ON:
        	Debug.LogError("YOUME_EVENT_OTHERS_VOICE_ON:"+param);
        	break;
		case YouMe.YouMeEvent.YOUME_EVENT_OTHERS_VOICE_OFF:
                Debug.LogError("YOUME_EVENT_OTHERS_VOICE_OFF:"+param);
                break;
        default:
			tipsText.text = tipsText.text + "\n事件类型" + eventType + ",错误码" + errorCode;
			break;

		}

	}



	public void onButtonJoinA(){
		//正在进入A房间的时候，除了退出所有房间和反初始化，其他都不允许操作，需要等相关回调才能操作
		//因此将不允许操作的按钮状态暂时设置为不可交互
		if(YouMe.ChannelState.CHANNEL_STATE_LEAVED==stateA){
			ATipsText.text = "正在离开";

			joinAButton.interactable = false;
			leaveAButton.interactable = false;
			joinBButton.interactable = false;
			leaveBButton.interactable = false;
			AMicToggle.gameObject.SetActive (false);
			BMicToggle.gameObject.SetActive (false);
			micToggle.gameObject.SetActive (false);

			ATipsText.text = "正在进入";
			GetID ();
			var errorcode = YouMe.YouMeVoiceAPI.GetInstance ().JoinChannelMultiMode (userID, ARoomID);
			//如果直接返回值不是成功，则不会进入回调
			if (YouMe.YouMeErrorCode.YOUME_SUCCESS == errorcode) {
				stateA = YouMe.ChannelState.CHANNEL_STATE_JOINING;
				}
		}
		
	}

	public void onButtonJoinB(){
		//正在进入房间的时候，除了退出所有房间和反初始化，其他都不能操作，需要等相关回调才能操作
		//因此将不允许操作的按钮状态暂时设置为不可交互
		if(YouMe.ChannelState.CHANNEL_STATE_LEAVED==stateB){
			BTipsText.text = "正在离开";

			joinAButton.interactable = false;
			leaveAButton.interactable = false;
			joinBButton.interactable = false;
			leaveBButton.interactable = false;
			AMicToggle.gameObject.SetActive (false);
			BMicToggle.gameObject.SetActive (false);
			micToggle.gameObject.SetActive (false);

			BTipsText.text = "正在进入";

			GetID ();
			var errorcode = YouMe.YouMeVoiceAPI.GetInstance ().JoinChannelMultiMode (userID, BRoomID); 
			//如果直接返回值不是成功，则不会进入回调
			if (YouMe.YouMeErrorCode.YOUME_SUCCESS == errorcode) {
				stateB = YouMe.ChannelState.CHANNEL_STATE_JOINING;
			}
		}
	}

	public void onButtonLeaveA(){
		//正在离开房间的时候，除了退出所有房间和反初始化，其他都不能操作，需要等相关回调才能操作
		//因此将不允许操作的按钮状态暂时设置为不可交互
		if(YouMe.ChannelState.CHANNEL_STATE_JOINED==stateA){
			joinAButton.interactable = false;
			leaveAButton.interactable = false;
			joinBButton.interactable = false;
			leaveBButton.interactable = false;
			AMicToggle.gameObject.SetActive (false);
			BMicToggle.gameObject.SetActive (false);
			micToggle.gameObject.SetActive (false);


			var errorcode = YouMe.YouMeVoiceAPI.GetInstance ().LeaveChannelMultiMode (ARoomID);
			//如果直接返回值不是成功，则不会进入回调
			if (YouMe.YouMeErrorCode.YOUME_SUCCESS == errorcode) {
				stateA = YouMe.ChannelState.CHANNEL_STATE_LEAVING_ONE;
			}
		}
	}

	public void onButtonLeaveB(){

		//正在离开房间的时候，除了退出所有房间和反初始化，其他都不能操作，需要等相关回调才能操作
		//因此将不允许操作的按钮状态暂时设置为不可交互
		if(YouMe.ChannelState.CHANNEL_STATE_JOINED==stateB){
			joinAButton.interactable = false;
			leaveAButton.interactable = false;
			joinBButton.interactable = false;
			leaveBButton.interactable = false;
			AMicToggle.gameObject.SetActive (false);
			BMicToggle.gameObject.SetActive (false);
			micToggle.gameObject.SetActive (false);


			var errorcode = YouMe.YouMeVoiceAPI.GetInstance ().LeaveChannelMultiMode (BRoomID);
			//如果直接返回值不是成功，则不会进入回调
			if (YouMe.YouMeErrorCode.YOUME_SUCCESS == errorcode) {
				stateB = YouMe.ChannelState.CHANNEL_STATE_LEAVING_ONE;
			}
		}
		
	}

	public void onButtonLeaveAll(){

		if ((stateA == YouMe.ChannelState.CHANNEL_STATE_LEAVED) && (stateB == YouMe.ChannelState.CHANNEL_STATE_LEAVED)) {
			//都已不在房间，不须再离开房间
			return;
		}
		//正在离开所有房间的时候，除了反初始化，其他都不能操作，需要等相关回调才能操作
		//因此将不允许操作的按钮状态暂时设置为不可交互
		joinAButton.interactable = false;
		leaveAButton.interactable = false;
		joinBButton.interactable = false;
		leaveBButton.interactable = false;
		leaveAllButton.interactable = false;
		AMicToggle.gameObject.SetActive (false);
		BMicToggle.gameObject.SetActive (false);
		micToggle.gameObject.SetActive (false);


		var errorcode = YouMe.YouMeVoiceAPI.GetInstance ().LeaveChannelAll();
		//如果直接返回值不是成功，则不会进入回调
		if (YouMe.YouMeErrorCode.YOUME_SUCCESS == errorcode) {
			stateA = YouMe.ChannelState.CHANNEL_STATE_LEAVING_ALL;
			stateB = YouMe.ChannelState.CHANNEL_STATE_LEAVING_ALL;
			tipsText.text = "正在退出所有频道";

		}
	
	}
		

	public void onToggleMicA(){
		if (AMicToggle.isOn) {
			AMicToggle.interactable = false;
			BMicToggle.interactable = false;
			micToggle.interactable = false;

			YouMe.YouMeVoiceAPI.GetInstance ().SetMicrophoneMute (false);
			var errorcode = YouMe.YouMeVoiceAPI.GetInstance().SpeakToChannel("all");
			if (YouMe.YouMeErrorCode.YOUME_SUCCESS != errorcode) {
				ATipsText.text = "操作失败，错误码" + (int)errorcode;
			}
		}
		
	}

	public void onToggleMicB(){

		if (BMicToggle.isOn) {
			AMicToggle.interactable = false;
			BMicToggle.interactable = false;
			micToggle.interactable = false;

			//speakToChannelB
			//speakToChannelA,等到相关回调之前不允许再次speakToChannelA和speakToChannelB
			YouMe.YouMeVoiceAPI.GetInstance ().SetMicrophoneMute (false);
			var errorcode = YouMe.YouMeVoiceAPI.GetInstance().SpeakToChannel("all");
			if (YouMe.YouMeErrorCode.YOUME_SUCCESS != errorcode) {
				BTipsText.text = "操作失败，错误码" + (int)errorcode;
			}
		
		}

	}

	public void onToggleMic(){
		if (micToggle.isOn) {
			YouMe.YouMeVoiceAPI.GetInstance ().SetMicrophoneMute (true);
			tipsText.text = "麦克风状态：关";
		}else{
			YouMe.YouMeVoiceAPI.GetInstance ().SetMicrophoneMute (false);
		}
	}
	public void onButtonReturn(){
		YouMe.YouMeVoiceAPI.GetInstance().UnInit();
		SceneManager.LoadScene ("talkLogin");
	}

	private void SetID(){
		ARoomID = "Live_abcde";
		BRoomID = "roomB";
		int random;
		random = Random.Range (1, 10000000);
		userID = random.ToString ();
		userIDInput.text = userID;
		ARoomIDInput.text = ARoomID;
		BRoomIDInput.text = BRoomID;
	}

	private void GetID(){
		userID = userIDInput.text ;
		ARoomID = ARoomIDInput.text ;
		BRoomID = BRoomIDInput.text ;
	}

	private void NotInitedUI(){
		joinAButton.interactable = false;
		leaveAButton.interactable = false;
		AMicToggle.gameObject.SetActive (false);
		joinBButton.interactable = false;
		leaveBButton.interactable = false;
		BMicToggle.gameObject.SetActive (false);
		micToggle.gameObject.SetActive (false);
	}

	private void InitedUI(){
		joinAButton.interactable = true;
		joinBButton.interactable = true;
	}

    private void OnApplicationQuit()
    {
        YouMe.YouMeVoiceAPI.GetInstance().UnInit();
    }
}
