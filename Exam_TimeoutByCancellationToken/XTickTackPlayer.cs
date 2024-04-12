// @(h)XTickTackPlayer.cs ver 0.00 ( '24.04.12 Nov-Lab ) プロトタイプを元に作成開始
// @(h)XTickTackPlayer.cs ver 0.51 ( '24.04.12 Nov-Lab ) ベータ版完成
// @(h)XTickTackPlayer.cs ver 0.51a( '24.04.13 Nov-Lab ) コメント整理

// @(s)
// 　【TickTackPlayer 拡張メソッド】TickTackPlayer クラスに拡張メソッドを追加します。

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


// ■本サンプルプロジェクトの主要部分です。
//   CancellationToken に対応する非同期メソッドへタイムアウト処理を追加する方法のサンプルです。
//   この方法は Stream.ReadAsync などにも応用可能です。
//
//   ＜他の非同期メソッドに応用したい場合＞
//   1)await target.PlayAsync(repeatNum, ctsTotal.Token); の行を、目的の非同期メソッドを呼び出すように置き換えます。
//     このとき、キャンセルトークンは必ず ctsTotal.Token を渡します。
//   2)目的の非同期メソッドに合わせて、引数や戻り値を適宜調整します。

namespace Exam_TimeoutByCancellationToken
{
    // ＜補足＞
    // ・修正することのできない既存の非同期メソッドへタイムアウト処理を追加する想定でのサンプルなので、
    //   あえて TickTackPlayer クラスとは別のクラスにしています。
    //====================================================================================================
    /// <summary>
    /// 【TickTackPlayer 拡張メソッド】<see cref="TickTackPlayer"/> クラスに拡張メソッドを追加します。
    /// </summary>
    //====================================================================================================
    public static partial class XTickTackPlayer
    {
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【非同期チクタク再生】非同期で、指定されたリピート回数だけチクタク音を再生します。
        /// </summary>
        /// <param name="target">             [in ]：対象インスタンス</param>
        /// <param name="repeatNum">          [in ]：リピート回数</param>
        /// <param name="millisecondsTimeout">[in ]：タイムアウト時間(ミリ秒)。無期限に待機する場合は <see cref="Timeout.Infinite"/>(-1)</param>
        /// <param name="cancellationToken">  [in ]：キャンセルトークン。取り消し要求機能を使わない場合は <see cref="CancellationToken.None"/></param>
        /// <returns>
        /// 非同期処理のタスク。
        /// </returns>
        /// <exception cref="OperationCanceledException">操作取り消し例外。キャンセルトークンによって取り消し要求が通知されました。</exception>
        /// <exception cref="TimeoutException">          タイムアウト例外。タイムアウト時間内に処理が完了しませんでした。</exception>
        /// <remarks>
        /// 補足<br></br>
        /// ・<see cref="TickTackPlayer.PlayAsync(int, CancellationToken)"/> へタイムアウト処理を追加した拡張メソッドです。<br></br>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public static async Task XPlayAsync(this TickTackPlayer target
                                          , int repeatNum
                                          , int millisecondsTimeout, CancellationToken cancellationToken)
        {
            //------------------------------------------------------------
            /// タイムアウト処理付きで非同期チクタク再生処理を行う
            //------------------------------------------------------------
            var ctsTimeout = new CancellationTokenSource();             //// タイムアウト用キャンセルトークンソースを生成する

            var ctsTotal =                                              //// 引数で指定されたキャンセルトークンとタイムアウト用キャンセルトークンを結合して、総合キャンセルトークンソースを生成する
                CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, ctsTimeout.Token);

            try
            {                                                           //// try開始
                ctsTimeout.CancelAfter(millisecondsTimeout);            /////  タイムアウト用キャンセルトークンソースにタイムアウト時間を設定する
                await target.PlayAsync(repeatNum, ctsTotal.Token);      /////  非同期チクタク再生処理を行う
                ctsTimeout.CancelAfter(Timeout.Infinite);               /////  タイムアウト用キャンセルトークンソースのタイムアウト時間を解除する
            }
            catch (OperationCanceledException)
            {                                                           //// catch:操作取り消し例外
                ctsTimeout.CancelAfter(Timeout.Infinite);               /////  タイムアウト用キャンセルトークンソースのタイムアウト時間を解除する

                if (ctsTimeout.IsCancellationRequested)
                {                                                       /////  タイムアウトによる取り消しの場合(タイムアウト用キャンセルトークンソースが取り消し要求状態の場合)
                    throw new TimeoutException();                       //////   タイムアウト例外をスローする
                }
                else
                {                                                       /////  タイムアウトによる取り消しでない場合
                    throw;                                              //////   例外を再スローする
                }
            }
            finally                                                     //// 上記以外の例外は処理せずに呼び出し元に受け取らせる
            {                                                           //// finally:後始末
                ctsTotal.Dispose();                                     /////  総合キャンセルトークンソースを破棄する
                ctsTimeout.Dispose();                                   /////  タイムアウト用キャンセルトークンソースを破棄する
            }
        }

    } // class

} // namespace
