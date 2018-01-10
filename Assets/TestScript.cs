/**
 * @author    TeraTaka
 * @code      COLORIS
 * @copyright NorthRetro
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UniRx;

/**
 * TestScript
 */
namespace Assets.Scripts
{
	public class TestScript : MonoBehaviour
	{
		
		void Start()
		{
			// クリック確認用のストリーム
			var click_stream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0));
			// ストリームが実行されたらログを出力
			click_stream.Subscribe(_ => Debug.Log("click!!"));
			var nihongo = click_stream.Subscribe(_ => Debug.Log("このイベントも実行するよ！")); // 2つの処理を同時に走らせたり、変数に入れてもストリームを受け取って実行する。

			// 1秒間に1回実行するストリーム
			var second_stream = Observable.Interval(TimeSpan.FromSeconds(1));
			// 1秒間に1回「wasshoi」とログに書き出す
			var wasshoi = second_stream.Subscribe(_ => Debug.Log("wasshoi"));
			// ただし、1回でもクリックされるとストリームの実行を停止させる
			click_stream.Take(1).Subscribe(_ => wasshoi.Dispose());
		}
	}
}
