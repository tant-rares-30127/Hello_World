# HelloWorld

## How to deploy to Heroku

1. Login to heroku 
```
heroku login
```

2. Build container

Build docker image:
```
docker build -t rares_web_by_borys .
```

Create and run docker container
```
docker run -d -p 8081:80 --name rares_web_by_borys_container rares_web_by_borys
```

After running app locally in docker will be available [here](http://localhost:8081/)