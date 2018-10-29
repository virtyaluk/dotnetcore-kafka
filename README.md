# Getting started with .NET Core and Kafka

This repo contains the code samples for the [Getting started with .NET Core and Kafka](https://www.hugopicado.com/2017/11/22/getting-started-with-net-core-and-kafka.html) tutorial.

## :dvd: Setup

Have [Docker :whale2:](https://docs.docker.com/install/) and [.NET Core](https://www.microsoft.com/net/download) installed.

From the root of the project run following:

```sh
docker-compose up --build
```

then in the producer project:

```sh
cd KafkaProducer/
dotnet restore
dotnet build -c Release
dotnet bin/Release/netcoreapp2.1/KafkaProducer.dll
```

and in the consumer project:

```sh
cd KafkaConsumer/
dotnet restore
dotnet build -c Release
dotnet bin/Release/netcoreapp2.1/KafkaConsumer.dll

```

## :green_book: License

[Licensed under the MIT license.](https://github.com/virtyaluk/dotnetcore-kafka/blob/master/LICENSE)

Copyright (c) 2018 Bohdan Shtepan

---

> [modern-dev.com](http://modern-dev.com) &nbsp;&middot;&nbsp;
> GitHub [@virtyaluk](https://github.com/virtyaluk) &nbsp;&middot;&nbsp;
> Twitter [@virtyaluk](https://twitter.com/virtyaluk)