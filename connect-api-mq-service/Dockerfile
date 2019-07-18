#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["connect-api-mq-service/connect-api-mq-service.csproj", "connect-api-mq-service/"]
RUN dotnet restore "connect-api-mq-service/connect-api-mq-service.csproj"
COPY . .
WORKDIR "/src/connect-api-mq-service"
RUN dotnet build "connect-api-mq-service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "connect-api-mq-service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "connect-api-mq-service.dll"]