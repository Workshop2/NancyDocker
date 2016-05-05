FROM mono

COPY . /src

WORKDIR /src

RUN xbuild NancyConsole.sln /p:TargetFrameworkVersion="v4.0"

EXPOSE 8001

CMD ["mono", "/src/NancyConsole/bin/Debug/NancyConsole.exe"]
