# .NET用サンプル：Exam_TimeoutByCancellationToken

CancellationToken に対応する非同期メソッドへタイムアウト処理を追加する方法のサンプルです。

この方法を使うことで、Stream.ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) などのように、CancellationToken には対応しているがタイムアウトには対応していない既存の非同期メソッドへ、後付けでタイムアウト処理を追加することができます。

ソースコードと実行結果を併せてご覧ください。

なお、本サンプルは非同期メソッドの動作状況をチクタク音で確認するようにしていますので、スピーカーやヘッドフォンをつないで実行してください。

## サンプルのポイント

[XTickTackPlayer.cs](https://github.com/Nov-Lab/Exam_TimeoutByCancellationToken/blob/master/Exam_TimeoutByCancellationToken/XTickTackPlayer.cs) が本サンプルの主要部分です。

XTickTackPlayer.XPlayAsync メソッドにより、既存の非同期メソッド TickTackPlayer.PlayAsync にタイムアウト処理を追加した拡張メソッドを提供しています。


# 動作環境

- Windows 8.1以降
- .NET Framework 4.5.1 以降、または互換性のある .NET 実装


# ライセンス

本ソフトウェアは、MITライセンスに基づいてライセンスされています。


# 開発環境

## 開発ツール、SDKなど
- Visual Studio Community 2019
  - ワークロード：.NET デスクトップ開発

## 言語
- C#


# その他

Nov-Lab 独自の記述ルールと用語については [NovLabRule.md](https://github.com/Nov-Lab/Nov-Lab/blob/main/NovLabRule.md) を参照してください。
