// @(h)FrmAppMain.cs ver 0.00 ( '24.04.12 Nov-Lab ) 作成開始
// @(h)FrmAppMain.cs ver 0.51 ( '24.04.13 Nov-Lab ) ベータ版完成
// @(h)FrmAppMain.cs ver 0.51a( '24.04.14 Nov-Lab ) コメント整理

// @(s)
// 　【メインフォーム】本アプリケーションのメインフォームです。

// ・XTickTackPlayer.cs が本サンプルプロジェクトの主要部分です。
//   CancellationToken に対応する非同期メソッドへタイムアウト処理を追加する方法を知りたい方は、そちらをご参照ください。

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Exam_TimeoutByCancellationToken
{
    //====================================================================================================
    /// <summary>
    /// 【メインフォーム】本アプリケーションのメインフォームです。
    /// </summary>
    //====================================================================================================
    public partial class FrmAppMain : Form
    {
        //====================================================================================================
        // 内部フィールド
        //====================================================================================================

        /// <summary>
        /// 【ユーザー操作用キャンセルトークンソース】
        /// ユーザー操作による取り消し要求を行うためのキャンセルトークンソースです。
        /// </summary>
        /// <remarks>
        /// 補足<br></br>
        /// ・キャンセルトークンは再利用できないため、非同期処理を行うときに毎回生成・破棄します。
        /// </remarks>
        protected CancellationTokenSource m_ctsOperation;

        /// <summary>
        /// 【チクタク音プレイヤー】チクタク音を再生するためのプレイヤーです。
        /// </summary>
        protected TickTackPlayer m_ticktackPlayer = new TickTackPlayer();


        //====================================================================================================
        // フォームイベント
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【コンストラクター】自動生成された内容のままです。
        /// </summary>
        //--------------------------------------------------------------------------------
        public FrmAppMain()
        {
            InitializeComponent();
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【フォーム_Load】本フォームを初期化します。
        /// </summary>
        //--------------------------------------------------------------------------------
        private void FrmAppMain_Load(object sender, EventArgs e)
        {
            //------------------------------------------------------------
            /// 本フォームを初期化する
            //------------------------------------------------------------
            SBtnCancel.Visible = false;                                 //// ステータスストリップ上のキャンセルボタンを非表示にする
            M_SetStatusMessage("");                                     //// ステータスメッセージをクリアする
        }


        //====================================================================================================
        // コントロールイベント
        //====================================================================================================

        // ＜メモ＞
        // ・タイムアウト機能を追加した拡張メソッドを呼び出すサンプルです。
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【タイムアウト付きでチクタク再生ボタン_Click】
        /// タイムアウト付きでチクタク音を再生します。
        /// </summary>
        //--------------------------------------------------------------------------------
        private async void BtnTickTackWithTimeout_Click(object sender, EventArgs e)
        {
            //------------------------------------------------------------
            /// タイムアウト付きでチクタク音を再生する
            //------------------------------------------------------------
            {                                                           //// 前準備
                M_SetStatusMessage("Playing...");                       /////  ステータスメッセージに再生中メッセージを表示する
                m_ctsOperation = new CancellationTokenSource();         /////  ユーザー操作用キャンセルトークンソースを生成する
                M_AsyncModeStart();                                     /////  非同期操作モード開始処理を行う
            }

            try
            {                                                           //// try開始
                Debug.Print("Start Ticktack.");
                await m_ticktackPlayer.XPlayAsync(                      /////  タイムアウト付きでチクタク音プレイヤーを非同期再生する
                    (int)NumRepeat.Value, (int)NumTimeout.Value, m_ctsOperation.Token);
                Debug.Print("End Ticktack");

                M_SetStatusMessage("Finished.");                        /////  ステータスメッセージに再生完了メッセージを表示する
            }
            catch (TimeoutException ex)
            {                                                           //// catch：タイムアウト例外
                M_SetStatusMessage($"Timeout:{ex.Message}");            /////  ステータスメッセージにタイムアウト例外の内容を表示する
                return;                                                 /////  関数終了
            }
            catch (OperationCanceledException ex)
            {                                                           //// catch：操作取り消し例外
                M_SetStatusMessage($"Canceled:{ex.Message}");           /////  ステータスメッセージに操作取り消し例外の内容を表示する
                return;                                                 /////  関数終了
            }
            catch (Exception ex)
            {                                                           //// catch：上記以外の例外
                M_SetStatusMessage($"catch:{ex.Message}");              /////  ステータスメッセージに例外の内容を表示する
                return;                                                 /////  関数終了
            }
            finally
            {                                                           //// finally：後始末
                M_AsyncModeEnd();                                       /////  非同期操作モード終了処理を行う
                m_ctsOperation.Dispose(); m_ctsOperation = null;        /////  ユーザー操作用キャンセルトークンソースを破棄して null にクリアする
            }
        }


        // ＜メモ＞
        // ・タイムアウト機能を持たない既存のメソッドを呼び出すサンプルです。
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【タイムアウトなしでチクタク再生ボタン_Click】
        /// タイムアウトなしでチクタク音を再生します。
        /// </summary>
        //--------------------------------------------------------------------------------
        private async void BtnTicktackNoTimeout_Click(object sender, EventArgs e)
        {
            //------------------------------------------------------------
            /// タイムアウトなしでチクタク音を再生する
            //------------------------------------------------------------
            {                                                           //// 前準備
                M_SetStatusMessage("Playing...");                       /////  ステータスメッセージに再生中メッセージを表示する
                m_ctsOperation = new CancellationTokenSource();         /////  ユーザー操作用キャンセルトークンソースを生成する
                M_AsyncModeStart();                                     /////  非同期操作モード開始処理を行う
            }

            try
            {                                                           //// try開始
                Debug.Print("Start Ticktack.");
                await m_ticktackPlayer.PlayAsync(                       /////  タイムアウトなしでチクタク音プレイヤーを非同期再生する
                    (int)NumRepeat.Value, m_ctsOperation.Token);
                Debug.Print("End Ticktack");

                M_SetStatusMessage("Finished.");                        /////  ステータスメッセージに再生完了メッセージを表示する
            }
            catch (OperationCanceledException ex)
            {                                                           //// catch：操作取り消し例外
                M_SetStatusMessage($"Canceled:{ex.Message}");           /////  ステータスメッセージに操作取り消し例外の内容を表示する
                return;                                                 /////  関数終了
            }
            catch (Exception ex)
            {                                                           //// catch：上記以外の例外
                M_SetStatusMessage($"catch:{ex.Message}");              /////  ステータスメッセージに例外の内容を表示する
                return;                                                 /////  関数終了
            }
            finally
            {                                                           //// finally：後始末
                M_AsyncModeEnd();                                       /////  非同期操作モード終了処理を行う
                m_ctsOperation.Dispose(); m_ctsOperation = null;        /////  ユーザー操作用キャンセルトークンソースを破棄して null にクリアする
            }
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【キャンセルボタン_Click】
        /// ユーザー操作用キャンセルトークンソースを取り消し要求状態にして、非同期操作をキャンセルさせます。
        /// </summary>
        //--------------------------------------------------------------------------------
        private void SBtnCancel_Click(object sender, EventArgs e)
        {
            //------------------------------------------------------------
            /// ユーザー操作用キャンセルトークンソースを取り消し要求状態にする
            //------------------------------------------------------------
            m_ctsOperation.Cancel();
        }


        //====================================================================================================
        // 内部メソッド
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【ステータスメッセージ設定】ステータスラベルにメッセージ文字列を表示します。Debug 構成の場合はデバッグ出力もします。
        /// </summary>
        /// <param name="message">[in ]：メッセージ文字列</param>
        //--------------------------------------------------------------------------------
        protected void M_SetStatusMessage(string message)
        {
            //------------------------------------------------------------
            /// ステータスラベルにメッセージ文字列を表示する
            //------------------------------------------------------------
            SLblStatus.Text = message.Replace("\r", "").Replace("\n", "");  //// メッセージ文字列から改行文字を削除してステータスラベルに表示する

            if (string.IsNullOrEmpty(message) == false)
            {                                                               //// メッセージ文字列が有効な場合
                Debug.Print(message);                                       /////  デバッグ出力する
            }
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【非同期操作モード開始】非同期操作の前準備として、本フォームを非同期操作中状態(キャンセルボタンだけ操作可能な状態)にします。
        /// </summary>
        //--------------------------------------------------------------------------------
        protected void M_AsyncModeStart()
        {
            //------------------------------------------------------------
            /// 本フォームを非同期操作中状態にする
            //------------------------------------------------------------
            GrpTicktack.Enabled = false;                                //// 操作部グループボックスを使用不可能にする
            menuStrip.Enabled = false;                                  //// メニューストリップを使用不可能にする
            SBtnCancel.Visible = true;                                  //// ステータスストリップ上のキャンセルボタンを表示する
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【非同期操作モード終了】非同期操作の後始末として、本フォームを通常状態に戻します。
        /// </summary>
        //--------------------------------------------------------------------------------
        protected void M_AsyncModeEnd()
        {
            //------------------------------------------------------------
            /// 本フォームを通常状態に戻す
            //------------------------------------------------------------
            GrpTicktack.Enabled = true;                                 //// 操作部グループボックスを使用可能に戻す
            menuStrip.Enabled = true;                                   //// メニューストリップを使用可能に戻す
            SBtnCancel.Visible = false;                                 //// ステータスストリップ上のキャンセルボタンを非表示に戻す
        }


        //====================================================================================================
        // 実験用メソッド
        //====================================================================================================

        private async void MnuTest_TestLogic1_Click(object sender, EventArgs e) => await M_TestLogic1();

        private async void MnuTest_TestLogic2_Click(object sender, EventArgs e) => await M_TestLogic2();


        //--------------------------------------------------------------------------------
        // 実験：タスクの実行が完了する前にタスクを破棄するとどうなるか？
        // 結果：InvalidOperationException例外が発生する。
        //     ：「タスクを破棄できるのは、そのタスクが完了状態 (RanToCompletion、Faulted、または Canceled) の場合だけです。」
        //--------------------------------------------------------------------------------
        protected async Task M_TestLogic1()
        {
            this.Enabled = false;
            M_SetStatusMessage("Start:M_TestLogic1");

            using (var task = m_ticktackPlayer.PlayAsync(5, CancellationToken.None))/// using：リピート回数 = 5回 でチクタク再生タスクを生成する
            {
                await Task.Delay(2000);                                             ////  非同期で2秒待機する
                task.Dispose();                                                     ////  タスクを破棄する(タスクの実行が完了する前なので例外が発生する)
            }

            M_SetStatusMessage("End:M_TestLogic1");
            this.Enabled = true;
        }


        //--------------------------------------------------------------------------------
        // 実験：タスク.Wait(int millisecondsTimeout) の動作内容
        // 結果：指定した時間だけ同期的に待機する。Wait がタイムアウトした後も、タスク自体は継続される。
        //--------------------------------------------------------------------------------
        protected async Task M_TestLogic2()
        {
            this.Enabled = false;
            M_SetStatusMessage("Start:M_TestLogic2");

            using (var task = m_ticktackPlayer.PlayAsync(5, CancellationToken.None))/// リピート回数 = 5回 でチクタク再生タスクを生成する
            {
                M_SetStatusMessage("Waits for the Task to complete execution.");
                task.Wait(2000);                                                    ////  タスクの実行が完了するまで2秒待機する
                M_SetStatusMessage("Wait is timeout. Task is running.");            ////  (待機がタイムアウトしても、タスク自体は継続される)

                while (task.IsCompleted == false)
                {                                                                   ////  タスクが完了するまで、繰り返す
                    await Task.Delay(20);                                           /////   非同期で20ミリ秒待機する
                }
                task.Dispose();                                                     ////  タスクを破棄する
            }

            M_SetStatusMessage("End:M_TestLogic2");
            this.Enabled = true;
        }

    } // class

} // namespace
