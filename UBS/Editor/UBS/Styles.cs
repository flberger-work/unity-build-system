using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

namespace UBS
{
	internal static class Styles
	{
		public const string kImagePath = "Assets/packages/UBS/Editor/images/";

		static Dictionary<long,Texture2D>mTextures = new Dictionary<long, Texture2D>();
		
		static Texture2D GetTexture(long pColorRGBA)
		{
			if (mTextures.ContainsKey(pColorRGBA) && mTextures [pColorRGBA] != null)
				return mTextures [pColorRGBA];
				
			Color32 c = GetColor(pColorRGBA);
			
			var tmp = new Texture2D(4, 4);
			for (int x = 0; x < 4; x++)
				for (int y = 0; y < 4; y++)
					tmp.SetPixel(x, y, c);
			tmp.Apply();
			tmp.Compress(true);
			
			mTextures [pColorRGBA] = tmp;
			
			return tmp; 
		}
		
		static Color32 GetColor(long pColorRGBA)
		{
			byte r = (byte)((pColorRGBA & 0xff000000) >> 24);
			byte g = (byte)((pColorRGBA & 0xff0000) >> 16);
			byte b = (byte)((pColorRGBA & 0xff00) >> 8);
			byte a = (byte)((pColorRGBA & 0xff));
			
			Color32 c = new Color32(r, g, b, a);
			return c;
		}
		
		static GUIStyle mList;
		public static GUIStyle list
		{
			get
			{
				if (mList == null)
				{
					mList = new GUIStyle();
					mList.normal.background = GetTexture(0x424646ff);
					mList.alignment = TextAnchor.UpperLeft;
					mList.stretchWidth = true;
					mList.stretchHeight = true;
				}
				return mList;
			}
		}

		static GUIStyle mBoldKey;
		public static GUIStyle boldKey
		{
			get
			{
				if (mBoldKey == null)
				{
					mBoldKey = new GUIStyle();
					if (EditorGUIUtility.isProSkin)
						mBoldKey.normal.textColor = GetColor(0xffffffff);
					else
						mBoldKey.normal.textColor = GetColor(0x000000ff);
					mBoldKey.fontStyle = FontStyle.Bold;
					mBoldKey.alignment = TextAnchor.MiddleLeft;
					
					
				}
				return mBoldKey;
			}
		}

		static GUIStyle mBuildProcessEditorBackground;
		public static GUIStyle buildProcessEditorBackground
		{
			get
			{
				if (mBuildProcessEditorBackground == null)
				{
					mBuildProcessEditorBackground = new GUIStyle();
					if (EditorGUIUtility.isProSkin)
						mBuildProcessEditorBackground.normal.background = GetTexture(0x444444aa);
					else
						mBuildProcessEditorBackground.normal.background = GetTexture(0xeeeeeeaa);
				}
				return mBuildProcessEditorBackground;
			}
		}

		static Texture2D mGear;
		public static Texture2D gear
		{
			get
			{
				if (mGear == null)
				{
					mGear = (Texture2D)AssetDatabase.LoadAssetAtPath(Styles.kImagePath + "gear.png", typeof(Texture2D));

				}
				return mGear;
			}
		}
		static Texture2D mIcoIOS;
		public static Texture2D icoIOS
		{
			get
			{
				if (mIcoIOS == null)
				{
					mIcoIOS = (Texture2D)AssetDatabase.LoadAssetAtPath(Styles.kImagePath + "icons/ico_ios.png", typeof(Texture2D));
					
				}
				return mIcoIOS;
			}
		}
		static Texture2D mIcoAndroid;
		public static Texture2D icoAndroid
		{
			get
			{
				if (mIcoAndroid == null)
				{
					mIcoAndroid = (Texture2D)AssetDatabase.LoadAssetAtPath(Styles.kImagePath + "icons/ico_android.png", typeof(Texture2D));
					
				}
				return mIcoAndroid;
			}
		}
		static Texture2D mIcoWindows;
		public static Texture2D icoWindows
		{ 
			get
			{
				if (mIcoWindows == null)
				{
					mIcoWindows = (Texture2D)AssetDatabase.LoadAssetAtPath(Styles.kImagePath + "icons/ico_windows.png", typeof(Texture2D));
					
				}
				return mIcoWindows;
			}
		}
		static GUIStyle mIcon;
		public static GUIStyle icon
		{ 
			get
			{
				if (mIcon == null)
				{
					mIcon = new GUIStyle();
					mIcon.fixedWidth = 20;
					mIcon.fixedHeight = 20;
					mIcon.contentOffset = new Vector2(-8f, -2f);
				}
				return mIcon;
			}
		}

		static GUIStyle mNormalValue;
		public static GUIStyle normalValue
		{
			get
			{
				if (mNormalValue == null)
				{
					mNormalValue = new GUIStyle();
					if (EditorGUIUtility.isProSkin)
						mNormalValue.normal.textColor = GetColor(0xffffffff);
					else
						mNormalValue.normal.textColor = GetColor(0x000000ff);
					mNormalValue.fontStyle = FontStyle.Normal;
					mNormalValue.alignment = TextAnchor.MiddleLeft;
					
					
				}
				return mNormalValue;
			}
		}

		static GUIStyle mSelectableListEntryText;
		public static GUIStyle selectableListEntryText
		{
			get
			{
				if (mSelectableListEntryText == null)
				{
					mSelectableListEntryText = new GUIStyle(list);
					mSelectableListEntryText.normal.textColor = GetColor(0xb5b5b5ff);
					mSelectableListEntryText.fontStyle = FontStyle.Bold;

					
				}
				return mSelectableListEntryText;
			}
		}
		static GUIStyle mSelectableListEntryTextOdd;
		public static GUIStyle selectableListEntryTextOdd
		{
			get
			{
				if (mSelectableListEntryTextOdd == null)
				{
					mSelectableListEntryTextOdd = new GUIStyle(list);
					mSelectableListEntryTextOdd.normal.textColor = GetColor(0xb5b5b5ff);
					mSelectableListEntryTextOdd.normal.background = GetTexture(0x333535ff);
					mSelectableListEntryTextOdd.fontStyle = FontStyle.Bold;
					
					
				}
				return mSelectableListEntryTextOdd;
			}
		}

		static GUIStyle mSelectableListEntry;
		public static GUIStyle selectableListEntry
		{
			get
			{
				if (mSelectableListEntry == null)
				{
					mSelectableListEntry = new GUIStyle(list);
					mSelectableListEntry.stretchHeight = false;
					mSelectableListEntry.normal.textColor = GetColor(0xb5b5b5ff);
					mSelectableListEntry.fontStyle = FontStyle.Bold;
					mSelectableListEntry.padding = new RectOffset(20, 20, 10, 9);
					mSelectableListEntry.border = new RectOffset(0, 0, 0, 1);
					
				}
				return mSelectableListEntry;
			}
		}
		
		static GUIStyle mSelectableListEntryOdd;
		public static GUIStyle selectableListEntryOdd
		{
			get
			{
				if (mSelectableListEntryOdd == null)
				{
					mSelectableListEntryOdd = new GUIStyle(selectableListEntry);
					mSelectableListEntryOdd.normal.background = GetTexture(0x333535ff);
					
				}
				return mSelectableListEntryOdd;
			}
		}

		static GUIStyle mToolButton;
		public static GUIStyle toolButton
		{
			get
			{
				if (mToolButton == null)
				{
					mToolButton = new GUIStyle("TE toolbarbutton");

					mToolButton.fontSize = 24;
					mToolButton.fontStyle = FontStyle.Bold;
					mToolButton.fixedHeight = 28;
					mToolButton.padding = new RectOffset(5, 5, 5, 5);
					mToolButton.contentOffset = new Vector2(-1, 0);
					mToolButton.clipping = TextClipping.Overflow;

				}
				return mToolButton;
			}

		}
		
		static GUIStyle mSelectedListEntry;
		public static GUIStyle selectedListEntry
		{
			get
			{
				if (mSelectedListEntry == null)
				{
					mSelectedListEntry = new GUIStyle();
					mSelectedListEntry.normal.background = GetTexture(0x1b76d1ff);
					mSelectedListEntry.normal.textColor = GetColor(0xffffffff);
					mSelectedListEntry.fontStyle = FontStyle.Bold;
					mSelectedListEntry.padding = new RectOffset(20, 20, 10, 9);
					mSelectedListEntry.border = new RectOffset(0, 0, 0, 1);
				}
				return mSelectedListEntry;
			}
		}

		static GUIStyle mDirtySetting;
		public static GUIStyle dirtySetting
		{
			get
			{
				if (mDirtySetting == null)
				{
					mDirtySetting = new GUIStyle();
					mDirtySetting.normal.background = GetTexture(0x1b76d1ff);

				}
				return mDirtySetting;
			}
		}
		
		static GUIStyle mBigHint;
		public static GUIStyle bigHint
		{
			get
			{
				if (mBigHint == null)
				{
					mBigHint = new GUIStyle();
					mBigHint.alignment = TextAnchor.MiddleCenter;
					mBigHint.stretchWidth = true;
					mBigHint.stretchHeight = true;
					mBigHint.fontSize = 32;
					mBigHint.fontStyle = FontStyle.Bold;
					mBigHint.normal.textColor = GetColor(0x00000066);
				}
				return mBigHint;
			}
		}
		static GUIStyle mMediumHint;
		public static GUIStyle mediumHint
		{
			get
			{
				if (mMediumHint == null)
				{
					mMediumHint = new GUIStyle();
					mMediumHint.alignment = TextAnchor.MiddleCenter;
					mMediumHint.stretchWidth = true;
					mMediumHint.stretchHeight = false;
					mMediumHint.fontSize = 24;
					mMediumHint.fontStyle = FontStyle.Bold;
					mMediumHint.normal.textColor = GetColor(0x00000066);
				}
				return mMediumHint;
			}
		}
		
		static GUIStyle mDetailsGroup;
		public static GUIStyle detailsGroup
		{
			get
			{
				if (mDetailsGroup == null)
				{
					mDetailsGroup = new GUIStyle();
					mDetailsGroup.alignment = TextAnchor.UpperLeft;
					mDetailsGroup.margin = new RectOffset(2, 2, 2, 2);
					
				}
				return mDetailsGroup;
			}
		}
		
		static GUIStyle mInfoGroup;
		public static GUIStyle infoGroup
		{
			get
			{
				if (mInfoGroup == null)
				{
					mInfoGroup = new GUIStyle();
					mInfoGroup.alignment = TextAnchor.UpperLeft;
					mInfoGroup.margin = new RectOffset(20, 20, 2, 10);
					mInfoGroup.padding = new RectOffset(10, 10, 5, 5);
					mInfoGroup.normal.background = GetTexture(0x00000066);
					
				}
				return mInfoGroup;
			}
		}

		static GUIStyle mDetailsGizmo;
		public static GUIStyle detailsGizmo
		{
			get
			{
				if (mDetailsGizmo == null)
				{
					mDetailsGizmo = new GUIStyle();
					mDetailsGizmo.alignment = TextAnchor.MiddleLeft;
					mDetailsGizmo.fixedWidth = 32;
					mDetailsGizmo.fixedHeight = 32;
					mDetailsGizmo.margin = new RectOffset(10, 10, 0, 0);
					mDetailsGizmo.normal.textColor = Color.white;
					
				}
				return mDetailsGizmo;
			}
		}
		
			
		static GUIStyle mDetailsTitle;
		public static GUIStyle detailsTitle
		{
			get
			{
				if (mDetailsTitle == null)
				{
					mDetailsTitle = new GUIStyle();
					mDetailsTitle.alignment = TextAnchor.MiddleLeft;
					mDetailsTitle.fontSize = 32;
					mDetailsTitle.fontStyle = FontStyle.Bold;
					mDetailsTitle.margin = new RectOffset(10, 10, 10, 10);
					mDetailsTitle.normal.textColor = GetColor(0x00000066);
					
				}
				return mDetailsTitle;
			}
		}
		
		static GUIStyle mDetailsDescription;
		public static GUIStyle detailsDescription
		{
			get
			{
				if (mDetailsDescription == null)
				{
					mDetailsDescription = new GUIStyle();
					mDetailsDescription.alignment = TextAnchor.UpperLeft;
					mDetailsDescription.margin = new RectOffset(65, 10, 10, 15);
					mDetailsDescription.wordWrap = true;
					
				}
				return mDetailsDescription;
			}
		}
		
		
		
		static GUIStyle mStatusMessage;
		public static GUIStyle statusMessage
		{
			get
			{
				if (mStatusMessage == null)
				{
					mStatusMessage = new GUIStyle();
					mStatusMessage.alignment = TextAnchor.MiddleCenter;
					mStatusMessage.stretchWidth = false;
					mStatusMessage.stretchHeight = false;
					mStatusMessage.fixedHeight = 20;
					mStatusMessage.fontSize = 12;
					mStatusMessage.margin = new RectOffset(10, 10, 2, 2);
					mStatusMessage.normal.textColor = GetColor(0x00000066);
				}
				return mStatusMessage;
			}
		}

		static GUIStyle mSettingsDescription;
		public static GUIStyle settingDescription
		{
			get
			{
				if (mSettingsDescription == null)
				{
					mSettingsDescription = new GUIStyle();
					mSettingsDescription.alignment = TextAnchor.MiddleRight;
					mSettingsDescription.imagePosition = ImagePosition.ImageOnly;
					mSettingsDescription.fixedWidth = 32;
					mSettingsDescription.fixedHeight = 20;
					mSettingsDescription.stretchHeight = false;
					mSettingsDescription.stretchWidth = false;
					mSettingsDescription.margin = new RectOffset(10, 10, 2, 2);

				}
				return mSettingsDescription;
			}
		}

		
		static GUIStyle mHLine;
		public static GUIStyle hLine
		{
			get
			{
				if (mHLine == null)
				{
					mHLine = new GUIStyle();
					mHLine.alignment = TextAnchor.MiddleCenter;
					mHLine.stretchWidth = true;
					mHLine.fixedHeight = 1;
					mHLine.normal.background = GetTexture(0x00000066);
				}
				return mHLine;
			}
		}
		
		
		static GUIStyle mVLine;
		public static GUIStyle vLine
		{
			get
			{
				if (mVLine == null)
				{
					mVLine = new GUIStyle();
					mVLine.alignment = TextAnchor.MiddleCenter;
					mVLine.stretchHeight = true;
					mVLine.fixedHeight = 0;
					mVLine.fixedWidth = 1;
					mVLine.normal.background = GetTexture(0xffffff66);
				}
				return mVLine;
			}
		}
		
		
		public static void VerticalLine()
		{
			GUILayout.Label("", vLine);
		}
		
		public static void HorizontalLine()
		{
			GUILayout.Label("", hLine);
		}

		static GUIStyle mHSeparator;
		public static GUIStyle hSeparator
		{
			get
			{
				if (mHSeparator == null)
				{
					mHSeparator = new GUIStyle();
					mHSeparator.alignment = TextAnchor.MiddleCenter;
					mHSeparator.stretchWidth = true;
					mHSeparator.fixedHeight = 1;
					mHSeparator.margin = new RectOffset(20, 20, 5, 5);
					mHSeparator.normal.background = GetTexture(0x00000066);
				}
				return mHSeparator;
			}
		}

		static GUIStyle mProgressBar;
		public static GUIStyle progressBar
		{
			get
			{
				if (mProgressBar == null)
				{
					mProgressBar = new GUIStyle();
					mProgressBar.alignment = TextAnchor.MiddleCenter;
					mProgressBar.stretchWidth = true;
					mProgressBar.stretchHeight = true;
					mProgressBar.margin = new RectOffset(5, 5, 1, 1);
					mProgressBar.normal.background = GetTexture(0x128ce1ff);
				}
				return mProgressBar;
			}
		}

		public static void HorizontalSeparator()
		{
			GUILayout.Label("", hSeparator);
		}




	}
}

