# HelloWorld

## How to deploy to Heroku

1. Login to heroku 
```
heroku login
```

2. Build container

Build docker image:
```
docker build -t rareshelloworldapp
```

3. Create and run docker container
```
docker run -d -p 8081:80 --name rareshelloworldapp_container rareshelloworldapp
```
