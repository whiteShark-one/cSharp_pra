# 工程目录

```
cSharp_pra/
│
├── .vscode/
│   ├── launch.json
│   └── tasks.json
│
├── src/
│   │
│   ├── Common/
│   │   └── CommonLib/
│   │
│   ├── Learning/
│   │   ├── learnAoiVision/
│   │   ├── msLearnCSharp/
│   │   └── rookieTutorial/
│   │
│   └── Backend/
│       │
│       ├── 01-BasicWebApi/
│       │   └── BasicWebApi/
│       │
│       ├── 02-BackgroundWorker/
│       │   └── BackgroundWorker/
│       │
│       ├── 03-ConcurrentQueueLock/
│       │   └── ConcurrentQueueLock/
│       │
│       ├── 04-ChannelBatch/
│       │   └── ChannelBatch/
│       │
│       ├── 05-ProducerConsumer/
│       │   └── ProducerConsumer/
│       │
│       ├── 06-FileProcessing/
│       │   └── FileProcessing/
│       │
│       ├── 07-TimerTask/
│       │   └── TimerTask/
│       │
│       ├── 08-RedisCache/
│       │   └── RedisCache/
│       │
│       ├── 09-MessageQueue/
│       │   └── MessageQueue/
│       │
│       ├── 10-RateLimit/
│       │   └── RateLimit/
│       │
│       ├── 11-RetryCircuitBreaker/
│       │   └── RetryCircuitBreaker/
│       │
│       └── 12-Microservice/
│           ├── ApiService/
│           ├── UserService/
│           └── OrderService/
│
├── tests/
│   └── Backend/
│       ├── 01-BasicWebApi.Tests/
│       ├── 02-BackgroundWorker.Tests/
│       ├── 03-ConcurrentQueueLock.Tests/
│       └── 04-ChannelBatch.Tests/
│
├── benchmarks/
│   ├── ConcurrentQueueBenchmark/
│   ├── ChannelBenchmark/
│   └── BatchBenchmark/
│
├── docs/
│   ├── architecture/
│   ├── learning/
│   └── testing/
│
├── deploy/
│   ├── docker/
│   ├── docker-compose/
│   └── k8s/
│
├── scripts/
│   ├── build.ps1
│   ├── test.ps1
│   └── benchmark.ps1
│
├── .gitignore
│
└── cSharp_pra.slnx
```

> 拓展

```
src/
├── Common          ← 公共代码
├── Learning        ← C#学习/教程
└── Backend         ← 后端服务实践
```

# 创建后端项目

## 01-BasicWebApi

```
#1
dotnet new webapi -n BasicWebApi -o src/Backend/01-BasicWebApi/BasicWebApi --use-controllers
#2
dotnet sln cSharp_pra.slnx add src/Backend/01-BasicWebApi/BasicWebApi/BasicWebApi.csproj
```

## 02-BackgroundWorker

```
#1
dotnet new worker -n BackgroundWorker -o src/Backend/02-BackgroundWorker/BackgroundWorker
#2
dotnet sln cSharp_pra.slnx add src/Backend/02-BackgroundWorker/BackgroundWorker/BackgroundWorker.csproj
```

## 03-ConcurrentQueueLock

```
#1
dotnet new worker -n ConcurrentQueueLock -o src/Backend/03-ConcurrentQueueLock/ConcurrentQueueLock
 #2 
dotnet sln cSharp_pra.slnx add src/Backend/03-ConcurrentQueueLock/ConcurrentQueueLock/ConcurrentQueueLock.csproj
```

## 04-ChannelBatch

```
#1
dotnet new worker -n ChannelBatch -o src/Backend/04-ChannelBatch/ChannelBatch
#2
dotnet sln cSharp_pra.slnx add src/Backend/04-ChannelBatch/ChannelBatch/ChannelBatch.csproj
```

## 05-待扩展...

------

## Solution结构

> 现在

```
<Solution>
  <Project Path="CommonLib/CommonLib.csproj" />
  <Project Path="learnAoiVision/learnAoiVision.csproj" />
  <Project Path="msLearnCSharp/msLearnCSharp.csproj" />
  <Project Path="rookieTutorial/rookieTutorial.csproj" />
</Solution>
```

> 未来应该逐渐变成类似

```
<Solution>
  <Project Path="src/Common/CommonLib/CommonLib.csproj" />

  <Project Path="src/Learning/learnAoiVision/learnAoiVision.csproj" />
  <Project Path="src/Learning/msLearnCSharp/msLearnCSharp.csproj" />
  <Project Path="src/Learning/rookieTutorial/rookieTutorial.csproj" />

  <Project Path="src/Backend/01-BasicWebApi/BasicWebApi/BasicWebApi.csproj" />
  <Project Path="src/Backend/02-BackgroundWorker/BackgroundWorker/BackgroundWorker.csproj" />
  <Project Path="src/Backend/03-ConcurrentQueueLock/ConcurrentQueueLock/ConcurrentQueueLock.csproj" />
  <Project Path="src/Backend/04-ChannelBatch/ChannelBatch/ChannelBatch.csproj" />
</Solution>
```

**不建议手工修改 `.slnx`**，后续直接使用 `dotnet sln ... add` / `remove` 维护，让 .NET CLI 管理它