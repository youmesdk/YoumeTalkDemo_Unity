using UnityEngine;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using System;

#if UNITY_IOS && !UNITY_EDITOR_WIN
using AOT;
#endif

namespace YouMe{

	public class YouMeVoiceAPI
	{
	    //////////////////////////////////////////////////////////////////////////////////////////////
		// 导出SDK所有的C接口API
	    //////////////////////////////////////////////////////////////////////////////////////////////
		
        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_init(string strAPPKey, string strAPPSecret, int serverRegionId, string strExtServerRegionName);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_unInit();

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern System.IntPtr youme_getCbMessage ();

		#if UNITY_IOS && !UNITY_EDITOR_WIN
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern void youme_freeCbMessage (System.IntPtr pMsg);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_setOutputToSpeaker (bool bOutputToSpeaker);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern void youme_setSpeakerMute (bool bOn);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern bool youme_getSpeakerMute ();

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern bool youme_getMicrophoneMute ();

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern void youme_setMicrophoneMute (bool mute);

		#if UNITY_IOS && !UNITY_EDITOR_WIN
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern void youme_setAutoSendStatus (bool bAutoSend);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_getVolume ();

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern void youme_setVolume (uint uiVolume);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern bool youme_getUseMobileNetworkEnabled ();

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern void youme_setUseMobileNetworkEnabled (bool bEnabled);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_joinChannelSingleMode (string strUserID, string strChannelID, int userRole, bool bCheckRoomExist);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_joinChannelMultiMode (string strUserID, string strChannelID, int userRole, bool bCheckRoomExist);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_speakToChannel(string strChannelID);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_leaveChannelMultiMode(string strChannelID);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_leaveChannelAll();

		#if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_setPcmCallback(UnityPcmCallbackDelegate unityPcmCallback, bool bOutputToSpeaker);

		#if UNITY_IOS && !UNITY_EDITOR_WIN
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern int youme_setOtherMicMute (string userID, bool mute);

		#if UNITY_IOS && !UNITY_EDITOR_WIN
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern int youme_setOtherSpeakerMute (string userID, bool mute);

		#if UNITY_IOS && !UNITY_EDITOR_WIN
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern int youme_setListenOtherVoice (string userID, bool isOn);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern void youme_setServerRegion (int regionId, string strExtRegionId, bool bAppend);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_playBackgroundMusic (string pFilePath, bool bRepeat);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_pauseBackgroundMusic ();

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_resumeBackgroundMusic ();

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_stopBackgroundMusic ();

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_setBackgroundMusicVolume (int volume);
		
        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_getBackgroundMusicVolume ();

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
	    private static extern int youme_setHeadsetMonitorOn(bool micEnabled, bool bgmEnabled);
	    
        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
    	private static extern int youme_setReverbEnabled(bool enabled);
        
        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
    	private static extern int youme_setVadCallbackEnabled(bool enabled);
        
        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
    	private static extern int youme_setMicLevelCallback(int maxLevel);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_pauseChannel();
        
        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_resumeChannel();
		        
        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern float youme_getSoundtouchPitchSemiTones();

		#if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_setSoundtouchPitchSemiTones(float fPitchSemiTones);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern void youme_setRecordingTimeMs(uint timeMs);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern void youme_setPlayingTimeMs(uint timeMs);
        
        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_getSDKVersion();

		#if UNITY_IOS && !UNITY_EDITOR_WIN
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern int  youme_requestRestApi( string strCommand , string  strQueryBody, ref int  requestID );

		#if UNITY_IOS && !UNITY_EDITOR_WIN
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern int  youme_getChannelUserList( string strChannelID , int maxCount ,  bool  notifyMemChange );


		#if UNITY_IOS && !UNITY_EDITOR_WIN
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern int  youme_setToken( string strToken );

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
    	private static extern int youme_setReleaseMicWhenMute(bool enabled);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
    	private static extern int youme_setExitCommModeWhenHeadsetPlugin(bool enabled);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_setGrabMicOption(string pChannelID, int mode, int maxAllowCount, int maxTalkTime, uint voteTime);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_startGrabMicAction(string pChannelID, string pContent);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_stopGrabMicAction(string pChannelID, string pContent);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_requestGrabMic(string pChannelID, int score, bool isAutoOpenMic, string pContent);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_releaseGrabMic(string pChannelID);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_setInviteMicOption(string pChannelID, int waitTimeout, int maxTalkTime);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_requestInviteMic(string pChannelID, string pUserID, string pContent);


        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_responseInviteMic(string pUserID, bool isAccept, string pContent);

        #if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_stopInviteMic();

		#if UNITY_IOS && !UNITY_EDITOR_WIN
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern int  youme_sendMessage( string pChannelID , string  pContent, ref int  requestID );

		#if UNITY_IOS && !UNITY_EDITOR_WIN
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern int youme_setWhiteUserList( string pChannelID,  string pWhiteUserList );
		
		#if UNITY_IOS && !UNITY_EDITOR_WIN
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern int youme_setUserRole( int userRole );
		
		#if UNITY_IOS && !UNITY_EDITOR_WIN
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern int youme_getUserRole();

		#if UNITY_IOS && !UNITY_EDITOR_WIN
        [DllImport("__Internal")]
        #else
        [DllImport("youme_voice_engine")]
        #endif
        private static extern int  youme_kickOtherFromChannel( string pUserID , string pChannelID , int lastTime );

		#if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern bool youme_releaseMicSync ();

		#if UNITY_IOS && !UNITY_EDITOR_WIN
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern bool youme_resumeMicSync ();

	    //////////////////////////////////////////////////////////////////////////////////////////////
		// 导出SDK所有的C接口API -- end
	    //////////////////////////////////////////////////////////////////////////////////////////////
        
		//
		// 回调消息类型定义， 需要跟底层匹配
		//
		private enum CallbackType
		{
			CALLBACK_TYPE_EVENT = 0,
			CALLBACK_TYPE_REST_API_RESPONSE, 
			CALLBACK_TYPE_MEMBER_CHANGE,
            CALLBACK_TYPE_BROADCAST
		}

		//
		// PcmCallback的回调数据， 需要跟底层匹配
		//
		[StructLayout(LayoutKind.Sequential)]
		private struct UnityPcmCallbackData {
			public int channelNum;
            public int samplingRateHz;
            public int bytesPerSample;
            public IntPtr data;
            public int dataSizeInByte;
		}
		
		//
		// PcmCallback的回调至外层的数据类
		//
		public class YoumePcmCallbackData {
			public int channelNum;
            public int samplingRateHz;
            public int bytesPerSample;
            public byte[] data;

			public YoumePcmCallbackData (int channelNum, int samplingRateHz, int bytesPerSample, IntPtr data, int dataSizeInByte) {
				this.channelNum = channelNum;
				this.samplingRateHz = samplingRateHz;
				this.bytesPerSample = bytesPerSample;
				this.data = new byte[dataSizeInByte];
				Marshal.Copy(data, this.data, 0, dataSizeInByte);
			}

			public YoumePcmCallbackData (int channelNum, int samplingRateHz, int bytesPerSample, byte[] data) {
				this.channelNum = channelNum;
				this.samplingRateHz = samplingRateHz;
				this.bytesPerSample = bytesPerSample;
                this.data = data;
            }
		}
		
		delegate void UnityPcmCallbackDelegate(IntPtr unityPcmCallbackData); 

		//
		// 回调处理
		// 主动调用底层函数查询当前是否有回调消息，如果有的话，做Json解析并传给上层
		//
		private class YoumeCallbackObject : MonoBehaviour {

			void Start() {
				InvokeRepeating("YoumeCallback", 0.5f, 0.05f);
			}

			void YoumeCallback ()
			{				
				System.IntPtr pMsg = YouMeVoiceAPI.youme_getCbMessage();
				if (pMsg == System.IntPtr.Zero) {
					return;
				}
				string strMessage = Marshal.PtrToStringAuto(pMsg);
				//Debug.Log("recv message:" + strMessage);
				if(null != strMessage)
				{
					try {
						YouMeVoiceAPI.GetInstance().ParseJsonCallbackMessage(strMessage);
					} catch (System.Exception e) {
						Debug.LogError(e.StackTrace);
					}
				}

				YouMeVoiceAPI.youme_freeCbMessage(pMsg);
				pMsg = System.IntPtr.Zero;
			}

		}

		//
		// 解析回调消息的Json字符串
		//
		private void ParseJsonCallbackMessage(string strMessage)
		{
			string strMethodName = null;
			string strCbMessage = null;

			JsonData jsonMessage =  JsonMapper.ToObject (strMessage);
			YouMeVoiceAPI.CallbackType cbType = (YouMeVoiceAPI.CallbackType)(int)jsonMessage ["type"];
			//Debug.Log ("###### callback message type:" + msgType);
			switch (cbType) {
			case YouMeVoiceAPI.CallbackType.CALLBACK_TYPE_EVENT:
				{
					strMethodName = "OnEvent";
					int eventType = (int)jsonMessage ["event"];
					int errCode = (int)jsonMessage ["error"];
					string channelId = (string)jsonMessage ["channelid"];
					string param = (string)jsonMessage ["param"];
					strCbMessage = "" + eventType + "," + errCode + "," + channelId + "," + param;
					//Debug.Log ("eventType:" + eventType + ",errCode:" + errCode + ", channelId:" + channelId + ",param:" + param );
				}
				break;
			case YouMeVoiceAPI.CallbackType.CALLBACK_TYPE_REST_API_RESPONSE:
				{
					strMethodName = "OnRequestRestApi";
					strCbMessage = strMessage;
				}
				break;
			case YouMeVoiceAPI.CallbackType.CALLBACK_TYPE_MEMBER_CHANGE:
				{
					strMethodName = "OnMemberChange";
					strCbMessage = strMessage;
				}
				break;
            case YouMeVoiceAPI.CallbackType.CALLBACK_TYPE_BROADCAST:
                {
                    strMethodName = "OnBroadcast";
                    int bcType = (int)jsonMessage["bc"];
                    string channelId = (string)jsonMessage["channelid"];
                    string param1 = (string)jsonMessage["param1"];
                    string param2 = (string)jsonMessage["param2"];
                    string content = (string)jsonMessage["content"];
                    strCbMessage = "" + bcType + "," + channelId + "," + param1 + "," + param2 + "," + content;
                }
                break;
            }
			if ((mCallbackObjName != null) && (strMethodName != null) && (strCbMessage != null)) {
				var gameObject = GameObject.Find(mCallbackObjName);
				if (gameObject != null)
				{
					gameObject.SendMessage(strMethodName, strCbMessage);
				}
			}
		}

		[AOT.MonoPInvokeCallback(typeof(UnityPcmCallbackDelegate))]  
		static void UnityPcmCallBackFunc(IntPtr param) {  
			UnityPcmCallbackData buffer = (UnityPcmCallbackData)Marshal.PtrToStructure(param, typeof(UnityPcmCallbackData));  
			if (null != mPcmCallback)
			{
				YoumePcmCallbackData data = new YoumePcmCallbackData(buffer.channelNum, buffer.samplingRateHz, buffer.bytesPerSample, buffer.data, buffer.dataSizeInByte);
                mPcmCallback(data);
			}
		} 

		//成员变量定义
		private static YouMeVoiceAPI mInstance;
		private string mCallbackObjName = null;
		private static System.Action<YoumePcmCallbackData> mPcmCallback = null;
 		#if UNITY_ANDROID && !UNITY_EDITOR_WIN
		private  bool mAndroidInited = false;
		private  bool mAndroidInitOK = false;
		private  AndroidJavaClass instance_youme_java;
		#endif

		//单实例对象
		public static YouMeVoiceAPI GetInstance()
		{
			if (mInstance == null)
			{
				mInstance = new YouMeVoiceAPI();
			}
			return mInstance;
		}

		YouMeVoiceAPI()
		{
			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				instance_youme_java = new AndroidJavaClass ("com.youme.voiceengine.api");					
			#endif
		}

        //////////////////////////////////////////////////////////////////////////////////////////////
        // C# 对外接口定义
        //////////////////////////////////////////////////////////////////////////////////////////////

		// 初始化Android Java部分，并load so库，同时启动Android Service
		#if UNITY_ANDROID && !UNITY_EDITOR_WIN
		private void InitAndroidJava()
		{
			try {
				if (!mAndroidInited) {
					mAndroidInited = true;

					AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
					AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
					AndroidJavaClass YouMeManager = new AndroidJavaClass ("com.youme.voiceengine.mgr.YouMeManager");
					mAndroidInitOK = YouMeManager.CallStatic<bool> ("Init", currentActivity);
				} 
			} catch {
				Debug.Log("android init exception!!!");
			}
		}
		#endif

        /// <summary>
        /// 设置接收回调消息的对象名。这个函数必须最先调用，这样才能收到后面所有调用的回调消息，包括Init(...)函数的回调。
        /// </summary>
        /// <param name="strObjName">用于接收回调消息的对象名</param>
        ///
		public void SetCallback(string strObjName)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				InitAndroidJava();
				if (!mAndroidInitOK) {
					return;
				}
			#endif 

			mCallbackObjName = strObjName;
		}

        /// <summary>
        /// 初始化语音引擎，做APP验证和资源初始化
        /// 这是一个异步调用接口，如果函数返回 YOUME_SUCCESS， 则需要等待以下事件回调达到才表明初始化完成。只有初始化成功，才能进行。
        /// 其他的操作，如进入/退出频道，开关麦克风等。
        /// YouMeEvent.YOUME_EVENT_INIT_OK - 表明初始化成功
        /// YouMeEvent.YOUME_EVENT_INIT_NOK - 表明初始化失败，最常见的失败原因是网络错误或者 AppKey/AppSecret 错误
        /// </summary>
        /// <param name="strAPPKey">从游密申请到的 app key, 这个你们应用程序的唯一标识</param>
        /// <param name="strAPPKey">对应 strAPPKey 的私钥, 这个需要妥善保存，不要暴露给其他人</param>
        /// <param name="serverRegionId">
        /// 设置首选连接服务器的区域码
        /// 如果在初始化时不能确定区域，可以填RTC_DEFAULT_SERVER，后面确定时通过 SetServerRegion 设置。
        /// 如果YOUME_RTC_SERVER_REGION定义的区域码不能满足要求，可以把这个参数设为 RTC_EXT_SERVER，然后
        /// 通过后面的参数 strExtServerRegionName 设置一个自定的区域值（如中国用 "cn" 或者 “ch"表示），然后把这个自定义的区域值同步给游密。
        /// 我们将通过后台配置映射到最佳区域的服务器。
        /// </param>
        /// <param name="strExtServerRegionName">扩展的服务器区域
        /// </param>
        ///
        /// <returns>返回接口调用是否成功的状态码，YouMeErrorCode.YOUME_SUCCESS表示成功</returns>
        ///
		public YouMeErrorCode Init(string strAppKey,string strAPPSecret, 
									YOUME_RTC_SERVER_REGION serverRegionId, string strExtServerRegionName)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				InitAndroidJava();
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif 

			GameObject callbackObj = new GameObject ("youme_update_once");
			GameObject.DontDestroyOnLoad (callbackObj);
			callbackObj.hideFlags = HideFlags.HideInHierarchy;
			callbackObj.AddComponent <YoumeCallbackObject>();

			return (YouMeErrorCode)youme_init (strAppKey, strAPPSecret, (int)serverRegionId, strExtServerRegionName);
		}

        /// <summary>
        /// 功能描述:反初始化引擎，在应用退出之前需要调用这个接口释放资源
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        ///
        /// <returns>返回接口调用是否成功的状态码，YouMeErrorCode.YOUME_SUCCESS表示成功</returns>
        ///
		public YouMeErrorCode UnInit ()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

			return (YouMeErrorCode)youme_unInit();
		}

        /// <summary>
        /// 设置服务器区域，默认是中国
        /// </summary>
        ///
        /// <param name="regionId">
        /// 设置首选连接服务器的区域码
        /// 如果YOUME_RTC_SERVER_REGION定义的区域码不能满足要求，可以把这个参数设为 RTC_EXT_SERVER，然后
        /// 通过下面的参数 strExtRegionName 设置一个自定的区域值，然后把这个自定义的区域值同步给游密。
        /// 我们将通过后台配置映射到最佳区域的服务器。
        /// </param>
        /// <param name="strExtRegionName">扩展的服务器区域
        /// </param>
        ///
        public void SetServerRegion(YOUME_RTC_SERVER_REGION regionId, string strExtRegionName){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				InitAndroidJava();
				if (!mAndroidInitOK) {
					return;
				}
			#endif 

			youme_setServerRegion((int)regionId, strExtRegionName, false);
        }

        /// <summary>
        /// 设置参与通话各方所在的区域
        /// 这个接口适合于分布区域比较广的应用。最简单的做法是只设定前用户所在区域。但如果能确定其他参与通话的应用所在的区域，则能使服务器选择更优。
        /// </summary>
        ///
        /// <param name="regionNames">
        /// 	指定参与通话各方区域的数组，数组里每个元素为一个区域代码。用户可以自行定义代表各区域的字符串（如中国用 "cn" 或者 “ch"表示），
        ///     然后把定义好的区域表同步给游密，游密会把这些定义配置到后台，在实际运营时选择最优服务器。
        /// </param>
        ///
        public void SetServerRegion(string[] regionNames){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				InitAndroidJava();
				if (!mAndroidInitOK) {
					return;
				}
			#endif

			if ((regionNames != null) && (regionNames.Length > 0)) {
				youme_setServerRegion ((int)YouMe.YOUME_RTC_SERVER_REGION.RTC_EXT_SERVER, regionNames[0], false);
			}
			for (int i = 1; i < regionNames.Length; i++) {
				youme_setServerRegion ((int)YouMe.YOUME_RTC_SERVER_REGION.RTC_EXT_SERVER, regionNames[i], true);
	        }
        }

        /// <summary>
        /// 切换语音输出设备
        /// 默认输出到扬声器，在加入房间成功后设置，如无听筒输出的需求尽量不要调用该接口。
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        /// </summary>
        ///
        /// <param name="bOutputToSpeaker">true为扬声器，false为听筒</param>
        ///
        /// <returns>返回接口调用是否成功的状态码，YouMeErrorCode.YOUME_SUCCESS表示成功</returns>
        ///
		public YouMeErrorCode SetOutputToSpeaker (bool bOutputToSpeaker)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

			return (YouMeErrorCode)youme_setOutputToSpeaker (bOutputToSpeaker);
		}

        /// <summary>
        /// 设置扬声器是否静音
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        /// </summary>
        ///
        /// <param name="bMute">true为麦克风静音，false为打开扬声器</param>
        ///
		public void SetSpeakerMute (bool bMute)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return;
				}
			#endif

			youme_setSpeakerMute (bMute);
		}
			
        /// <summary>
        /// 获取扬声器的静音状态
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        /// </summary>
        ///
        /// <returns>true 扬声器当前处于静音状态，false 扬声器当前处于打开状态， 默认情况下扬声器是打开的</returns>
        ///
		public bool GetSpeakerMute ()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return true;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return false;
				}
			#endif

			return youme_getSpeakerMute ();
		}


        /// <summary>
        /// 设置麦克风是否静音
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        /// </summary>
        ///
        /// <param name="bMute">true为麦克风静音，false为打开麦克风，默认情况下麦克风是关闭的</param>
        ///
        public void SetMicrophoneMute (bool mute)
        {
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return;
				}
			#endif

            youme_setMicrophoneMute (mute);
        }


        /// <summary>
        /// 获取麦克风的静音状态
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        /// </summary>
        ///
        /// <returns>true 麦克风当前处于静音状态，false 麦克风当前处于打开状态</returns>
        ///
		public bool GetMicrophoneMute ()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return false;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return false;
				}
			#endif

			return youme_getMicrophoneMute ();
		}

		/// <summary>
		/// 设置是否通知其他人，自己开关麦克风扬声器的状态
		/// </summary>
		///
		/// <param name="bAutoSend">true通知，false不通知
		///
		public void SetAutoSendStatus (bool bAutoSend)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
			if (!mAndroidInitOK) {
			return;
			}
			#endif

			youme_setAutoSendStatus (bAutoSend);
		}

        /// <summary>
        /// 设置通话音量
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        /// </summary>
        ///
        /// <param name="uiVolume"> 取值范围是[0-100] 100表示最大音量， 默认音量是100</param>
        ///
        public void SetVolume (uint uiVolume)
        {
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return;
				}
			#endif

            youme_setVolume (uiVolume);
        }

        /// <summary>
        /// 获取音量大小,此音量值为程序内部的音量，与系统音量相乘得到程序使用的实际音量
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        /// </summary>
        ///
        /// <returns>当前音量值，范围 [0-100]</returns>
        ///
		public int GetVolume ()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return 0;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return 0;
				}
			#endif

			return youme_getVolume ();
		}


        /// <summary>
        /// 设置是否允许使用移动网络(2G/3G/4G)进行通话。如果当前已经进入了语音频道，这个设置是不生效的，它只对下次通话有效。
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        /// </summary>
        ///
        /// <param name="bEnabled"> true-移动网络下允许通话，false-移动网络下不允许通话，默认允许 </param>
        ///
        public void SetUseMobileNetworkEnabled (bool bEnabled)
        {
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return;
				}
			#endif

            youme_setUseMobileNetworkEnabled (bEnabled);
        }

        /// <summary>
        /// 获取当前是否允许使用移动网络(2G/3G/4G)进行通话
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        /// </summary>
        ///
        /// <returns>true-移动网络下允许通话，false-移动网络下不允许通话</returns>
        ///
		public bool GetUseMobileNetworkEnabled ()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return true;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return false;
				}
			#endif

			return youme_getUseMobileNetworkEnabled ();
		}


        /// <summary>
        /// 加入语音频道（单频道模式，每个时刻只能在一个语音频道里面）
        /// 这是一个异步调用接口，函数返回YouMeErrorCode.YOUME_SUCCESS后，还需要等待如下事件回调
        /// YouMeEvent.YOUME_EVENT_CONNECTED - 成功进入语音频道
        /// YouMeEvent.YOUME_EVENT_CONNECT_FAILED - 进入语音频道失败，可能原因是网络或服务器有问题
        /// </summary>
        ///
        /// <param name="strUserID"> 全局唯一的用户标识，全局指在当前应用程序的范围内 </param>
        /// <param name="strChannelID"> 全局唯一的频道标识，全局指在当前应用程序的范围内 </param>
        /// <param name="userRole"> 用户在语音频道里面的角色，见YouMeUserRole定义 </param>
        /// <param name="bCheckRoomExist"> 是否检查频道存在时才加入，默认为false: true 当频道存在时加入、不存在时返回错误（多用于观众角色），false 无论频道是否存在都加入频道 </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功了启动了进入语音频道的流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
		public YouMeErrorCode JoinChannelSingleMode (string strUserID, string strChannelID, YouMeUserRole userRole, bool bCheckRoomExist=false)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

			return (YouMeErrorCode)youme_joinChannelSingleMode (strUserID, strChannelID, (int)userRole, bCheckRoomExist);
		}
				
        /// <summary>
        /// 加入语音频道（多频道模式，可以同时听多个语音频道的内容，但每个时刻只能对着一个频道讲话）
        /// 这是一个异步调用接口，函数返回YouMeErrorCode.YOUME_SUCCESS后，还需要等待如下事件回调
        /// YouMeEvent.YOUME_EVENT_CONNECTED - 成功进入语音频道
        /// YouMeEvent.YOUME_EVENT_CONNECT_FAILED - 进入语音频道失败，可能原因是网络或服务器有问题
        /// </summary>
        ///
        /// <param name="strUserID"> 全局唯一的用户标识，全局指在当前应用程序的范围内 </param>
        /// <param name="strChannelID"> 全局唯一的频道标识，全局指在当前应用程序的范围内 </param>
        /// <param name="userRole"> 用户在语音频道里面的角色，见YouMeUserRole定义 </param>
        /// <param name="bCheckRoomExist"> 是否检查频道存在时才加入，默认为false: true 当频道存在时加入、不存在时返回错误（多用于观众角色），false 无论频道是否存在都加入频道 </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功了启动了进入语音频道的流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode JoinChannelMultiMode (string strUserID, string strChannelID, YouMeUserRole userRole, bool bCheckRoomExist=false)
        {
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_joinChannelMultiMode (strUserID, strChannelID, (int)userRole, bCheckRoomExist);
        }

        /// <summary>
        /// 加入语音频道（多频道模式，可以同时听多个语音频道的内容，但每个时刻只能对着一个频道讲话，以自由讲话者身份）
        /// 这是一个异步调用接口，函数返回YouMeErrorCode.YOUME_SUCCESS后，还需要等待如下事件回调
        /// YouMeEvent.YOUME_EVENT_CONNECTED - 成功进入语音频道
        /// YouMeEvent.YOUME_EVENT_CONNECT_FAILED - 进入语音频道失败，可能原因是网络或服务器有问题
        /// </summary>
        ///
        /// <param name="strUserID"> 全局唯一的用户标识，全局指在当前应用程序的范围内 </param>
        /// <param name="strChannelID"> 全局唯一的频道标识，全局指在当前应用程序的范围内 </param>
        /// <param name="bCheckRoomExist"> 是否检查频道存在时才加入，默认为false: true 当频道存在时加入、不存在时返回错误（多用于观众角色），false 无论频道是否存在都加入频道 </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功了启动了进入语音频道的流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode JoinChannelMultiMode (string strUserID, string strChannelID, bool bCheckRoomExist=false)
        {
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_joinChannelMultiMode (strUserID, strChannelID, (int)YouMeUserRole.YOUME_USER_TALKER_FREE, bCheckRoomExist);
        }

        /// <summary>
        /// 多频道模式下，指定当前要讲话的频道
        /// 这是一个异步调用接口，函数返回YouMeErrorCode.YOUME_SUCCESS后，还需要等待如下事件回调
        /// YouMeEvent.YOUME_EVENT_SPEAK_SUCCESS - 成功进入语音频道
        /// YouMeEvent.YOUME_EVENT_SPEAK_FAILED - 进入语音频道失败，可能原因是网络或服务器有问题
        /// </summary>
        ///
        /// <param name="strUserID"> 全局唯一的用户标识，全局指在当前应用程序的范围内 </param>
        /// <param name="strChannelID"> 全局唯一的频道标识，全局指在当前应用程序的范围内 </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功了启动了进入语音频道的流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode SpeakToChannel (string strChannelID)
        {
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_speakToChannel (strChannelID);
        }

        /// <summary>
        /// 退出指定的语音频道
        /// 这是一个异步调用接口，函数返回YouMeErrorCode.YOUME_SUCCESS后，还需要等待如下事件回调
        /// YouMeEvent.YOUME_EVENT_TERMINATED - 成功退出语音频道
        /// YouMeEvent.YOUME_EVENT_TERMINATE_FAILED - 退出语音频道失败，可能原因是网络或服务器有问题。
        ///     只对多频道模式有意义，单频道模式下，退出总是成功的。
        /// </summary>
        ///
        /// <param name="strChannelID"> 指定要退出的频道的标识符 </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功了启动了退出语音频道的流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
		public YouMeErrorCode LeaveChannelMultiMode (string strChannelID)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

			return (YouMeErrorCode)youme_leaveChannelMultiMode (strChannelID);
		}

        /// <summary>
        /// 退出所有的语音频道
        /// 这是一个异步调用接口，函数返回YouMeErrorCode.YOUME_SUCCESS后，还需要等待如下事件回调
        /// YouMeEvent.YOUME_EVENT_TERMINATED。
        /// </summary>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功了启动了退出所有语音频道的流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode LeaveChannelAll ()
        {
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_leaveChannelAll ();
        }

		public YouMeErrorCode SetPcmCallback (System.Action<YoumePcmCallbackData> callback, bool bOutputToSpeaker = true)
        {
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif
			mPcmCallback = callback;
			#if (UNITY_ANDROID && ENABLE_IL2CPP) || !UNITY_ANDROID
            return (YouMeErrorCode)youme_setPcmCallback (UnityPcmCallBackFunc, bOutputToSpeaker);
			#else
			AndroidJavaObject pluginClass = new AndroidJavaClass("com.youme.voiceengine.api");
			pluginClass.CallStatic ("setPcmCallbackForUnity3D", new AndroidPluginCallback(),true);
            return YouMeErrorCode.YOUME_SUCCESS;
			#endif
        }
		
		#if UNITY_ANDROID
		class AndroidPluginCallback : AndroidJavaProxy
		{
			public AndroidPluginCallback() : base("com.youme.voiceengine.YouMeCallBackInterfacePcmForUnity") { }

			public void onPcmData(int channelNum, int samplingRateHz, int bytesPerSample, AndroidJavaObject javaByteData){
				if (null != mPcmCallback)
				{
					AndroidJavaObject bufferObject = javaByteData.Get<AndroidJavaObject>("data");
                    byte[] data = AndroidJNI.FromByteArray(bufferObject.GetRawObject());
                    YoumePcmCallbackData cbData = new YoumePcmCallbackData(channelNum, samplingRateHz, bytesPerSample,data);
					mPcmCallback(cbData);
				}
			}
		}
		#endif

		/// <summary>
		/// 设置他人麦克风静音
		/// </summary>
		///
		/// <param name="userID">要控制的用户的ID</param>
		/// <param name="mute">true为静音，false为取消静音</param>
		///
		/// <returns>返回接口调用是否成功的状态码，YouMeErrorCode.YOUME_SUCCESS表示成功</returns>
		///
		public YouMeErrorCode SetOtherMicMute (string userID,bool mute){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
			if (!mAndroidInitOK) {
			return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return (YouMeErrorCode)youme_setOtherMicMute(userID, mute );
		}

		/// <summary>
		/// 设置他人扬声器静音
		/// </summary>
		///
		/// <param name="userID">要控制的用户的ID</param>
		/// <param name="mute">true为静音，false为取消静音</param>
		///
		/// <returns>返回接口调用是否成功的状态码，YouMeErrorCode.YOUME_SUCCESS表示成功</returns>
		///
		public YouMeErrorCode SetOtherSpeakerMute (string userID,bool mute){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
			if (!mAndroidInitOK) {
			return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return (YouMeErrorCode)youme_setOtherSpeakerMute(userID, mute);
		}

		/// <summary>
		/// 设置是否接收指定用户的语音
		/// </summary>
		///
		/// <param name="userID">要屏蔽的用户的ID</param>
		/// <param name="isOn">true为打开，false为关闭</param>
		///
		/// <returns>返回接口调用是否成功的状态码，YouMeErrorCode.YOUME_SUCCESS表示成功</returns>
		///
		public YouMeErrorCode SetListenOtherVoice (string userID,bool isOn){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
			if (!mAndroidInitOK) {
			return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return (YouMeErrorCode)youme_setListenOtherVoice(userID, isOn);
		}


        /// <summary>
        /// 播放指定的音乐文件。播放的音乐将会通过扬声器输出，并和语音混合后发送给接收方。这个功能适合于主播/指挥等使用。
        /// 如果当前已经有一个音乐文件在播放，正在播放的音乐会被停止，然后播放新的文件。
        /// 这是一个异步调用接口，函数返回YouMeErrorCode.YOUME_SUCCESS后，将通过如下回调事件通知音乐播放的状态：
        /// YouMeEvent.YOUME_EVENT_BGM_STOPPED - 音乐播放结束了
        /// YouMeEvent.YOUME_EVENT_BGM_FAILED - 音乐文件无法播放（比如文件损坏，格式不支持等）
        /// </summary>
        ///
        /// <param name="strFilePath"> 音乐文件的路径 </param>
        /// <param name="bRepeat"> true 重复播放这个文件， false 只播放一次就停止播放 </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功启动了音乐播放流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
		public YouMeErrorCode PlayBackgroundMusic (string strFilePath, bool bRepeat){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_playBackgroundMusic(strFilePath, bRepeat);
		}

        /// <summary>
        /// 暂停播放当前正在播放的背景音乐。
        /// 这是一个同步调用接口。
        /// </summary>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功暂停了音乐播放流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
		public YouMeErrorCode PauseBackgroundMusic (){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_pauseBackgroundMusic();
		}

        /// <summary>
        /// 恢复当前暂停播放的背景音乐。
        /// 这是一个同步调用接口。
        /// </summary>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功恢复了音乐播放流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
		public YouMeErrorCode ResumeBackgroundMusic (){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_resumeBackgroundMusic();
		}

        /// <summary>
        /// 停止播放当前正在播放的背景音乐。
        /// 这是一个同步调用接口，函数返回时，音乐播放也就停止了。
        /// </summary>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功停止了音乐播放流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
		public YouMeErrorCode StopBackgroundMusic (){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_stopBackgroundMusic();
		}

        /// <summary>
        /// 设定背景音乐的音量。这个接口用于调整背景音乐和语音之间的相对音量，使得背景音乐和语音混合听起来协调。
        /// 这是一个同步调用接口
        /// </summary>
        ///
        /// <param name="volume"> 背景音乐的音量，范围 [0-100], 100为最大音量 </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功设置了背景音乐的音量
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
		public YouMeErrorCode SetBackgroundMusicVolume (int volume){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_setBackgroundMusicVolume(volume);
		}

        /// <summary>
        /// 返回设定的背景音乐音量。
        /// 这是一个同步调用接口
        /// </summary>
        ///
        /// <returns name="volume"> 背景音乐的音量，范围 [0-100], 100为最大音量 </returns>
        ///
        ///
		public int GetBackgroundMusicVolume (){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return 0;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return 0;
				}
			#endif

            return youme_getBackgroundMusicVolume();
		}

        /// <summary>
        /// 设置插耳机的情况下开启或关闭语音监听（即通过耳机听到自己说话的内容或背景音乐）
        /// 这是一个同步调用接口
        /// </summary>
        ///
        /// <param name="micEnabled"> 是否监听麦克风 true 监听，false 不监听 </param>
        /// <param name="bgmEnabled"> 是否监听背景音乐 true 监听，false 不监听 默认为true </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功设置了语音监听
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode SetHeadsetMonitorOn(bool micEnabled, bool bgmEnabled = true){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_setHeadsetMonitorOn(micEnabled, bgmEnabled);
        }

        /// <summary>
        /// 设置是否开启混响音效，这个主要对主播/指挥有用
        /// 这是一个同步调用接口
        /// </summary>
        ///
        /// <param name="enabled"> true 开启混响，false 关闭混响 </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功设置了混响音效
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode SetReverbEnabled(bool enabled){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_setReverbEnabled(enabled);
        }
        
        /// <summary>
        /// 设置是否开启语音检测回调
        /// 这是一个同步调用接口
        /// </summary>
        ///
        /// <param name="enabled"> true 开启语音检测，false 关闭语音检测 </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功设置了语音检测回调
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode SetVadCallbackEnabled(bool enabled){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_setVadCallbackEnabled(enabled);
        }

        /// <summary>
        /// 设置麦克风音量回调参数
        /// 你可以在初始化成功后随时调用这个接口。在整个APP生命周期只需要调用一次，除非你想修改参数。
        /// 设置成功后，当用户讲话时，你将收到回调事件 MY_MIC_LEVEL， 回调参数 iStatus 表示当前讲话的音量级别。
        /// </summary>
        ///
        /// <param name="maxMicLevel">
        /// 设为 0 表示关闭麦克风音量回调
        /// 设为 大于0的值表示音量最大时对应的值，这个可以根据你们的UI设计来设定。
        /// 比如你用10级的音量条来表示音量变化，则传10。这样当底层回传音量是10时，则表示当前mic音量达到最大值。
        /// </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表示设置成功
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode SetMicLevelCallback(int maxMicLevel){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_setMicLevelCallback(maxMicLevel);
        }

        /// <summary>
        /// 暂停通话，释放对麦克风等设备资源的占用。当需要用第三方模块临时录音时，可调用这个接口。
        /// 这是一个异步调用接口，函数返回YouMeErrorCode.YOUME_SUCCESS后，还需要等待如下事件回调
        /// YouMeEvent.YOUME_EVENT_PAUSED - 成功暂停语音
        /// YouMeEvent.YOUME_EVENT_CONNECT_FAILED - 暂停语音失败
        /// </summary>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明暂停通话正在进行当中
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode PauseChannel(){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_pauseChannel();
        }
        
        /// <summary>
        /// 恢复通话，调用PauseChannel暂停通话后，可调用这个接口恢复通话
        /// 这是一个异步调用接口，函数返回YouMeErrorCode.YOUME_SUCCESS后，还需要等待如下事件回调
        /// YouMeEvent.YOUME_EVENT_RESUMED - 成功恢复语音
        /// YouMeEvent.YOUME_EVENT_RESUME_FAILED - 恢复语音失败
        /// </summary>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明恢复通话正在进行当中
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode ResumeChannel(){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_resumeChannel();
        }
		
		/**
         *  功能描述: 获取变声音调（增值服务，需要后台配置开启）
         *  @return 变声音调，范围为-12~12，0为原声，值越高音调越高
         */
		public float GetSoundtouchPitchSemiTones(){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return 0;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return 0;
				}
			#endif

            return youme_getSoundtouchPitchSemiTones();
		}

		/**
         *  功能描述: 设置变声音调（增值服务，需要后台配置开启），退出房间时重置为0
         *  @param fPitchSemiTones: 变声音调，范围为-12~12，0为原声，值越高音调越高
         *  @return   YOUME_SUCCESS - 成功
         *          其他 - 具体错误码
         */
		public YouMeErrorCode SetSoundtouchPitchSemiTones(float fPitchSemiTones){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_setSoundtouchPitchSemiTones(fPitchSemiTones);
        }

        /// <summary>
        /// 设置当前录音的时间戳。当通过录游戏脚本进行直播时，要保证观众端音画同步，在主播端需要进行时间对齐。
        /// 这个接口设置的就是当前游戏画面录制已经进行到哪个时间点了。
        /// </summary>
        ///
		/// <param name="timeMs"> 当前游戏画面对应的时间点，单位为毫秒 </param>
        /// <returns> void </returns>
        ///
        public void SetRecordingTimeMs(uint timeMs){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return;
				}
			#endif

            youme_setRecordingTimeMs(timeMs);
        }

        /// <summary>
        /// 设置当前声音播放的时间戳。当通过录游戏脚本进行直播时，要保证观众端音画同步，游戏画面的播放需要和声音播放进行时间对齐。
        /// 这个接口设置的就是当前游戏画面播放已经进行到哪个时间点了。
        /// </summary>
        ///
		/// <param name="timeMs"> 当前游戏画面播放对应的时间点，单位为毫秒 </param>
        /// <returns> void </returns>
        ///
        public void SetPlayingTimeMs(uint timeMs){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return;
				}
			#endif

            youme_setPlayingTimeMs(timeMs);
        }

        /// <summary>
        /// 获取SDK版本号，版本号分为4段，如 2.5.0.0，这4段在int里面的分布如下
        /// | 4 bits | 6 bits | 8 bits | 14 bits|
        /// </summary>
        ///
        /// <returns>
        /// 压缩过的版本号
        /// </returns>
        ///
        public int GetSDKVersion(){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return 0;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return 0;
				}
			#endif

            return youme_getSDKVersion();
        }

		/**
 		 *  功能描述:Rest API , 向服务器请求额外数据
   		 *  @param strCommand: 请求的命令字符串
  		 *  @param strQueryBody: 请求需要的数据,json格式，内容参考restAPI
   		 *  @param requestID: 回传id,回调的时候传回，标识消息。
   		 *  @return YOUME_SUCCESS - 成功
     	 *          其他 - 具体错误码
		 */
		public YouMeErrorCode  RequestRestApi( string command, string queryBody, ref int  requestID ){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
			if (!mAndroidInitOK) {
			return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return (YouMeErrorCode)youme_requestRestApi( command,  queryBody, ref requestID );
		}

		/**
   		*  功能描述:查询频道的用户列表(必须在频道中)
   		*  @param channelID:要查询的频道ID
    	*  @param maxCount:想要获取的最大数量，-1表示获取全部
     	*  @param notifyMemChagne: 其他用户进出房间时，是否要收到通知
     	*  @return 错误码，详见YouMeConstDefine.h定义
     	*/
		public YouMeErrorCode  GetChannelUserList( string channelID,  int maxCount, bool notifyMemChange  ){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
			if (!mAndroidInitOK) {
			return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return (YouMeErrorCode)youme_getChannelUserList( channelID,  maxCount, notifyMemChange);
		}

		/**
        *  功能描述:设置身份验证的token
        *  @param strToken: 身份验证用token，设置为NULL或者空字符串，清空token值,则不验证。
        *  @return 无
        */
		public void  SetToken( string strToken  ){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
			if (!mAndroidInitOK) {
			return;
			}
			#endif

			youme_setToken(strToken);
		}

        /// <summary>
        /// 设置当麦克风静音时，是否释放麦克风设备，在初始化之后、加入房间之前调用
        /// 这是一个同步调用接口
        /// </summary>
        ///
        /// <param name="enabled">
        ///     true 当麦克风静音时，释放麦克风设备，此时允许第三方模块使用麦克风设备录音。在Android上，语音通过媒体音轨，而不是通话音轨输出。
        ///     false 不管麦克风是否静音，麦克风设备都会被占用。
        /// </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明设置成功
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode SetReleaseMicWhenMute(bool enabled){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_setReleaseMicWhenMute(enabled);
        }

        /// <summary>
        /// 设置插入耳机时，是否自动退出系统通话模式(禁用手机系统硬件信号前处理)
        /// 系统提供的前处理效果包括回声消除、自动增益等，有助于抑制背景音乐等回声噪音，减少系统资源消耗，对Windows系统无效
        /// 由于插入耳机可从物理上阻断回声产生，故可设置禁用该效果以保留背景音乐的原生音质效果
        /// 默认为false，在初始化之后、加入房间之前调用
        /// 这是一个同步调用接口
        /// </summary>
        ///
        /// <param name="enabled">
        ///     true 当插入耳机时，自动禁用系统硬件信号前处理，拔出时还原
        ///     false 插拔耳机不做处理
        /// </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明设置成功
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode SetExitCommModeWhenHeadsetPlugin(bool enabled){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_setExitCommModeWhenHeadsetPlugin(enabled);
        }


		//---------------------抢麦接口---------------------//
        /**
        * 功能描述:    抢麦相关设置（抢麦活动发起前调用此接口进行设置）
        * @param const char * pChannelID: 抢麦活动的频道id
        * @param int mode: 抢麦模式（1:先到先得模式；2:按权重分配模式）
        * @param int maxAllowCount: 允许能抢到麦的最大人数
        * @param int maxTalkTime: 允许抢到麦后使用麦的最大时间（秒）
        * @param unsigned int voteTime: 抢麦仲裁时间（秒），过了X秒后服务器将进行仲裁谁最终获得麦（仅在按权重分配模式下有效）
        * @return   YOUME_SUCCESS - 成功
        *          其他 - 具体错误码
        */
        public YouMeErrorCode SetGrabMicOption(string pChannelID, int mode, int maxAllowCount, int maxTalkTime, uint voteTime)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
            #endif

            return (YouMeErrorCode)youme_setGrabMicOption(pChannelID, mode, maxAllowCount, maxTalkTime, voteTime);
        }
		
		/**
		* 功能描述:    发起抢麦活动
		* @param const char * pChannelID: 抢麦活动的频道id
		* @param const char * pContent: 游戏传入的上下文内容，通知回调会传回此内容（目前只支持纯文本格式）
		* @return   YOUME_SUCCESS - 成功
		*          其他 - 具体错误码
		*/
        public YouMeErrorCode StartGrabMicAction(string pChannelID, string pContent)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
            #endif

            return (YouMeErrorCode)youme_startGrabMicAction(pChannelID, pContent);
        }
		
		/**
		* 功能描述:    停止抢麦活动
		* @param const char * pChannelID: 抢麦活动的频道id
		* @param const char * pContent: 游戏传入的上下文内容，通知回调会传回此内容（目前只支持纯文本格式）
		* @return   YOUME_SUCCESS - 成功
		*          其他 - 具体错误码
		*/
        public YouMeErrorCode StopGrabMicAction(string pChannelID, string pContent)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
            #endif

            return (YouMeErrorCode)youme_stopGrabMicAction(pChannelID, pContent);
        }
		
		/**
		* 功能描述:    发起抢麦请求
		* @param const char * pChannelID: 抢麦的频道id
		* @param int score: 积分（权重分配模式下有效，游戏根据自己实际情况设置）
		* @param bool isAutoOpenMic: 抢麦成功后是否自动开启麦克风权限
		* @param const char * pContent: 游戏传入的上下文内容，通知回调会传回此内容（目前只支持纯文本格式）
		* @return   YOUME_SUCCESS - 成功
		*          其他 - 具体错误码
		*/
        public YouMeErrorCode requestGrabMic(string pChannelID, int score, bool isAutoOpenMic, string pContent)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
            #endif

            return (YouMeErrorCode)youme_requestGrabMic(pChannelID, score, isAutoOpenMic, pContent);
        }
		
		/**
		* 功能描述:    释放抢到的麦
		* @param const char * pChannelID: 抢麦活动的频道id
		* @return   YOUME_SUCCESS - 成功
		*          其他 - 具体错误码
		*/		
		public YouMeErrorCode releaseGrabMic(string pChannelID)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
            #endif

            return (YouMeErrorCode)youme_releaseGrabMic(pChannelID);
        }
		
		//---------------------连麦接口---------------------//
		/**
		* 功能描述:    连麦相关设置（角色是频道的管理者或者主播时调用此接口进行频道内的连麦设置）
		* @param const char * pChannelID: 连麦的频道id
		* @param int waitTimeout: 等待对方响应超时时间（秒）
		* @param int maxTalkTime: 最大通话时间（秒）
		* @return   YOUME_SUCCESS - 成功
		*          其他 - 具体错误码
		*/
		public YouMeErrorCode setInviteMicOption(string pChannelID, int waitTimeout, int maxTalkTime)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
            #endif

            return (YouMeErrorCode)youme_setInviteMicOption(pChannelID, waitTimeout, maxTalkTime);
        }
		
		/**
		 * 功能描述:    发起与某人的连麦请求（主动呼叫）
		 * @param const char * pUserID: 被叫方的用户id
		 * @param const char * pContent: 游戏传入的上下文内容，通知回调会传回此内容（目前只支持纯文本格式）
		 * @return   YOUME_SUCCESS - 成功
		 *          其他 - 具体错误码
		 */		
		public YouMeErrorCode requestInviteMic(string pChannelID, string pUserID, string pContent)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
            #endif

            return (YouMeErrorCode)youme_requestInviteMic(pChannelID, pUserID, pContent);
        }

		/**
		 * 功能描述:    对连麦请求做出回应（被动应答）
		 * @param const char * pUserID: 主叫方的用户id
		 * @param bool isAccept: 是否同意连麦
		 * @param const char * pContent: 游戏传入的上下文内容，通知回调会传回此内容（目前只支持纯文本格式）
		 * @return   YOUME_SUCCESS - 成功
		 *          其他 - 具体错误码
		 */
		public YouMeErrorCode responseInviteMic(string pUserID, bool isAccept, string pContent)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
            #endif

            return (YouMeErrorCode)youme_responseInviteMic(pUserID, isAccept, pContent);
        }
		
		/**
		* 功能描述:    停止连麦
		* @return   YOUME_SUCCESS - 成功
		*          其他 - 具体错误码
		*/
		public YouMeErrorCode stopInviteMic()
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
            #endif

            return (YouMeErrorCode)youme_stopInviteMic();
        }		

		/**
    	 * 功能描述:   向房间广播消息
     	 * @param channelID: 广播房间
    	 * @param content: 广播内容-文本串
	     * @param requestID:返回消息标识，回调的时候会回传该值
   		 *  @return YOUME_SUCCESS - 成功
     	 *          其他 - 具体错误码
		 */
		public YouMeErrorCode  SendMessage( string channelID, string content, ref int  requestID ){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
			return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
			if (!mAndroidInitOK) {
			return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return (YouMeErrorCode)youme_sendMessage( channelID,  content, ref requestID );
		}

		/**
    	 * 功能描述:   对频道设置白名单用户
    	 * @param channelID: 要设置的频道
    	 * @param whiteUserList: 白名单用户列表, 以|分隔，如：User1|User2|User3
     	 * @return   YOUME_SUCCESS - 成功
     	 *          其他 - 具体错误码
         */
        public YouMeErrorCode  SetWhiteUserList( string channelID,  string whiteUserList ) {
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
			return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
			if (!mAndroidInitOK) {
			return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return (YouMeErrorCode)youme_setWhiteUserList( channelID,  whiteUserList );
		}
		
		/**
		 *  功能描述:切换身份(仅支持单频道模式，进入房间以后设置)
		 *
		 *  @param userRole: 用户身份
		 *
		 *  @return YOUME_SUCCESS - 成功
     	 *          其他 - 具体错误码
		 */
		public YouMeErrorCode SetUserRole( YouMeUserRole userRole ) {
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
			return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
			if (!mAndroidInitOK) {
			return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return (YouMeErrorCode)youme_setUserRole( (int)userRole );
		}

		/**
		 *  功能描述:获取身份(仅支持单频道模式)
		 *
		 *  @return 身份定义，详见YouMeUserRole定义
		 */
		public YouMeUserRole GetUserRole() {
			return (YouMeUserRole)youme_getUserRole();
		}

		 /**
         *  功能描述: 把某人踢出房间
         *  @param  userID: 被踢的用户ID
         *  @param  channelID: 从哪个房间踢出
         *  @param  lastTime: 踢出后，多长时间内不允许再次进入
         *  @return YOUME_SUCCESS - 成功
         *          其他 - 具体错误码
         */
        private YouMeErrorCode KickOtherFromChannel( string userID , string channelID , int lastTime )
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN
            return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN
            if (!mAndroidInitOK) {
            return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
            }
            #endif

            return (YouMeErrorCode)youme_kickOtherFromChannel( userID, channelID, lastTime );
        }

		/// <summary>
        /// 调用后同步完成麦克风释放，只是为了方便使用 IM 的录音接口时切换麦克风使用权。
        /// </summary>
        ///
        /// <returns>true 表示成功，目前只有没有进入频道调用可能返回false。</returns>
        ///
		public bool ReleaseMicSync ()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return true;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return false;
				}
			#endif

			return youme_releaseMicSync ();
		}

		/// <summary>
        /// 调用后恢复麦克风到释放前的状态，对应 ReleaseMicSync ，只是为了方便使用 IM 的录音接口时切换麦克风使用权。
        /// </summary>
        ///
        /// <returns>true 表示成功，目前只有没有进入频道调用可能返回false。</returns>
        ///
		public bool ResumeMicSync ()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN
				return true;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN
				if (!mAndroidInitOK) {
					return false;
				}
			#endif

			return youme_resumeMicSync ();
		}

	} //YouMeVoiceAPI
}
