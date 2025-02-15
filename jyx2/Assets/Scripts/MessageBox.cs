/*
 * 金庸群侠传3D重制版
 * https://github.com/jynew/jynew
 *
 * 这是本开源项目文件头，所有代码均使用MIT协议。
 * 但游戏内资源和第三方插件、dll等请仔细阅读LICENSE相关授权协议文档。
 *
 * 金庸老先生千古！
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using HanSquirrel.ResourceManager;
using Jyx2;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    public Button m_ConfirmButton;
    public Text m_MessageText;

    public static void Create(string msg, Action callback, Transform parent = null)
    {
        if(parent == null)
        {
            var go = GameObject.Find("MainUI");
            parent = go.transform;
        }

        var obj = Jyx2ResourceHelper.CreatePrefabInstance("Assets/Prefabs/MessageBox.prefab");
        obj.transform.SetParent(parent);

        var rt = obj.GetComponent<RectTransform>();
        rt.localPosition = Vector3.zero;
        rt.localScale = Vector3.one;

        var messageBox = obj.GetComponent<MessageBox>();
        messageBox.Show(msg, callback);
    }

    public void Show(string msg, Action callback)
    {
        m_MessageText.text = msg;
        m_ConfirmButton.onClick.RemoveAllListeners();
        m_ConfirmButton.onClick.AddListener(() =>
        {
            Jyx2ResourceHelper.ReleasePrefabInstance(this.gameObject);
            if(callback != null)
                callback();
        });
    }

}
