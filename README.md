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

4. Heroku container login
```
heroku container:login
```

5. Heroku push
```
heroku container:push -a rareshelloworldapp web
```

6. Release the container
```
heroku container:release -a rareshelloworldapp web
```