#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM centos:7 AS base
ENV container docker
RUN (cd /lib/systemd/system/sysinit.target.wants/; for i in *; do [ $i == \
systemd-tmpfiles-setup.service ] || rm -f $i; done); \
rm -f /lib/systemd/system/multi-user.target.wants/*;\
rm -f /etc/systemd/system/*.wants/*;\
rm -f /lib/systemd/system/local-fs.target.wants/*; \
rm -f /lib/systemd/system/sockets.target.wants/*udev*; \
rm -f /lib/systemd/system/sockets.target.wants/*initctl*; \
rm -f /lib/systemd/system/basic.target.wants/*;\
rm -f /lib/systemd/system/anaconda.target.wants/*;
VOLUME [ "/sys/fs/cgroup" ]
CMD ["/usr/sbin/init"]

# Install dotnet-sdk
RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm; \
    yum install dotnet-sdk-6.0 -y;

# Run our application
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM centos:7 AS build
WORKDIR /src
COPY ["UserApi/UserApi.csproj", "UserApi/"]
RUN dotnet restore "UserApi/UserApi.csproj"
COPY . .
WORKDIR "/src/UserApi"
RUN dotnet build "UserApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserApi.dll"]