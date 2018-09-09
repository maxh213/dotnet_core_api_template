FROM microsoft/dotnet:2.1-sdk 

WORKDIR /Api
COPY /Api .

RUN ["dotnet", "restore"]

EXPOSE 60000/tcp

ENTRYPOINT ["dotnet"]
CMD ["run"]