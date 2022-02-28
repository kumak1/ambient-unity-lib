# ambient-unity-lib

ambient-unity-lib は [Ambient](https://ambidata.io/) との通信を楽にする API Client です

## Install

UnityProject の `manifest.json` に以下記述を追加してください

```json
{
  "scopedRegistries": [
    {
      "name": "npm",
      "url": "https://registry.npmjs.com",
      "scopes": [
        "com.kumak1"
      ]
    }
  ],
  "dependencies": {
    "com.kumak1.ambient-unity-lib": "0.1.1",

    // 中略
    
  }
}

```

## Usage

```cs
using AmbientUnityLib;
```

```cs
var ambient = new Ambient("channel id", "read key", "write key");

ambient.Send(new AmbientSendParameter { D1 = "0.5" });
ambient.Read();
```