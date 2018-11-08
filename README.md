# LoggingExperiment
  ロギングの実験

## 実験概要
  マルチプロセスで同一ファイルにログ出力を行った場合の実験


## 実験方法
  コマンドプロンプトで以下のコマンド実行

  - NLog
    ```
    start Logging.exe -l nlog -c ＜ログ数＞ テストです
    start Logging.exe -l nlog -c ＜ログ数＞ テストです
    start Logging.exe -l nlog -c ＜ログ数＞ テストです
    ```

  - log4Net
    ```
    start Logging.exe -l log4net -c ＜ログ数＞ テストです
    start Logging.exe -l log4net -c ＜ログ数＞ テストです
    start Logging.exe -l log4net -c ＜ログ数＞ テストです
    ```

## 実験結果
- NLog
  - `AsyncWrapper` or `BufferingWrapper` を利用しない場合は遅い
  - `<targets async="true">` で `AsyncWrapper` を利用した場合、ログ数が多くなるとログ消失する
    これは、`AsyncWrapper` の `overflowAction ` の規定値が `Discard` の為
  - `BufferingWrapper` を利用すると、ログ数10000でもログ消失することがなかった

- log4Net
  `lockingModel` を設定しても、ログ数100でログ消失が発生した

## 感想
  - 実験結果からNLogがよさそう
