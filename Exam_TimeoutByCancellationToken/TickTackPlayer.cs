// @(h)TickTackPlayer.cs ver 0.00 ( '24.04.12 Nov-Lab ) プロトタイプを元に作成開始
// @(h)TickTackPlayer.cs ver 0.51 ( '24.04.12 Nov-Lab ) ベータ版完成
// @(h)TickTackPlayer.cs ver 0.51a( '24.04.13 Nov-Lab ) コメント整理

// @(s)
// 　【チクタクプレイヤー】チクタク音を再生する機能を提供します。

// ・XTickTackPlayer.cs が本サンプルプロジェクトの主要部分です。
//   CancellationToken に対応する非同期メソッドへタイムアウト処理を追加する方法を知りたい方は、そちらをご参照ください。

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace Exam_TimeoutByCancellationToken
{
    //====================================================================================================
    /// <summary>
    /// 【チクタクプレイヤー】チクタク音を再生する機能を提供します。
    /// </summary>
    //====================================================================================================
    public partial class TickTackPlayer
    {
        // ＜メモ＞
        // ・このサンプルでは省略していますが、１つのサウンドデータをすべてのインスタンスで共有した方がメモリー効率は良くなります。
        //====================================================================================================
        // 内部フィールド
        //====================================================================================================
        /// <summary>
        /// 【Tick音】Tick音を再生するためのサウンドプレイヤーです。
        /// </summary>
        protected SoundPlayer m_tickSound = new SoundPlayer(Path.Combine(Application.StartupPath, "SoundData\\Tick.wav"));

        /// <summary>
        /// 【Tack音】Tack音を再生するためのサウンドプレイヤーです。
        /// </summary>
        protected SoundPlayer m_tackSound = new SoundPlayer(Path.Combine(Application.StartupPath, "SoundData\\Tack.wav"));


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【コンストラクター】サウンドデータを読み込みます。
        /// </summary>
        //--------------------------------------------------------------------------------
        public TickTackPlayer()
        {
            //------------------------------------------------------------
            /// サウンドデータを読み込む
            //------------------------------------------------------------
            m_tickSound.Load();                                         //// Tick音のサウンドデータを読み込む
            m_tackSound.Load();                                         //// Tack音のサウンドデータを読み込む


            //------------------------------------------------------------
            /// 一度ダミーで待機しておく
            ///- (初回の待機だけなぜか時間がかかる場合があるが、一度待機しておくことでこの問題を回避できる)
            //------------------------------------------------------------
            using (var task = Task.Delay(10)) { task.Wait(); }          //// 10ミリ秒待機する(Thread.Sleep でないのは PlayAsync と同じ方法に揃えるため)
        }


        // ＜メモ＞
        // ・タイムアウトに対応していない非同期メソッドのサンプルです。
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【非同期チクタク再生】非同期で、指定されたリピート回数だけチクタク音を再生します。
        /// </summary>
        /// <param name="repeatNum">        [in ]：リピート回数</param>
        /// <param name="cancellationToken">[in ]：キャンセルトークン。取り消し要求機能を使わない場合は <see cref="CancellationToken.None"/></param>
        /// <returns>
        /// 非同期処理のタスク。
        /// </returns>
        /// <exception cref="OperationCanceledException">操作取り消し例外。キャンセルトークンによって取り消し要求が通知されました。</exception>
        //--------------------------------------------------------------------------------
        public async Task PlayAsync(int repeatNum, CancellationToken cancellationToken)
        {
            //------------------------------------------------------------
            /// 指定されたリピート回数だけチクタク音を再生する
            //------------------------------------------------------------
            try
            {                                                           //// try開始
                for (int ctrRepeat = 0; ctrRepeat < repeatNum; ctrRepeat++)
                {                                                       /////  リピート回数分、繰り返す
                    Debug.Print($"Tick {ctrRepeat + 1}");
                    m_tickSound.Play();                                 //////   Tick音を再生開始する
                    await Task.Delay(500, cancellationToken);           //////   0.5秒待機する(キャンセルトークンの監視付き)
                    m_tickSound.Stop();                                 //////   Tick音を停止する

                    Debug.Print($"Tack {ctrRepeat + 1}");
                    m_tackSound.Play();                                 //////   Tack音を再生開始する
                    await Task.Delay(500, cancellationToken);           //////   0.5秒待機する(キャンセルトークンの監視付き)
                    m_tackSound.Stop();                                 //////   Tack音を停止する
                }
            }
            finally                                                     //// 例外は処理せずに呼び出し元に受け取らせる
            {                                                           //// finnaly：後始末
                m_tickSound.Stop();                                     /////  Tick音を停止する
                m_tackSound.Stop();                                     /////  Tack音を停止する
            }
        }

    } // class

} // namespace
