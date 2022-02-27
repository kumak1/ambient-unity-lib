# ambient-unity-lib

ambient-unity-lib は [Ambient](https://ambidata.io/) との通信を楽にする API Client です

## Installing

### プロジェクトへパッケージの追加

Unity の `Package Manager` から追加します。

1. `+` アイコンをクリック
2. `Add package from git URL...` をクリック
3. `git@github.com:kumak1/ambient-unity-lib.git` を入力

## Usage

```cs
var ambient = new Ambient("channel id", "read key", "write key");

ambient.Send(new AmbientSendParameter { D1 = "0.5" });
ambient.Read();
```